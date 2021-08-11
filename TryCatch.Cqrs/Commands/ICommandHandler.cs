// <copyright file="ICommandHandler.cs" company="TryCatch Software Factory">
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
    /// Define the common interface of any command handler.
    /// </summary>
    /// <typeparam name="TCommand">Type of the command.</typeparam>
    /// <typeparam name="TPayload">Type of the payload.</typeparam>
    public interface ICommandHandler<TCommand, TPayload>
        where TCommand : class
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="command">A <see cref="TCommand"/> reference to the command.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">Throws exception when command passed as argument is null.</exception>
        /// <returns>A <see cref="Task{Result{TPayload}}"/> reference with result info from command handler execution.</returns>
        Task<Result<TPayload>> Execute(TCommand command, CancellationToken cancellationToken = default);
    }
}
