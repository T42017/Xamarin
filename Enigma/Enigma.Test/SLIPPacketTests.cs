using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enigma.Model;

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

    }
}
