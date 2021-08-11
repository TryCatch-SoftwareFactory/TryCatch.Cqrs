// <copyright file="ICommandDispatcher.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Patterns.Results;

    /// <summary>
    /// Command dispatcher interface. Allows execute the command handlers linked with the commands passed as arguments.
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Allows running the command used as argument.
        /// </summary>
        /// <typeparam name="TCommand">Type of the command.</typeparam>
        /// <typeparam name="TPayload">Type of the payload.</typeparam>
        /// <param name="command">A <see cref="TCommand"/> reference to the command.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">Throws an exception when command passed as argument is null.</exception>
        /// <returns>A <see cref="Task{Result{TPayload}}"/> reference with result info from command handler execution.</returns>
        Task<Result<TPayload>> Run<TCommand, TPayload>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : class;
    }
}
