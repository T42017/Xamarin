using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    public class Packet
    {
        public const byte START = 192;
        public const byte ESCAPE = 219;

        public const byte STARTSTUFF = 220;
        public const byte ESCAPESTUFF = 221;
        /*
         * Packet is    START   1 byte
         *              LENGTH  1 byte (pre escaped, always 6 for now)
         *              PAYLOAD 6 byte (default 
         *              CRC     1 byte
         * */

        public static byte[] ToByteArray(Parameter parameter)
        {
            var data = new List<byte>();
            data.Add(START);
            data.Add(6);
            var payload = parameter.ToByteArray();
            data.AddRange(payload);
            data.Add(CalculateCrc(payload));

            //Byte stuffing
            for (int i = 1; i < data.Count; i++)
            {
                byte b = data[i];
                if (b == START || b == ESCAPE)
                {
                    data.Insert(i, ESCAPE);
                    data[i + 1] = (b == START) ? STARTSTUFF : ESCAPESTUFF;
                }
            }

            return data.ToArray();
        }

        public static Parameter FromByteArray(byte[] data)
        {
            //Destuff and make, if possible, a parameter object
            throw new NotImplementedException();
        }


        private static byte CalculateCrc(byte[] data)
        {
            // start with length
            byte crc = 6; 

            foreach (var b in data)
                crc += b;

            // 2-komplement
            return (byte)(0xFF - crc + 1);
        }
    }
}
