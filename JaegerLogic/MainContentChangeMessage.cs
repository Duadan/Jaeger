using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    public class MainContentChangeMessage
    {
        public MainContentChangeMessage(string name)
        {
            Control = name;
        }
        public string Control { get; set; }
    }
}
