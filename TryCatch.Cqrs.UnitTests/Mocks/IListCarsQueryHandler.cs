// <copyright file="IListCarsQueryHandler.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    using TryCatch.Cqrs.Queries;
    using TryCatch.Patterns.Results;

    public interface IListCarsQueryHandler : IQueryHandler<ListCarsQueryObject, PageResult<Car>>
    {
    }
}
