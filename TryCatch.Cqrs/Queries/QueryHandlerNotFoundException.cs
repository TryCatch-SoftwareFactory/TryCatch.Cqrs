// <copyright file="QueryHandlerNotFoundException.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Cqrs.Exceptions
{
    using System;

    /// <summary>
    /// Represents errors that occur when the query handler is not found.
    /// </summary>
    public class QueryHandlerNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandlerNotFoundException"/> class.
        /// </summary>
        public QueryHandlerNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public QueryHandlerNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The <see cref="Exception"/> that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public QueryHandlerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
