using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public interface IFileManager
    {
        void SaveFile(string filename, string text);
        string LoadFile(string filename);
    }
}
