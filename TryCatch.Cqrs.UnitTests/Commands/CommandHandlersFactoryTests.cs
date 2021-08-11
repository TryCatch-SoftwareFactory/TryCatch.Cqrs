// <copyright file="CommandHandlersFactoryTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Commands
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.Cqrs.Commands;
    using TryCatch.Cqrs.UnitTests.Mocks;
    using TryCatch.Patterns.Factories;
    using Xunit;

    public class CommandHandlersFactoryTests
    {
        private readonly IServiceProvider serviceProvider;

        private readonly CommandHandlersFactory sut;

        public CommandHandlersFactoryTests()
        {
            this.serviceProvider = Substitute.For<IServiceProvider>();

            this.sut = new CommandHandlersFactory(this.serviceProvider);
        }

        [Fact]
        public void Register_With_Valid_Command_And_Handler()
        {
            // Act
            var actual = this.sut.Register<StartCarCommand, IStartCarCommandHandler>();

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void Register_With_Exists_Command_In_Factory()
        {
            // Arrange
            this.sut.Register<StartCarCommand, IStartCarCommandHandler>();

            // Act
            Action act = () => this.sut.Register<StartCarCommand, IStartCarCommandHandler>();

            // Asserts
            act.Should().Throw<DuplicateComponentException>();
        }

        [Fact]
        public void GetHandler_With_A_Command_Not_Registered_Previously()
        {
            // Act
            Action act = () => this.sut.GetHandler<StartCarCommand, bool>();

            // Asserts
            act.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetHandler_with_a_invalid_command_handler()
        {
            // Arrange
            this.sut.Register<StartCarCommand, Car>();
            this.serviceProvider.GetService(typeof(Car)).Returns(new Car());

            // Act
            Action act = () => this.sut.GetHandler<StartCarCommand, bool>();

            // Asserts
            act.Should().Throw<CommandHandlerNotFoundException>();
        }

        [Fact]
        public void GetHandler_With_A_CommandHandler_Without_Component()
        {
            // Arrange
            this.sut.Register<StartCarCommand, IStartCarCommandHandler>();

            // Act
            Action act = () => this.sut.GetHandler<StartCarCommand, bool>();

            // Asserts
            act.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetHandler_Ok()
        {
            // Arrange
            this.sut.Register<StartCarCommand, IStartCarCommandHandler>();
            this.serviceProvider.GetService(typeof(IStartCarCommandHandler)).Returns(new StartCarCommandHandler());

            // Act
            var actual = this.sut.GetHandler<StartCarCommand, bool>();

            // Asserts
            actual.Should().NotBeNull();
            actual.Should().BeOfType<StartCarCommandHandler>();
        }
    }
}
