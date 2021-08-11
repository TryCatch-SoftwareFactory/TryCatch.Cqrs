// <copyright file="QueryHandlersFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Queries
{
    using System;
    using TryCatch.Cqrs.Exceptions;
    using TryCatch.Patterns.Factories;
    using TryCatch.Validators;

    /// <summary>
    /// Implementation of query handlers factory.
    /// </summary>
    public class QueryHandlersFactory : AbstractFactory, IQueryHandlersFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandlersFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> reference to service provider.</param>
        public QueryHandlersFactory(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        /// <inheritdoc/>
        public bool Register<TQueryObject, TQueryHandler>()
                where TQueryObject : class
                where TQueryHandler : class
        {
            var name = typeof(TQueryObject).Name;

            return this.RegisterType(name, typeof(TQueryHandler));
        }

        /// <inheritdoc/>
        public IQueryHandler<TQueryObject, TQueryResult> GetHandler<TQueryObject, TQueryResult>()
            where TQueryObject : class
            where TQueryResult : class
        {
            var name = typeof(TQueryObject).Name;

            var service = this.GetType(name) as IQueryHandler<TQueryObject, TQueryResult>;

            if (service is null)
            {
                throw new QueryHandlerNotFoundException($"The query handler for {name} is not found.");
            }

            return service;
        }
    }
}
