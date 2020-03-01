using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    enum InputMode
    {
        Alphabetical = 1,
        Numerical = 2,
        Symbolic = 4,
        Alphanumeric = Alphabetical | Numerical,
        Alphasymbolic = Alphabetical | Symbolic,
        Numerosymbolic = Numerical | Symbolic,
        All = Alphabetical | Numerical | Symbolic
    }
}
