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

        protected int nrOfOperators;
        public virtual int NrOfOperators { get { return nrOfOperators; } }
        public abstract AState SuperOperator(int i);

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
