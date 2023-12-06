using System.Collections.Generic;

namespace SimpleOutcome
{
    /// <summary>
    /// Represents the result of an operation, providing information about success or failure
    /// and an optional collection of messages associated with the result.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets a value indicating whether the operation is successful.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Gets an immutable collection of messages associated with the result.
        /// </summary>
        IReadOnlyCollection<string> Messages { get; }
    }

    /// <summary>
    /// Represents the result of an operation with associated data of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of data associated with the result.</typeparam>
    public interface IResult<T> : IResult
    {
        /// <summary>
        /// Gets the data associated with the result.
        /// </summary>
        T? Data { get; }
    }
}
