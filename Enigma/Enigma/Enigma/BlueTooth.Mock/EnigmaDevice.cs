using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.Model;

namespace Enigma.BlueTooth.Mock
{
    public class EnigmaDevice : IBlueToothDevice
    {
        public int BytesToRead => _readbuffer.Count;

        private Dictionary<UInt16, UInt32> _parameters = new Dictionary<ushort, uint>();
        private List<byte> _readbuffer = new List<byte>();
        private List<byte> _writebuffer = new List<byte>();

        public EnigmaDevice()
        {
            _parameters.Add(1, 12);
            _parameters.Add(2, 10);

            _parameters.Add(11, 192);
            _parameters.Add(12, 219);
        }

        /// <summary>
        /// Writes a specified number of bytes to the device using data from a buffer
        /// </summary>
        /// <param name="buffer">The byte array that contains the data to write to the device</param>
        /// <param name="offset">The zero-based byte offset in the buffer parameter at which to begin copying bytes to the device</param>
        /// <param name="count">The number of bytes to write</param>
        public void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count];
            Array.Copy(buffer,offset, data, 0, count);

            Task.Delay(1000).Wait();

            //Handle packets.
            var DeStuffBuffer = new List<byte>();
            DeStuffBuffer.AddRange(data);

            // there is a small chance that last byte is ESC and stuffing is missing
            // in that case save that byte in buffer
            bool lastByteIsEsc = DeStuffBuffer.Last() == Packet.ESCAPE;

            for (int i = 0; i < DeStuffBuffer.Count; i++)
            {
                if (DeStuffBuffer[i] == Packet.ESCAPE && (i + 1) < DeStuffBuffer.Count)
                {
                    if (DeStuffBuffer[i + 1] == Packet.STARTSTUFF)
                    {
                        DeStuffBuffer[i] = Packet.START;
                        DeStuffBuffer.RemoveAt(i + 1);
                    }
                    else if (DeStuffBuffer[i + 1] == Packet.ESCAPESTUFF)
                    {
                        DeStuffBuffer[i] = Packet.ESCAPE;
                        DeStuffBuffer.RemoveAt(i + 1);
                    }
                }
            }

            if (lastByteIsEsc)
            {
                _writebuffer.AddRange(DeStuffBuffer.GetRange(0, DeStuffBuffer.Count - 1));
                DeStuffBuffer.RemoveRange(0, DeStuffBuffer.Count - 1);
            }
            else
            {
                _writebuffer.AddRange(DeStuffBuffer);
                DeStuffBuffer.Clear();
            }

            int off = -1;

            for (int i = 0; i < _writebuffer.Count; i++)
            {
                if (_writebuffer[i] == Packet.START && (i + 2) < _writebuffer.Count)
                {
                    int length = _writebuffer[i + 1];
                    if ((i + 2 + length) < _writebuffer.Count)
                    {
                        off = i + 2 + length;

                        try
                        {
                            var p = Parameter.FromByteArray(_writebuffer.GetRange(i + 1, length).ToArray());
                            i = i + 2 + length;
                            if (p != null)
                                HandleIncomingParameter(p);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error parsing packet: " + ex.Message, ex);
                        }
                    }
                }
            }

            _writebuffer.RemoveRange(0, off+ 1);
        }

        private void HandleIncomingParameter(Parameter parameter)
        {
            parameter.Value = _parameters[parameter.Id];
            _readbuffer.AddRange(Packet.ToByteArray(parameter));
        }

        /// <summary>
        /// Reads a number of bytes from the device input buffer and writes those bytes into a byte array at the specified offset.
        /// </summary>
        /// <param name="buffer">The byte array to write the input to.</param>
        /// <param name="offset">The offset in buffer at which to write the bytes.</param>
        /// <param name="count">The maximum number of bytes to read. Fewer bytes are read if count is greater than the number of bytes in the input buffer.</param>
        public void Read(byte[] buffer, int offset, int count)
        {
            Task.Delay(1000).Wait();

            count = count > BytesToRead ? BytesToRead : count;
            Array.Copy(_readbuffer.ToArray(), 0, buffer, offset, count);
            _readbuffer.RemoveRange(0, count);
        }
    }
}
