// <copyright file="IQueryDispatcher.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Query dispatcher interface. Allows execute the query handlers linked with the query object passed as arguments.
    /// </summary>
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Allows running the query passed as argument.
        /// </summary>
        /// <typeparam name="TQueryObject">Type of query object.</typeparam>
        /// <typeparam name="TQueryResult">Type of query result.</typeparam>
        /// <param name="queryObject">A <see cref="TQueryObject"/> reference to the query object with data to do the query.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <returns>A <see cref="Task{TQueryResult}"/> reference to the object with the result of query execution.</returns>
        Task<TQueryResult> Run<TQueryObject, TQueryResult>(TQueryObject queryObject, CancellationToken cancellationToken = default)
                where TQueryObject : class
                where TQueryResult : class;
    }
}
