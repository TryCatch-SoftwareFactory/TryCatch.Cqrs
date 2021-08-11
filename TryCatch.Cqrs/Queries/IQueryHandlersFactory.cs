// <copyright file="IQueryHandlersFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Queries
{
    using System;
    using TryCatch.Patterns.Factories;

    /// <summary>
    /// Query handlers factory interface. Allows obtaining a reference to each query handler linked with any query object registered in the system.
    /// </summary>
    public interface IQueryHandlersFactory
    {
        /// <summary>
        /// Allows registering the mapper entry between query object and their query handler.
        /// </summary>
        /// <typeparam name="TQueryObject">Type of query object.</typeparam>
        /// <typeparam name="TQueryHandler">Type of query handler.</typeparam>
        /// <exception cref="ArgumentNullException">Throws the exception if the query object or the query handler passed as argument is null.</exception>
        /// <exception cref="DuplicateComponentException">Throws the exception if the command has been registered previously.</exception>
        /// <exception cref="ComponentNotFoundException">Throws the exception when the implementation of the query handler is not registerd in the service provider.</exception>
        /// <returns>Indicates if register was successful.</returns>
        bool Register<TQueryObject, TQueryHandler>()
                where TQueryObject : class
                where TQueryHandler : class;

        /// <summary>
        /// Allows getting the query handler reference linked to query object passed as argument.
        /// </summary>
        /// <typeparam name="TQueryObject">Type of query object.</typeparam>
        /// <typeparam name="TQueryResult">Type of query result.</typeparam>
        /// <exception cref="ArgumentNullException">Throws the exception if the query object or the query handler passed as argument is null.</exception>
        /// <exception cref="DuplicateComponentException">Throws the exception if the command has been registered previously.</exception>
        /// <exception cref="ComponentNotFoundException">Throws the exception when the implementation of the query handler is not registerd in the service provider.</exception>
        /// <returns>A <see cref="IQueryHandler{TQueryObject, TQueryResult}"/> reference to the query handler linked to the query object.</returns>
        IQueryHandler<TQueryObject, TQueryResult> GetHandler<TQueryObject, TQueryResult>()
            where TQueryObject : class
            where TQueryResult : class;
    }
}
