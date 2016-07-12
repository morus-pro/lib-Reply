﻿
/* MlIB.Reply
 * https://github.com/LeandroMBarreto
 * http://www.codeproject.com/Members/LeandroMBarreto
 * 
 The MIT License (MIT)

Copyright (c) 2014-2016 LeandroMBarreto

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;

namespace MlIB
{
    /// <summary>
    /// Use this class to return valuable error information from methods instead of ambiguous null, false or default values.
    /// </summary>
    /// <typeparam name="TReturn">The type of the returned value</typeparam>
    public class Reply<TReturn>
    {
        public TReturn Value { get; protected set; }
        public Enum ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception ExceptionThrown { get; protected set; }

        public bool HasError { get { return HasErrorMessage || HasErrorCode || HasException; } }
        public bool HasErrorCode { get { return this.ErrorCode != null; } }
        public bool HasException { get { return this.ExceptionThrown != null; } }
        public bool HasErrorMessage { get { return !string.IsNullOrEmpty(this.ErrorMessage); } }

        public Reply(TReturn value, string errorMessage = "")
        {
            this.Value = value;
            this.ErrorCode = null;
            this.ErrorMessage = errorMessage;
            this.ExceptionThrown = null;
        }

        public Reply(TReturn value, Enum errorCode, string errorMessage = "")
        {
            this.Value = value;
            this.ErrorCode = errorCode;
            this.ExceptionThrown = null;

            if (HasError && string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = Enum.GetName(errorCode.GetType(), errorCode);
            else this.ErrorMessage = errorMessage;
        }

        public Reply(TReturn value, Exception exception)
        {
            this.Value = value;
            this.ErrorCode = null;
            this.ErrorMessage = exception.Message;
            this.ExceptionThrown = exception;
        }

    }
}