﻿// Generated from Logger{T}.Format.tt
using System;

namespace Sweetener.Logging 
{
    /// <content>
    /// The portion of the <see cref="Logger{T}"/> class that defines the various formatting
    /// overloads for the logging methods for each <see cref="LogLevel"/>.
    /// </content>
    abstract partial class Logger<T>
    {
        #region Trace
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Trace(T context, string message)
        {
            ThrowIfDisposed();

            if (MinLevel <= LogLevel.Trace)
                Log(new LogEntry<T>(LogLevel.Trace, context, message));
        }

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Trace(T context, string format, object arg0)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Trace)
                Log(new LogEntry<T>(LogLevel.Trace, context, string.Format(FormatProvider, format, arg0)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Trace(T context, string format, object arg0, object arg1)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Trace)
                Log(new LogEntry<T>(LogLevel.Trace, context, string.Format(FormatProvider, format, arg0, arg1)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Trace(T context, string format, object arg0, object arg1, object arg2)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Trace)
                Log(new LogEntry<T>(LogLevel.Trace, context, string.Format(FormatProvider, format, arg0, arg1, arg2)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <param name="arg3">The fourth object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Trace(T context, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Trace)
                Log(new LogEntry<T>(LogLevel.Trace, context, string.Format(FormatProvider, format, arg0, arg1, arg2, arg3)));
        }

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <para>The format specification in <paramref name="format"/> is invalid.</para>
        /// <para>-or-</para>
        /// <para>
        /// The index of a format item is less than zero, or greater than or equal
        /// to the length of the <paramref name="args"/> array.
        /// </para>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Trace(T context, string format, params object[] args)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (args == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.args);

            if (MinLevel <= LogLevel.Trace)
                Log(new LogEntry<T>(LogLevel.Trace, context, string.Format(FormatProvider, format, args)));
        }
        #endregion

        #region Debug
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Debug(T context, string message)
        {
            ThrowIfDisposed();

            if (MinLevel <= LogLevel.Debug)
                Log(new LogEntry<T>(LogLevel.Debug, context, message));
        }

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Debug(T context, string format, object arg0)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Debug)
                Log(new LogEntry<T>(LogLevel.Debug, context, string.Format(FormatProvider, format, arg0)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Debug(T context, string format, object arg0, object arg1)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Debug)
                Log(new LogEntry<T>(LogLevel.Debug, context, string.Format(FormatProvider, format, arg0, arg1)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Debug(T context, string format, object arg0, object arg1, object arg2)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Debug)
                Log(new LogEntry<T>(LogLevel.Debug, context, string.Format(FormatProvider, format, arg0, arg1, arg2)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <param name="arg3">The fourth object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Debug(T context, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Debug)
                Log(new LogEntry<T>(LogLevel.Debug, context, string.Format(FormatProvider, format, arg0, arg1, arg2, arg3)));
        }

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <para>The format specification in <paramref name="format"/> is invalid.</para>
        /// <para>-or-</para>
        /// <para>
        /// The index of a format item is less than zero, or greater than or equal
        /// to the length of the <paramref name="args"/> array.
        /// </para>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Debug(T context, string format, params object[] args)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (args == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.args);

            if (MinLevel <= LogLevel.Debug)
                Log(new LogEntry<T>(LogLevel.Debug, context, string.Format(FormatProvider, format, args)));
        }
        #endregion

        #region Info
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Info(T context, string message)
        {
            ThrowIfDisposed();

            if (MinLevel <= LogLevel.Info)
                Log(new LogEntry<T>(LogLevel.Info, context, message));
        }

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Info(T context, string format, object arg0)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Info)
                Log(new LogEntry<T>(LogLevel.Info, context, string.Format(FormatProvider, format, arg0)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Info(T context, string format, object arg0, object arg1)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Info)
                Log(new LogEntry<T>(LogLevel.Info, context, string.Format(FormatProvider, format, arg0, arg1)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Info(T context, string format, object arg0, object arg1, object arg2)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Info)
                Log(new LogEntry<T>(LogLevel.Info, context, string.Format(FormatProvider, format, arg0, arg1, arg2)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <param name="arg3">The fourth object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Info(T context, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Info)
                Log(new LogEntry<T>(LogLevel.Info, context, string.Format(FormatProvider, format, arg0, arg1, arg2, arg3)));
        }

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <para>The format specification in <paramref name="format"/> is invalid.</para>
        /// <para>-or-</para>
        /// <para>
        /// The index of a format item is less than zero, or greater than or equal
        /// to the length of the <paramref name="args"/> array.
        /// </para>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Info(T context, string format, params object[] args)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (args == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.args);

            if (MinLevel <= LogLevel.Info)
                Log(new LogEntry<T>(LogLevel.Info, context, string.Format(FormatProvider, format, args)));
        }
        #endregion

        #region Warn
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Warn(T context, string message)
        {
            ThrowIfDisposed();

            if (MinLevel <= LogLevel.Warn)
                Log(new LogEntry<T>(LogLevel.Warn, context, message));
        }

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Warn(T context, string format, object arg0)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Warn)
                Log(new LogEntry<T>(LogLevel.Warn, context, string.Format(FormatProvider, format, arg0)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Warn(T context, string format, object arg0, object arg1)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Warn)
                Log(new LogEntry<T>(LogLevel.Warn, context, string.Format(FormatProvider, format, arg0, arg1)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Warn(T context, string format, object arg0, object arg1, object arg2)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Warn)
                Log(new LogEntry<T>(LogLevel.Warn, context, string.Format(FormatProvider, format, arg0, arg1, arg2)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <param name="arg3">The fourth object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Warn(T context, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Warn)
                Log(new LogEntry<T>(LogLevel.Warn, context, string.Format(FormatProvider, format, arg0, arg1, arg2, arg3)));
        }

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <para>The format specification in <paramref name="format"/> is invalid.</para>
        /// <para>-or-</para>
        /// <para>
        /// The index of a format item is less than zero, or greater than or equal
        /// to the length of the <paramref name="args"/> array.
        /// </para>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Warn(T context, string format, params object[] args)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (args == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.args);

            if (MinLevel <= LogLevel.Warn)
                Log(new LogEntry<T>(LogLevel.Warn, context, string.Format(FormatProvider, format, args)));
        }
        #endregion

        #region Error
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Error(T context, string message)
        {
            ThrowIfDisposed();

            if (MinLevel <= LogLevel.Error)
                Log(new LogEntry<T>(LogLevel.Error, context, message));
        }

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Error(T context, string format, object arg0)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Error)
                Log(new LogEntry<T>(LogLevel.Error, context, string.Format(FormatProvider, format, arg0)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Error(T context, string format, object arg0, object arg1)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Error)
                Log(new LogEntry<T>(LogLevel.Error, context, string.Format(FormatProvider, format, arg0, arg1)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Error(T context, string format, object arg0, object arg1, object arg2)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Error)
                Log(new LogEntry<T>(LogLevel.Error, context, string.Format(FormatProvider, format, arg0, arg1, arg2)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <param name="arg3">The fourth object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Error(T context, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Error)
                Log(new LogEntry<T>(LogLevel.Error, context, string.Format(FormatProvider, format, arg0, arg1, arg2, arg3)));
        }

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <para>The format specification in <paramref name="format"/> is invalid.</para>
        /// <para>-or-</para>
        /// <para>
        /// The index of a format item is less than zero, or greater than or equal
        /// to the length of the <paramref name="args"/> array.
        /// </para>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Error(T context, string format, params object[] args)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (args == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.args);

            if (MinLevel <= LogLevel.Error)
                Log(new LogEntry<T>(LogLevel.Error, context, string.Format(FormatProvider, format, args)));
        }
        #endregion

        #region Fatal
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Fatal(T context, string message)
        {
            ThrowIfDisposed();

            if (MinLevel <= LogLevel.Fatal)
                Log(new LogEntry<T>(LogLevel.Fatal, context, message));
        }

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Fatal(T context, string format, object arg0)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Fatal)
                Log(new LogEntry<T>(LogLevel.Fatal, context, string.Format(FormatProvider, format, arg0)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Fatal(T context, string format, object arg0, object arg1)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Fatal)
                Log(new LogEntry<T>(LogLevel.Fatal, context, string.Format(FormatProvider, format, arg0, arg1)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Fatal(T context, string format, object arg0, object arg1, object arg2)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Fatal)
                Log(new LogEntry<T>(LogLevel.Fatal, context, string.Format(FormatProvider, format, arg0, arg1, arg2)));
        }

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <param name="arg3">The fourth object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Fatal(T context, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (MinLevel <= LogLevel.Fatal)
                Log(new LogEntry<T>(LogLevel.Fatal, context, string.Format(FormatProvider, format, arg0, arg1, arg2, arg3)));
        }

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="MinLevel"/>
        /// is less than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="context">The domain-specific information that provides additional context about the message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An array of objects to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">
        /// <para>The format specification in <paramref name="format"/> is invalid.</para>
        /// <para>-or-</para>
        /// <para>
        /// The index of a format item is less than zero, or greater than or equal
        /// to the length of the <paramref name="args"/> array.
        /// </para>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public void Fatal(T context, string format, params object[] args)
        {
            ThrowIfDisposed();

            if (format == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.format);

            if (args == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.args);

            if (MinLevel <= LogLevel.Fatal)
                Log(new LogEntry<T>(LogLevel.Fatal, context, string.Format(FormatProvider, format, args)));
        }
        #endregion

    }
}