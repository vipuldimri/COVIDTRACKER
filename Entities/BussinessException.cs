using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BussinessException : Exception
    {
        public string CustomMessage { get; set; }
        public BussinessException(string message)
        {
            CustomMessage = message;
        }
    }
}
