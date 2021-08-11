// <copyright file="CommandDispatcher.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Patterns.Results;
    using TryCatch.Validators;

    /// <summary>
    /// Command dispatcher interface. Execute the command handler linked to the Command reference specified as the argument.
    /// </summary>
    public abstract class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlersFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandDispatcher"/> class.
        /// </summary>
        /// <param name="factory">A <see cref="ICommandHandlersFactory"/> reference to the command handler factory.</param>
        protected CommandDispatcher(ICommandHandlersFactory factory)
        {
            ArgumentsValidator.ThrowIfIsNull(factory, nameof(factory));

            this.factory = factory;
        }

        /// <inheritdoc/>
        public async Task<Result<TPayload>> Run<TCommand, TPayload>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : class
        {
            cancellationToken.ThrowIfCancellationRequested();

            ArgumentsValidator.ThrowIfIsNull(command, $"Command {typeof(TCommand).Name} is null.");

            var handler = this.factory.GetHandler<TCommand, TPayload>();

            return await handler.Execute(command, cancellationToken).ConfigureAwait(false);
        }
    }
}
