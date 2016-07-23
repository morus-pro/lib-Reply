﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class IReplyFast_Throw
    {

        // IReplyFast.Throw(string msgPrefix = null)

        //I:having no error
        //O:dont throw, do nothing
        //O:keeps showing no error
        [TestMethod]
        public void IReplyFast_Throw_havingNoError()
        {
            var result = M.Reply.NoError(5);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNull(assert, "WHY THROWING??");  //O:dont throw, do nothing
            Assert.IsFalse(result.HasError);  //O:keeps showing no error
        }

        //I:having null exception
        //O:throw warning exception 
        //O:generic exception message
        [TestMethod]
        public void IReplyFast_Throw_havingNullException()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains("A DEFAULT ERROR WAS THROWN"), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having null exception, having valid message
        //O:throw warning exception 
        //O:error message in exception message
        [TestMethod]
        public void IReplyFast_Throw_havingNullException_havingValidMessage()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having null exception, having value exception
        //O:throw warning exception 
        //O:error message in exception message
        [TestMethod]
        public void IReplyFast_Throw_havingNullException_havingEmptyMessage_whenValueException()
        {
            Exception nullEx = null;
            var result = M.Reply.Error(nullEx, "", Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual("[--]", assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having valid exception
        //O:throw expected exception 
        [TestMethod]
        public void IReplyFast_Throw_havingValidException()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(InvalidOperationException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having no error, msgPrefix empty
        //O:dont throw, do nothing
        //O:keeps showing no error
        [TestMethod]
        public void IReplyFast_Throw_msgPrefix_empty_havingNoError()
        {
            var result = M.Reply.NoError(5);

            Exception assert = null;
            try
            {
                result.Throw("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNull(assert, "WHY THROWING??");  //O:dont throw, do nothing
            Assert.IsFalse(result.HasError);  //O:keeps showing no error
        }

        //I:having null exception, msgPrefix empty
        //O:throw warning exception 
        //O:empty message
        [TestMethod]
        public void IReplyFast_Throw_msgPrefix_empty_havingNullException()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx);

            Exception assert = null;
            try
            {
                result.Throw("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual("[--]", assert.Message, "WHY NOT EMPTY MESSAGE??");
        }

        //I:having null exception, having valid message, msgPrefix empty
        //O:throw warning exception 
        //O:error message in exception message
        [TestMethod]
        public void IReplyFast_Throw_msgPrefix_empty_havingNullException_havingValidMessage()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.Throw("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having null exception, having value exception, msgPrefix empty
        //O:throw warning exception 
        //O:error message in exception message
        [TestMethod]
        public void IReplyFast_Throw_msgPrefix_empty_havingNullException_havingEmptyMessage_whenValueException()
        {
            Exception nullEx = null;
            var result = M.Reply.Error(nullEx, "", Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.Throw("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual("[--]", assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having valid exception, msgPrefix empty
        //O:throw expected exception 
        [TestMethod]
        public void IReplyFast_Throw_msgPrefix_empty_havingValidException()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.Throw("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(InvalidOperationException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

    }
}
