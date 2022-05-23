using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class AState : ICloneable
    {
        public abstract bool IsState();
        public abstract bool IsGoalState();
        public abstract AState SuperOperator(int i);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
