using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryCreator.Ressources.Core.Exception
{
    public class MzWrongEnumValueException : System.Exception
    {
        public MzWrongEnumValueException() : base() { }
        public MzWrongEnumValueException(string message) : base(message) { }
        public MzWrongEnumValueException(string message, System.Exception inner) : base(message, inner) { }
    }
}
