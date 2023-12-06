using System;
using System.Collections.Generic;

namespace SimpleOutcome
{
    /// <summary>
    /// Represents the result of an operation with success/failure status and optional messages.
    /// </summary>
    public class Result : IResult
    {
        private readonly List<string> _messages = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">The success status of the operation.</param>
        public Result(bool isSuccess) => IsSuccess = isSuccess;

        /// <summary>
        /// Gets a value indicating whether the operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets the read-only collection of messages associated with the result.
        /// </summary>
        public IReadOnlyCollection<string> Messages => _messages.AsReadOnly();

        /// <summary>
        /// Creates a new instance of <see cref="Result"/> representing a successful operation.
        /// </summary>
        /// <returns>A new instance of <see cref="Result"/> representing success.</returns>
        public static Result Success() => new(true);

        /// <summary>
        /// Creates a new instance of <see cref="Result"/> representing a failed operation.
        /// </summary>
        /// <returns>A new instance of <see cref="Result"/> representing failure.</returns>
        public static Result Failure() => new(false);

        /// <summary>
        /// Creates a new instance of <see cref="Result{T}"/> representing a successful operation with data.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data associated with the successful operation.</param>
        /// <returns>A new instance of <see cref="Result{T}"/> representing success with data.</returns>
        public static Result<T?> Success<T>(T? data) => new(true, data);

        /// <summary>
        /// Creates a new instance of <see cref="Result{T}"/> representing a failed operation with optional data.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The optional data associated with the failed operation.</param>
        /// <returns>A new instance of <see cref="Result{T}"/> representing failure with optional data.</returns>
        public static Result<T?> Failure<T>(T? data = default) => new(false, data);

        /// <summary>
        /// Adds a message to the result.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="args">Optional arguments to format the message.</param>
        /// <returns>The current instance of <see cref="Result"/>.</returns>
        public virtual Result WithMessage(string message, params object?[] args)
        {
            AddMessage(message, args);
            return this;
        }

        /// <summary>
        /// Adds a list of messages to the result.
        /// </summary>
        /// <param name="messages">The list of messages to add.</param>
        /// <returns>The current instance of <see cref="Result"/>.</returns>
        public virtual Result WithListOf(params string[] messages)
        {
            foreach (var msg in messages ?? Array.Empty<string>()) AddMessage(msg);
            return this;
        }

        private void AddMessage(string message, params object?[] args)
        {
            if (!string.IsNullOrWhiteSpace(message))
                _messages.Add(args?.Length > 0 ? string.Format(message, args) : message);
        }

        /// <summary>
        /// Returns a string representation of the result.
        /// </summary>
        /// <returns>A string representation of the result.</returns>
        public override string ToString()
            => _messages.Count > 0 ? string.Join(Environment.NewLine, _messages)
                                   : IsSuccess ? "Operation succeeded" : "Operation failed";
    }

    /// <summary>
    /// Represents the result of an operation with success/failure status, optional messages, and optional data.
    /// </summary>
    /// <typeparam name="T">The type of data associated with the result.</typeparam>
    public class Result<T> : Result, IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="isSuccess">The success status of the operation.</param>
        /// <param name="data">The data associated with the result.</param>
        public Result(bool isSuccess, T? data) : base(isSuccess) => Data = data ?? default;

        /// <summary>
        /// Gets the data associated with the result.
        /// </summary>
        public T? Data { get; }

        /// <summary>
        /// Adds a message to the result.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="args">Optional arguments to format the message.</param>
        /// <returns>The current instance of <see cref="Result{T}"/>.</returns>
        public override Result<T?> WithMessage(string message, params object?[] args)
        {
            base.WithMessage(message, args);
            return this;
        }

        /// <summary>
        /// Adds a list of messages to the result.
        /// </summary>
        /// <param name="messages">The list of messages to add.</param>
        /// <returns>The current instance of <see cref="Result{T}"/>.</returns>
        public override Result<T> WithListOf(params string[] messages)
        {
            base.WithListOf(messages);
            return this;
        }
    }
}
