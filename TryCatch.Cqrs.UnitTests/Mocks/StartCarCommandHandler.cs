// <copyright file="StartCarCommandHandler.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Patterns.Results;

    public class StartCarCommandHandler : IStartCarCommandHandler
    {
        private readonly ResultBuilder<bool> builder;

        public StartCarCommandHandler()
        {
            this.builder = new ResultBuilder<bool>();
        }

        public async Task<Result<bool>> Execute(StartCarCommand command, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _ = command ?? throw new ArgumentNullException(nameof(command));

            var car = new Car(command.Reference);

            var isStartedOk = await car.Start(cancellationToken).ConfigureAwait(false);

            return this.builder
                .Build()
                .WithPayload(isStartedOk)
                .Create();
        }
    }
}
