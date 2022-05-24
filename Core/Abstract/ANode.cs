using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class ANode
    {
        protected AState state;
        protected ANode parent;
        protected int depth;
        public virtual int NrOfOperators { get { return state.NrOfOperators; } }

        protected ANode() { }
        public ANode(AState startState)
        {
            this.state = startState;
            this.parent = null;
            this.depth = 0;
        }
        public ANode(ANode parent)
        {
            this.state = (AState)parent.state.Clone();
            this.parent = parent;
            this.depth++;
        }

        public ANode Parent { get { return this.parent; } }
        public abstract ANode SuperOperator(int i);
        public AState State { get { return this.state; } }
        public int Depth { get { return this.depth; } set { this.depth = value; } }
        public bool IsTerminal { get { return this.state.IsGoalState(); } }

        //public abstract List<ANode> Expand();

        public override bool Equals(object obj)
        {
            if (!(obj is ANode)) return false;
            ANode other = (ANode)obj;
            return this.state.Equals(other.state);
        }

        public abstract object Clone();

        public override string ToString() { return this.state.ToString(); }
    }
}
