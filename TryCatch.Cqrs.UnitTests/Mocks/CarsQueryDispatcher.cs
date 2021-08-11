// <copyright file="CarsQueryDispatcher.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    using TryCatch.Cqrs.Queries;

    public class CarsQueryDispatcher : QueryDispatcher
    {
        public CarsQueryDispatcher(IQueryHandlersFactory queryHandlersFactory)
            : base(queryHandlersFactory)
        {
        }
    }
}
