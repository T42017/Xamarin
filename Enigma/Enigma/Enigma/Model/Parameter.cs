using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Model
{
    public class Parameter
    {
        public UInt16 Id { get; set; }
        public UInt32 Value { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }
        public object Content { get; set; }

        public enum ParameterType
        {
            Integer16,
            Integer32,
            String,
            Float,
            Bool,
            Select,
            ReadOnly

        }

        public string Type { get; set; }

        public byte[] ToByteArray()
        {
            var data = new byte[6];
            data[0] = (byte) (Id >> 8);
            data[1] = (byte) (Id & 0xFF);
            data[2] = (byte) ((Value >> 24) & 0xFF);
            data[3] = (byte) ((Value >> 16) & 0xFF);
            data[4] = (byte) ((Value >> 8) & 0xFF);
            data[5] = (byte) (Value & 0xFF);

            return data;
        }

        public static Parameter FromByteArray(byte[] data)
        {
            if (data.Length != 6)
                throw new Exception("Data should be exactly length 6 for packets!");

            var param = new Parameter
            {
                Id = (UInt16) ((data[0] << 8) + data[1]),
                Value = (UInt32) ((data[2] << 24) + (data[3] << 16) + (data[4] << 8) + data[5])
            };
            return param;
        }

        public string TranslatedName => GetTranslatedString(Name);

        const string ResourceId = "Enigma.Resources.AppResource";

        private string GetTranslatedString(string name)
        {
            if (name == null)
                return null;

            ResourceManager resourceManager =
                new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            var translated = resourceManager.GetString(name, CultureInfo.CurrentCulture);
            return string.IsNullOrEmpty(translated) ? name : translated;
        }
    }
}
