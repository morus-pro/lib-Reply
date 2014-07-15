﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mErrorWrapper.UnitTesting
{
    [TestClass]
    public class TestandoBoolean
    {
        [TestMethod]
        public void RetornaValorComErro()
        {
            var valor = false;
            Enum erro = MyTestErrorEnum.FUUUUU;

            var result = Error.With(erro, valor);

            Assert.AreEqual(valor, result.Value);
            Assert.AreEqual(erro, result.ErrorCode);

            Assert.AreEqual(erro != null,
                result.HasError);

            Assert.AreEqual(erro == null,
                string.IsNullOrEmpty(result.ErrorMessage));
        }


    }
}
