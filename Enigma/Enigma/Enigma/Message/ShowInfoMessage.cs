using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Message
{
    class ShowInfoMessage
    {
        public ShowInfoMessage(string title, string message, string buttonText = "Close")
        {
            Title = title;
            Message = message;
            ButtonText = buttonText;
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public string ButtonText { get; set; }
    }
}
