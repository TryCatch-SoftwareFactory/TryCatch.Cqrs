// <copyright file="QueryDispatcherTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Queries
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.Cqrs.Queries;
    using TryCatch.Cqrs.UnitTests.Mocks;
    using TryCatch.Patterns.Results;
    using Xunit;

    public class QueryDispatcherTests
    {
        private readonly IQueryHandlersFactory factory;

        private readonly QueryDispatcher sut;

        public QueryDispatcherTests()
        {
            this.factory = Substitute.For<IQueryHandlersFactory>();

            this.sut = new CarsQueryDispatcher(this.factory);
        }

        [Fact]
        public async Task Invoke_Run_Without_Query()
        {
            // Arrange
            ListCarsQueryObject queryObject = null;

            // Act
            Func<Task> act = async () => await this.sut.Run<ListCarsQueryObject, PageResult<Car>>(queryObject).ConfigureAwait(false);

            // Asserts
            await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
        }

        [Fact]
        public async Task Invoke_Run_without_errors()
        {
            // Arrange
            var queryObject = new ListCarsQueryObject(isOn: true);
            var queryHandler = new ListCarsQueryHandler(new PageResultBuilder<Car>());

            this.factory
                .GetHandler<ListCarsQueryObject, PageResult<Car>>()
                .Returns(queryHandler);

            // Act
            var actual = await this.sut.Run<ListCarsQueryObject, PageResult<Car>>(queryObject).ConfigureAwait(false);

            // Asserts
            actual.Should().NotBeNull();
            actual.Count.Should().Be(20);
            actual.Matched.Should().Be(20);
            actual.Offset.Should().Be(1);
            actual.Limit.Should().Be(1000);
            actual.Items.Should().NotBeEmpty().And.HaveCount(20);
        }
    }
}
