// <copyright file="ListCarsQueryObject.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.UnitTests.Mocks
{
    public class ListCarsQueryObject
    {
        private readonly bool isOn;

        private readonly int limit;

        private readonly int offset;

        public ListCarsQueryObject(bool isOn, int offset = 1, int limit = 1000)
        {
            this.isOn = isOn;
            this.offset = offset;
            this.limit = limit;
        }

        public bool IsOn => this.isOn;

        public int Offset => this.offset;

        public int Limit => this.limit;
    }
}
