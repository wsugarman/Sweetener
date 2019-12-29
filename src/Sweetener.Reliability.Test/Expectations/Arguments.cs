﻿// Generated from Arguments.tt
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweetener.Reliability.Test
{
    internal static class Arguments
    {
        public static void Validate(CancellationToken token)
        {
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg)
        {
            Assert.AreEqual(42, arg);
        }

        public static void Validate(int arg, CancellationToken token)
        {
            Validate(arg);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2)
        {
            Assert.AreEqual(42   , arg1);
            Assert.AreEqual("foo", arg2);
        }

        public static void Validate(int arg1, string arg2, CancellationToken token)
        {
            Validate(arg1, arg2);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3)
        {
            Assert.AreEqual(42   , arg1);
            Assert.AreEqual("foo", arg2);
            Assert.AreEqual(3.14D, arg3);
        }

        public static void Validate(int arg1, string arg2, double arg3, CancellationToken token)
        {
            Validate(arg1, arg2, arg3);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4)
        {
            Assert.AreEqual(42   , arg1);
            Assert.AreEqual("foo", arg2);
            Assert.AreEqual(3.14D, arg3);
            Assert.AreEqual(1000L, arg4);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5)
        {
            Assert.AreEqual(42       , arg1);
            Assert.AreEqual("foo"    , arg2);
            Assert.AreEqual(3.14D    , arg3);
            Assert.AreEqual(1000L    , arg4);
            Assert.AreEqual((ushort)1, arg5);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6)
        {
            Assert.AreEqual(42       , arg1);
            Assert.AreEqual("foo"    , arg2);
            Assert.AreEqual(3.14D    , arg3);
            Assert.AreEqual(1000L    , arg4);
            Assert.AreEqual((ushort)1, arg5);
            Assert.AreEqual((byte)255, arg6);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7)
        {
            Assert.AreEqual(42                   , arg1);
            Assert.AreEqual("foo"                , arg2);
            Assert.AreEqual(3.14D                , arg3);
            Assert.AreEqual(1000L                , arg4);
            Assert.AreEqual((ushort)1            , arg5);
            Assert.AreEqual((byte)255            , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30), arg7);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8)
        {
            Assert.AreEqual(42                   , arg1);
            Assert.AreEqual("foo"                , arg2);
            Assert.AreEqual(3.14D                , arg3);
            Assert.AreEqual(1000L                , arg4);
            Assert.AreEqual((ushort)1            , arg5);
            Assert.AreEqual((byte)255            , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30), arg7);
            Assert.AreEqual(112U                 , arg8);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9)
        {
            Assert.AreEqual(42                      , arg1);
            Assert.AreEqual("foo"                   , arg2);
            Assert.AreEqual(3.14D                   , arg3);
            Assert.AreEqual(1000L                   , arg4);
            Assert.AreEqual((ushort)1               , arg5);
            Assert.AreEqual((byte)255               , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)   , arg7);
            Assert.AreEqual(112U                    , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL), arg9);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10)
        {
            Assert.AreEqual(42                        , arg1);
            Assert.AreEqual("foo"                     , arg2);
            Assert.AreEqual(3.14D                     , arg3);
            Assert.AreEqual(1000L                     , arg4);
            Assert.AreEqual((ushort)1                 , arg5);
            Assert.AreEqual((byte)255                 , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)     , arg7);
            Assert.AreEqual(112U                      , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)  , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06), arg10);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11)
        {
            Assert.AreEqual(42                        , arg1);
            Assert.AreEqual("foo"                     , arg2);
            Assert.AreEqual(3.14D                     , arg3);
            Assert.AreEqual(1000L                     , arg4);
            Assert.AreEqual((ushort)1                 , arg5);
            Assert.AreEqual((byte)255                 , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)     , arg7);
            Assert.AreEqual(112U                      , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)  , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06), arg10);
            Assert.AreEqual(321UL                     , arg11);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12)
        {
            Assert.AreEqual(42                        , arg1);
            Assert.AreEqual("foo"                     , arg2);
            Assert.AreEqual(3.14D                     , arg3);
            Assert.AreEqual(1000L                     , arg4);
            Assert.AreEqual((ushort)1                 , arg5);
            Assert.AreEqual((byte)255                 , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)     , arg7);
            Assert.AreEqual(112U                      , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)  , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06), arg10);
            Assert.AreEqual(321UL                     , arg11);
            Assert.AreEqual((sbyte)-7                 , arg12);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13)
        {
            Assert.AreEqual(42                        , arg1);
            Assert.AreEqual("foo"                     , arg2);
            Assert.AreEqual(3.14D                     , arg3);
            Assert.AreEqual(1000L                     , arg4);
            Assert.AreEqual((ushort)1                 , arg5);
            Assert.AreEqual((byte)255                 , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)     , arg7);
            Assert.AreEqual(112U                      , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)  , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06), arg10);
            Assert.AreEqual(321UL                     , arg11);
            Assert.AreEqual((sbyte)-7                 , arg12);
            Assert.AreEqual(-24.68M                   , arg13);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, char arg14)
        {
            Assert.AreEqual(42                        , arg1);
            Assert.AreEqual("foo"                     , arg2);
            Assert.AreEqual(3.14D                     , arg3);
            Assert.AreEqual(1000L                     , arg4);
            Assert.AreEqual((ushort)1                 , arg5);
            Assert.AreEqual((byte)255                 , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)     , arg7);
            Assert.AreEqual(112U                      , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)  , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06), arg10);
            Assert.AreEqual(321UL                     , arg11);
            Assert.AreEqual((sbyte)-7                 , arg12);
            Assert.AreEqual(-24.68M                   , arg13);
            Assert.AreEqual('!'                       , arg14);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, char arg14, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, char arg14, float arg15)
        {
            Assert.AreEqual(42                        , arg1);
            Assert.AreEqual("foo"                     , arg2);
            Assert.AreEqual(3.14D                     , arg3);
            Assert.AreEqual(1000L                     , arg4);
            Assert.AreEqual((ushort)1                 , arg5);
            Assert.AreEqual((byte)255                 , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)     , arg7);
            Assert.AreEqual(112U                      , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)  , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06), arg10);
            Assert.AreEqual(321UL                     , arg11);
            Assert.AreEqual((sbyte)-7                 , arg12);
            Assert.AreEqual(-24.68M                   , arg13);
            Assert.AreEqual('!'                       , arg14);
            Assert.AreEqual(0.1F                      , arg15);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, char arg14, float arg15, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            //Assert.AreNotEqual(default, token);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, char arg14, float arg15, Guid arg16)
        {
            Assert.AreEqual(42                                                , arg1);
            Assert.AreEqual("foo"                                             , arg2);
            Assert.AreEqual(3.14D                                             , arg3);
            Assert.AreEqual(1000L                                             , arg4);
            Assert.AreEqual((ushort)1                                         , arg5);
            Assert.AreEqual((byte)255                                         , arg6);
            Assert.AreEqual(TimeSpan.FromDays(30)                             , arg7);
            Assert.AreEqual(112U                                              , arg8);
            Assert.AreEqual(Tuple.Create(true, 64UL)                          , arg9);
            Assert.AreEqual(new DateTime(2019, 10, 06)                        , arg10);
            Assert.AreEqual(321UL                                             , arg11);
            Assert.AreEqual((sbyte)-7                                         , arg12);
            Assert.AreEqual(-24.68M                                           , arg13);
            Assert.AreEqual('!'                                               , arg14);
            Assert.AreEqual(0.1F                                              , arg15);
            Assert.AreEqual(Guid.Parse("53710ff0-eaa3-4fac-a068-e5be641d446b"), arg16);
        }

        public static void Validate(int arg1, string arg2, double arg3, long arg4, ushort arg5, byte arg6, TimeSpan arg7, uint arg8, Tuple<bool, ulong> arg9, DateTime arg10, ulong arg11, sbyte arg12, decimal arg13, char arg14, float arg15, Guid arg16, CancellationToken token)
        {
            Validate(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            //Assert.AreNotEqual(default, token);
        }

    }
}
