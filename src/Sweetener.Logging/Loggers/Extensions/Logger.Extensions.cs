﻿// Generated from Logger.Extensions.tt
using System;

namespace Sweetener.Logging.Extensions
{
    /// <summary>
    /// Provides a set of supplemental methods for <see cref="Logger"/> and <see cref="Logger{T}"/>.
    /// </summary>
    public static partial class LoggerExtensions
    {
        #region Trace
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Trace(this Logger logger, string message)
            => logger.Log(LogLevel.Trace, message);

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Trace(this Logger logger, string format, object arg0)
            => logger.Log(LogLevel.Trace, format, arg0);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Trace(this Logger logger, string format, object arg0, object arg1)
            => logger.Log(LogLevel.Trace, format, arg0, arg1);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Trace(this Logger logger, string format, object arg0, object arg1, object arg2)
            => logger.Log(LogLevel.Trace, format, arg0, arg1, arg2);

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Trace"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
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
        public static void Trace(this Logger logger, string format, params object[] args)
            => logger.Log(LogLevel.Trace, format, args);
        #endregion

        #region Debug
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Debug(this Logger logger, string message)
            => logger.Log(LogLevel.Debug, message);

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Debug(this Logger logger, string format, object arg0)
            => logger.Log(LogLevel.Debug, format, arg0);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Debug(this Logger logger, string format, object arg0, object arg1)
            => logger.Log(LogLevel.Debug, format, arg0, arg1);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Debug(this Logger logger, string format, object arg0, object arg1, object arg2)
            => logger.Log(LogLevel.Debug, format, arg0, arg1, arg2);

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Debug"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
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
        public static void Debug(this Logger logger, string format, params object[] args)
            => logger.Log(LogLevel.Debug, format, args);
        #endregion

        #region Info
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Info(this Logger logger, string message)
            => logger.Log(LogLevel.Info, message);

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Info(this Logger logger, string format, object arg0)
            => logger.Log(LogLevel.Info, format, arg0);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Info(this Logger logger, string format, object arg0, object arg1)
            => logger.Log(LogLevel.Info, format, arg0, arg1);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Info(this Logger logger, string format, object arg0, object arg1, object arg2)
            => logger.Log(LogLevel.Info, format, arg0, arg1, arg2);

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Info"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
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
        public static void Info(this Logger logger, string format, params object[] args)
            => logger.Log(LogLevel.Info, format, args);
        #endregion

        #region Warn
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Warn(this Logger logger, string message)
            => logger.Log(LogLevel.Warn, message);

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Warn(this Logger logger, string format, object arg0)
            => logger.Log(LogLevel.Warn, format, arg0);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Warn(this Logger logger, string format, object arg0, object arg1)
            => logger.Log(LogLevel.Warn, format, arg0, arg1);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Warn(this Logger logger, string format, object arg0, object arg1, object arg2)
            => logger.Log(LogLevel.Warn, format, arg0, arg1, arg2);

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Warn"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Warn"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
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
        public static void Warn(this Logger logger, string format, params object[] args)
            => logger.Log(LogLevel.Warn, format, args);
        #endregion

        #region Error
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Error(this Logger logger, string message)
            => logger.Log(LogLevel.Error, message);

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Error(this Logger logger, string format, object arg0)
            => logger.Log(LogLevel.Error, format, arg0);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Error(this Logger logger, string format, object arg0, object arg1)
            => logger.Log(LogLevel.Error, format, arg0, arg1);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Error(this Logger logger, string format, object arg0, object arg1, object arg2)
            => logger.Log(LogLevel.Error, format, arg0, arg1, arg2);

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Error"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
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
        public static void Error(this Logger logger, string format, params object[] args)
            => logger.Log(LogLevel.Error, format, args);
        #endregion

        #region Fatal
        /// <summary>
        /// Requests that the specified message be logged with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="message">The message requested for logging.</param>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Fatal(this Logger logger, string message)
            => logger.Log(LogLevel.Fatal, message);

        /// <summary>
        /// Requests that the text representation of the specified object, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Fatal(this Logger logger, string format, object arg0)
            => logger.Log(LogLevel.Fatal, format, arg0);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Fatal(this Logger logger, string format, object arg0, object arg1)
            => logger.Log(LogLevel.Fatal, format, arg0, arg1);

        /// <summary>
        /// Requests that the text representation of the specified objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">The second object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">The third object to write using <paramref name="format"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException">The format specification in <paramref name="format"/> is invalid.</exception>
        /// <exception cref="ObjectDisposedException">The logger is disposed.</exception>
        public static void Fatal(this Logger logger, string format, object arg0, object arg1, object arg2)
            => logger.Log(LogLevel.Fatal, format, arg0, arg1, arg2);

        /// <summary>
        /// Requests that the text representation of the specified array of objects, using the
        /// specified format information, be logged with the level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The log request will only be fulfilled if the <see cref="Logger.MinLevel"/> is less
        /// than or equal to <see cref="LogLevel.Fatal"/>.
        /// </remarks>
        /// <param name="logger">The <see cref="Logger"/> that will process the request.</param>
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
        public static void Fatal(this Logger logger, string format, params object[] args)
            => logger.Log(LogLevel.Fatal, format, args);
        #endregion

    }
}