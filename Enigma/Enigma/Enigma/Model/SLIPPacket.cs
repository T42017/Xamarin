using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    public class SLIPPacket
    {
        public const byte END = 192;
        public const byte ESC = 219;

        public const byte ESC_END = 220;
        public const byte ESC_ESC = 221;
        /*
         * Packet is    
         *              LENGTH  1 byte (pre escaped, always 6 for now)
         *              PAYLOAD 6 byte (default 
         *              CRC     1 byte
         *              END     1 byte
         * */

        public static byte[] ToByteArray(Parameter parameter)
        {
            var data = new List<byte>();
            data.Add(6);
            var payload = parameter.ToByteArray();
            data.AddRange(payload);
            data.Add(CalculateCrc(payload));

            //Byte stuffing
            for (int i = 1; i < data.Count; i++)
            {
                byte b = data[i];
                if (b == END || b == ESC)
                {
                    data.Insert(i, ESC);
                    data[i + 1] = (b == END) ? ESC_END : ESC_ESC;
                }
            }
            data.Add(END);

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
