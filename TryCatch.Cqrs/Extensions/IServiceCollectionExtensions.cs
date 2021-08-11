// <copyright file="IServiceCollectionExtensions.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using TryCatch.Cqrs.Commands;
    using TryCatch.Cqrs.Queries;

    /// <summary>
    /// IServiceCollection extensions to initilalize common components for CQRS.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add basic CQRS Components.
        /// </summary>
        /// <param name="services">A <see cref="IServiceCollection"/> reference to the service collection.</param>
        /// <returns>A <see cref="IServiceCollection"/> reference to the current service collection.</returns>
        public static IServiceCollection AddCqrsLightFramework(this IServiceCollection services) =>
            services
                .AddScoped<ICommandHandlersFactory, CommandHandlersFactory>()
                .AddScoped<IQueryHandlersFactory, QueryHandlersFactory>();
    }
}
