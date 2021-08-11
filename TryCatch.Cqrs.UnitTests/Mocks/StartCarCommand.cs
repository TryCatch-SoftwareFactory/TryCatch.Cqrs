// <copyright file="StartCarCommand.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    public class StartCarCommand
    {
        public StartCarCommand(string reference)
        {
            this.Reference = reference;
        }

        public string Reference { get; }
    }
}
