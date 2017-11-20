using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    public class Parameter
    {
        public UInt16 Id { get; set; }
        public UInt32 Value { get; set; }

        public byte[] ToByteArray()
        {
            var data = new byte[6];
            data[0] = (byte)(Id >> 8);
            data[1] = (byte)(Id & 0xFF);
            data[2] = (byte)((Value >> 24) & 0xFF);
            data[3] = (byte)((Value >> 16) & 0xFF);
            data[4] = (byte)((Value >> 8) & 0xFF);
            data[5] = (byte)(Value & 0xFF);

            return data;
        }

        public static Parameter FromByteArray(byte[] data)
        {
            if(data.Length != 6)
                throw new Exception("Data should be exactly length 6 for packets!");

            var param = new Parameter();
            param.Id = (UInt16)((data[0] << 8) + data[1]);
            param.Value = (UInt32)((data[2] << 24) + (data[3] << 16) + (data[4] << 8) + data[5]);
            return param;
        }
    }
}
