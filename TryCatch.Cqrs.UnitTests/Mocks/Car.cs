// <copyright file="Car.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    using System.Threading;
    using System.Threading.Tasks;

    public class Car
    {
        private bool on;

        public Car()
        {
        }

        public Car(string reference)
        {
            this.on = false;

            this.Reference = reference;
        }

        public string Reference { get; }

        public bool IsOn => this.on;

        public async Task<bool> Start(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await Task.CompletedTask.ConfigureAwait(false);

            this.on = true;

            return this.on;
        }

        public async Task<bool> Stop(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await Task.CompletedTask.ConfigureAwait(false);

            this.on = false;

            return this.on;
        }
    }
}
