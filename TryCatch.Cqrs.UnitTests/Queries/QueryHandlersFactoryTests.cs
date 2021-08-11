// <copyright file="QueryHandlersFactoryTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Queries
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.Cqrs.Exceptions;
    using TryCatch.Cqrs.Queries;
    using TryCatch.Cqrs.UnitTests.Mocks;
    using TryCatch.Patterns.Factories;
    using TryCatch.Patterns.Results;
    using Xunit;

    public class QueryHandlersFactoryTests
    {
        private readonly IServiceProvider serviceProvider;

        private readonly QueryHandlersFactory sut;

        public QueryHandlersFactoryTests()
        {
            this.serviceProvider = Substitute.For<IServiceProvider>();

            this.sut = new QueryHandlersFactory(this.serviceProvider);
        }

        [Fact]
        public void Register_With_Valid_QueryObject_And_Handler()
        {
            // Act
            var actual = this.sut.Register<ListCarsQueryObject, IListCarsQueryHandler>();

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void Register_With_Exists_QueryObject_In_Factory()
        {
            // Arrange
            this.sut.Register<ListCarsQueryObject, IListCarsQueryHandler>();

            // Act
            Action act = () => this.sut.Register<ListCarsQueryObject, IListCarsQueryHandler>();

            // Asserts
            act.Should().Throw<DuplicateComponentException>();
        }

        [Fact]
        public void GetHandler_With_A_QueryObject_Not_Registered_Previously()
        {
            // Act
            Action act = () => this.sut.GetHandler<ListCarsQueryObject, PageResult<Car>>();

            // Asserts
            act.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetHandler_With_A_QueryHandler_Without_Component()
        {
            // Arrange
            this.sut.Register<ListCarsQueryObject, IListCarsQueryHandler>();

            // Act
            Action act = () => this.sut.GetHandler<ListCarsQueryObject, PageResult<Car>>();

            // Asserts
            act.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetHandler_Ok()
        {
            // Arrange
            this.sut.Register<ListCarsQueryObject, IListCarsQueryHandler>();
            this.serviceProvider.GetService(typeof(IListCarsQueryHandler)).Returns(new ListCarsQueryHandler(new PageResultBuilder<Car>()));

            // Act
            var actual = this.sut.GetHandler<ListCarsQueryObject, PageResult<Car>>();

            // Asserts
            actual.Should().NotBeNull();
            actual.Should().BeOfType<ListCarsQueryHandler>();
        }

        [Fact]
        public void GetHandler_with_a_invalid_command_handler()
        {
            // Arrange
            this.sut.Register<ListCarsQueryObject, Car>();
            this.serviceProvider.GetService(typeof(Car)).Returns(new Car());

            // Act
            Action act = () => this.sut.GetHandler<ListCarsQueryObject, PageResult<Car>>();

            // Asserts
            act.Should().Throw<QueryHandlerNotFoundException>();
        }
    }
}
