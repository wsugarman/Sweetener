﻿// Generated from ILogger{T}.tt
using System;

namespace Sweetener.Logging
{
    /// <summary>
    /// Represents a client that can log values with a given <see cref="LogLevel"/>
    /// based on their purpose or severity.
    /// </summary>
    /// <typeparam name="T">The type of values to be logged.</typeparam>
    public interface ILogger<T> : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether logging is synchronized (thread safe).
        /// </summary>
        /// <returns><see langword="true"/> if logging is synchronized (thread safe); otherwise, <see langword="false"/>.</returns>
        bool IsSynchronized { get; }

        /// <summary>
        /// Gets the minimum level of log requests that will be fulfilled.
        /// </summary>
        /// <returns>The minimum <see cref="LogLevel"/> that will be fulfilled.</returns>
        LogLevel MinLevel { get; }

        /// <summary>
        /// Gets an object that can be used to synchronize logging.
        /// </summary>
        /// <returns>An object that can be used to synchronize logging.</returns>
        object SyncRoot { get; }

        /// <summary>
        /// Requests that the specified value be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="value">The value requested for logging.</param>
        /// <exception cref="ArgumentNullException">
        /// <typeparamref name="T"/> is a reference type and <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        void Trace(T value);

        /// <summary>
        /// Requests that the specified value be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="value">The value requested for logging.</param>
        /// <exception cref="ArgumentNullException">
        /// <typeparamref name="T"/> is a reference type and <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        void Debug(T value);

        /// <summary>
        /// Requests that the specified value be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="value">The value requested for logging.</param>
        /// <exception cref="ArgumentNullException">
        /// <typeparamref name="T"/> is a reference type and <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        void Info(T value);

        /// <summary>
        /// Requests that the specified value be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="value">The value requested for logging.</param>
        /// <exception cref="ArgumentNullException">
        /// <typeparamref name="T"/> is a reference type and <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        void Warn(T value);

        /// <summary>
        /// Requests that the specified value be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="value">The value requested for logging.</param>
        /// <exception cref="ArgumentNullException">
        /// <typeparamref name="T"/> is a reference type and <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        void Error(T value);

        /// <summary>
        /// Requests that the specified value be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="value">The value requested for logging.</param>
        /// <exception cref="ArgumentNullException">
        /// <typeparamref name="T"/> is a reference type and <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        void Fatal(T value);
    }
}
