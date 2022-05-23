using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class ANode
    {
        AState state;
        ANode parent;
        int depth;

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
        public AState State { get { return this.state; } }
        public int Depth { get { return this.depth; } }
        public bool IsTerminal { get { return this.state.IsGoalState(); } }

        public override bool Equals(object obj)
        {
            if (!(obj is ANode)) return false;
            ANode other = (ANode)obj;
            return this.state.Equals(other.state);
        }
        public override string ToString() { return this.state.ToString(); }

        public abstract List<ANode> Expand();
    }
}
