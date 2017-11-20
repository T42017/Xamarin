using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enigma.Model;
using Enigma.Extensions;

namespace Enigma.Test
{
    [TestClass]
    public class SLIPPacketTests
    {
        [TestMethod]
        public void ShouldAddENDbyteToStream()
        {
            //Arrange
            Parameter p = new Parameter()
            {
                Id = 1,
                Value = 10
            };
            //Act
            var data = SLIPPacket.ToByteArray(p);
            //Assert
            Assert.AreEqual(SLIPPacket.END, data.Last());
        }

        [TestMethod]
        public void ShouldAddSLIPOverheadBytes()
        {
            //Arrange
            Parameter p = new Parameter()
            {
                Id = 1,
                Value = 10
            };
            //Act
            var data = SLIPPacket.ToByteArray(p);
            //Assert
            Assert.AreEqual(9, data.Length);
        }

        [TestMethod]
        public void ShouldReplaceENDWithESC_ESC_END()
        {
            //Arrange
            Parameter p = new Parameter()
            {
                Id = 1,
                Value = SLIPPacket.END
            };
            //Act
            var data = SLIPPacket.ToByteArray(p);
            //Assert
            byte[] pattern = {SLIPPacket.ESC, SLIPPacket.ESC_END};
            Assert.IsTrue(data.IndexOfPattern(pattern) > 0);
        }

        [TestMethod]
        public void ShouldReplaceESCWithESC_ESC_ESC()
        {
            //Arrange
            Parameter p = new Parameter()
            {
                Id = 1,
                Value = SLIPPacket.ESC
            };
            //Act
            var data = SLIPPacket.ToByteArray(p);
            //Assert
            byte[] pattern = { SLIPPacket.ESC, SLIPPacket.ESC_ESC };
            Assert.IsTrue(data.IndexOfPattern(pattern) > 0);
        }

    }
}
