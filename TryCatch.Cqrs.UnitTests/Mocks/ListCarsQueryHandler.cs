// <copyright file="ListCarsQueryHandler.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Patterns.Results;

    public class ListCarsQueryHandler : IListCarsQueryHandler
    {
        private readonly IQueryable<Car> entities;

        private readonly PageResultBuilder<Car> builder;

        public ListCarsQueryHandler(PageResultBuilder<Car> builder)
        {
            this.builder = builder;

            var cars = new List<Car>();

            for (var i = 1; i < 21; i++)
            {
                cars.Add(new Car("REFERENCE-0{i}"));
            }

            this.entities = cars.AsQueryable();
        }

        public async Task<PageResult<Car>> Execute(ListCarsQueryObject queryObject, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            foreach (var car in this.entities)
            {
                await car.Start().ConfigureAwait(false);
            }

            var items = this.entities.Where(x => x.IsOn == queryObject.IsOn).ToList();

            return this.builder.Build()
                .WithCount(items.LongCount())
                .WithMatched(items.LongCount())
                .WithOffset(queryObject.Offset)
                .WithLimit(queryObject.Limit)
                .WithItems(items)
                .Create();
        }
    }
}
