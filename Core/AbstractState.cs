using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class AbstractState : ICloneable
    {
        public abstract bool IsState();
        public abstract bool IsGoalState();
        public abstract AbstractState SuperOperator(int i);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
