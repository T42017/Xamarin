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
         *              CRC-16  2 byte
         *              END     1 byte
         * */

        public static byte[] ToByteArray(Parameter parameter)
        {
            var data = new List<byte>();
            data.Add(6);
            var payload = parameter.ToByteArray();
            data.AddRange(payload);

            var crc = CalculateCrc16(payload);
            data.Add((byte)(crc >> 8));
            data.Add((byte)(crc & 0xFF));

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

        public static UInt16 CalculateCrc16(byte[] data)
        {
            UInt16 crc = UInt16.MaxValue;
            byte x = 0;

            foreach (var d in data)
            {
                x = (byte)((crc >> 8) ^ d);
                x ^= (byte)(x >> 4);
                crc = (UInt16)((crc << 8) ^ ((UInt16)(x << 12)) ^ ((UInt16)(x << 5)) ^ x);
            }

            return crc;
        }
    }
}
