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
            Assert.AreEqual(10, data.Length);
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

        [TestMethod]
        public void ShouldCaclculateCrc16ForSomeData1()
        {
            //Arrange
            byte[] data = { 0x12 };
            //Act
            var crc = SLIPPacket.CalculateCrc16(data);
            //Assert
            Assert.AreEqual(0xD383, crc);
        }

        [TestMethod]
        public void ShouldCaclculateCrc16ForSomeData2()
        {
            //Arrange
            byte[] data = { 0x34, 0x12, 0x56, 0x78, 0x90, 0xFF };
            //Act
            var crc = SLIPPacket.CalculateCrc16(data);
            //Assert
            Assert.AreEqual(0x42F4, crc);
        }

    }
}
