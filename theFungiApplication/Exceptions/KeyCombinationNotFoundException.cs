using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.Exceptions
{
    public class KeyCombinationNotFoundException : Exception
    {
        public KeyCombinationNotFoundException(int id1,Type type1, int id2, Type type2)
            : base($"Key Combination of type {type1} - id {id1} and type of {type2} - {id2} was not found")
        {

        }
    }
}
