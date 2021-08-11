// <copyright file="CommandDispatcherTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Commands
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.Cqrs.Commands;
    using TryCatch.Cqrs.UnitTests.Mocks;
    using Xunit;

    public class CommandDispatcherTests
    {
        private readonly ICommandHandlersFactory factory;

        private readonly CommandDispatcher sut;

        public CommandDispatcherTests()
        {
            this.factory = Substitute.For<ICommandHandlersFactory>();

            this.sut = new CarsCommandDispatcher(this.factory);
        }

        [Fact]
        public async Task Invoke_Run_Without_Command()
        {
            // Arrange
            StartCarCommand command = null;

            // Act
            Func<Task> act = async () => await this.sut.Run<StartCarCommand, bool>(command).ConfigureAwait(false);

            // Asserts
            await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
        }

        [Fact]
        public async Task Invoke_Run_Without_Errors()
        {
            // Arrange
            var command = new StartCarCommand("SOME-REFERENCE");
            var commandHandler = new StartCarCommandHandler();
            this.factory.GetHandler<StartCarCommand, bool>().Returns(commandHandler);

            // Act
            var actual = await this.sut.Run<StartCarCommand, bool>(command).ConfigureAwait(false);

            // Asserts
            actual.Should().NotBeNull();
            actual.IsSucceeded.Should().BeTrue();
            actual.Payload.Should().BeTrue();
        }
    }
}
