using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceFlux.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PriceFlux.Helpers.Tests
{
    [TestClass()]
    public class MD5HashTests
    {
        [TestMethod()]
        public void GetMd5HashTest()
        {
            MD5 md5Hash = MD5.Create();

            Assert.AreEqual(MD5Hash.GetMd5Hash(md5Hash, "a"), "0cc175b9c0f1b6a831c399e269772661");
            Assert.IsTrue(MD5Hash.VerifyMd5Hash(md5Hash, "a", "0cc175b9c0f1b6a831c399e269772661"));
            
            md5Hash.Dispose();

        }
    }
}