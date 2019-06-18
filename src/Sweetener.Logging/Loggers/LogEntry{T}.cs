﻿using System;
using System.Threading;

namespace Sweetener.Logging
{
    /// <summary>
    /// An entry to be written to the log.
    /// </summary>
    /// <typeparam name="T">The type of the entry's message.</typeparam>
    public readonly struct LogEntry<T>
    {
        /// <summary>
        /// The <see cref="LogLevel"/> associated with the <see cref="Message"/>.
        /// </summary>
        public readonly LogLevel Level;

        /// <summary>
        /// The value to be logged.
        /// </summary>
        public readonly T Message;

        /// <summary>
        /// The timestamp when the log request was made.
        /// </summary>
        /// <remarks>
        /// The <see cref="DateTime.Kind"/> is <see cref="DateTimeKind.Utc"/>.
        /// </remarks>
        public readonly DateTime Timestamp;

        /// <summary>
        /// The <see cref="Thread.ManagedThreadId"/> of the thread that created the log entry.
        /// </summary>
        public readonly int ThreadId;

        /// <summary>
        /// The <see cref="Thread.Name"/> of the thread that created the log entry.
        /// </summary>
        public readonly string ThreadName;

        // TODO: Should process information be here? Thread information is here because
        //       the thread that requests a log be written and the the thread that performs
        //       the write operation may be different. Though, users could perhaps marshal
        //       entries across the app domain into another process as well.

        internal LogEntry(LogLevel level, T message)
            : this(DateTime.UtcNow, level, message)
        { }

        internal LogEntry(DateTime timestamp, LogLevel level, T message)
        {
            // ctor is internal and we'll be well-behaved, so checks aren't necessary
            Level      = level;
            Message    = message;
            Timestamp  = timestamp;

            // Retrieving the current thread per entry is actually faster than attempting to
            // cache the value in a [ThreadStatic] variable and checking for initialization
            Thread currentThread = Thread.CurrentThread;
            ThreadId   = currentThread.ManagedThreadId;
            ThreadName = currentThread.Name;
        }
    }
}