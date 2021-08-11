// <copyright file="ICommandHandlersFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Commands
{
    using System;
    using TryCatch.Patterns.Factories;

    /// <summary>
    /// Command handlers factory interface. Allows building references to each command handler linked with any command registered in the system.
    /// </summary>
    public interface ICommandHandlersFactory
    {
        /// <summary>
        /// Allows to register the mapper entry between command and their command handler.
        /// </summary>
        /// <typeparam name="TCommand">Type of command to be register.</typeparam>
        /// <typeparam name="TCommandHandler">Type of command handler interface to be register.</typeparam>
        /// <exception cref="ArgumentNullException">Throws the exception if the command or the command handler passed as argument is null.</exception>
        /// <exception cref="DuplicateComponentException">Throws the exception if the command has been registered previously.</exception>
        /// <exception cref="ComponentNotFoundException">Throws the exception when the implementation of the query handler is not registerd in the service provider.</exception>
        /// <returns>Indicates if register was successful.</returns>
        bool Register<TCommand, TCommandHandler>()
                where TCommand : class
                where TCommandHandler : class;

        /// <summary>
        /// Allows to get the command handler reference linked to command passed as argument.
        /// </summary>
        /// <typeparam name="TCommand">Type of the command.</typeparam>
        /// <typeparam name="TPayload">Type of the payload.</typeparam>
        /// <exception cref="ArgumentNullException">Throws the exception if the command passed as argument is null.</exception>
        /// <exception cref="CommandHandlerNotFoundException">Throws the exception if the command handler is not found.</exception>
        /// <exception cref="ComponentNotFoundException">Throws the exception when the implementation of the command handler is not registerd in the service provider.</exception>
        /// <returns>A <see cref="ICommandHandler{TCommand, TPayload}"/> reference to the command handler linked to the command.</returns>
        ICommandHandler<TCommand, TPayload> GetHandler<TCommand, TPayload>()
            where TCommand : class;
    }
}
