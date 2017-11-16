using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.BlueTooth.Mock
{
    public interface IBlueToothDevice
    {
        int BytesToRead { get; }

        void Write(byte[] buffer, int offset, int count);
        void Read(byte[] buffer, int offset, int count);
    }
}
