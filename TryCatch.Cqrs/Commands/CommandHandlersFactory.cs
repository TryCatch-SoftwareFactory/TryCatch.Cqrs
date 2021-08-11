// <copyright file="CommandHandlersFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Commands
{
    using System;
    using TryCatch.Patterns.Factories;

    /// <summary>
    /// Command handlers factory.
    /// </summary>
    public class CommandHandlersFactory : AbstractFactory, ICommandHandlersFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlersFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> reference to service provider.</param>
        public CommandHandlersFactory(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        /// <inheritdoc/>
        public bool Register<TCommand, TCommandHandler>()
                where TCommand : class
                where TCommandHandler : class
        {
            var name = typeof(TCommand).Name;

            return this.RegisterType(name, typeof(TCommandHandler));
        }

        /// <inheritdoc/>
        public ICommandHandler<TCommand, TPayload> GetHandler<TCommand, TPayload>()
            where TCommand : class
        {
            var name = typeof(TCommand).Name;

            var service = this.GetType(name) as ICommandHandler<TCommand, TPayload>;

            if (service is null)
            {
                throw new CommandHandlerNotFoundException($"The command handler for {name} is not found.");
            }

            return service;
        }
    }
}
