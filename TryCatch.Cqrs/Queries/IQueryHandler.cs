// <copyright file="IQueryHandler.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Query handler interface.
    /// </summary>
    /// <typeparam name="TQueryObject">Type of query object.</typeparam>
    /// <typeparam name="TQueryResult">Type of query result.</typeparam>
    public interface IQueryHandler<TQueryObject, TQueryResult>
    {
        /// <summary>
        /// Execute the query passed as argument.
        /// </summary>
        /// <param name="queryObject">A <see cref="TQueryObject"/> reference to the Query object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">Throws exception when query object passed as argument is null.</exception>
        /// <returns>A <see cref="TQueryResult"/> reference with the results of the query handler execution.</returns>
        Task<TQueryResult> Execute(TQueryObject queryObject, CancellationToken cancellationToken = default);
    }
}
