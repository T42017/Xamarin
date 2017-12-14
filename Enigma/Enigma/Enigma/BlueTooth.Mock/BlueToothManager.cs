using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.BlueTooth.Mock
{
    public class BlueToothManager : IBlueToothManager
    {
        public IBlueToothDevice Connect()
        {
            Task.Delay(5000).Wait();
            return new EnigmaDevice();
        }

        public void initializeBluetooth()
        {
            throw new NotImplementedException();
        }
    }
}
