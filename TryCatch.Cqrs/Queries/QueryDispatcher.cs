// <copyright file="QueryDispatcher.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Validators;

    /// <summary>
    /// Query dispatcher interface. Execute the query handler linked to the query object reference specified as the argument.
    /// </summary>
    public abstract class QueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryHandlersFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryDispatcher"/> class.
        /// </summary>
        /// <param name="factory">A <see cref="IQueryHandlersFactory"/> reference to the query handler factory.</param>
        protected QueryDispatcher(IQueryHandlersFactory factory)
        {
            ArgumentsValidator.ThrowIfIsNull(factory, nameof(factory));

            this.factory = factory;
        }

        /// <inheritdoc/>
        public async Task<TQueryResult> Run<TQueryObject, TQueryResult>(TQueryObject queryObject, CancellationToken cancellationToken = default)
            where TQueryResult : class
            where TQueryObject : class
        {
            cancellationToken.ThrowIfCancellationRequested();

            ArgumentsValidator.ThrowIfIsNull(queryObject, $"QueryObject {typeof(TQueryObject).Name} is null.");

            var handler = this.factory.GetHandler<TQueryObject, TQueryResult>();

            return await handler.Execute(queryObject, cancellationToken).ConfigureAwait(false);
        }
    }
}
