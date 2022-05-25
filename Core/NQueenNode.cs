using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class NQueenNode : ICloneable
    {
        private NQueenState state;
        private NQueenNode parent;
        private int depth;
        public int NrOfOperators { get { return state.NrOfOperators; } }
        public int GridSize { get { return this.state.GridSize; } }
        private NQueenNode() { }
        public NQueenNode(NQueenState startState)
        {
            this.state = startState;
            this.parent = null;
            this.depth = 0;
        }
        public NQueenNode(NQueenNode parent)
        {
            this.state = (NQueenState)parent.state.Clone();
            this.parent = parent;
            this.depth = parent.depth + 1;
        }

        public int Depth { get { return this.depth; } set { this.depth = value; } }
        public NQueenNode Parent { get { return this.parent; } }
        public bool IsTerminal { get { return this.state.IsGoalState(); } }

        public List<NQueenNode> Expand()
        {
            List<NQueenNode> newNodes = new List<NQueenNode>();
            for (int i = 0; i < this.NrOfOperators; i++)
            {
                NQueenNode newNode = new NQueenNode(this);
                if (newNode.SuperOperator(i) != null)
                    newNodes.Add(newNode);
            }
            return newNodes;
        }

        public NQueenNode SuperOperator(int i)
        {
            NQueenNode node = new NQueenNode(this);
            if (node.state.SuperOperator(i) == null) return null;
            return node;
        }

        public NQueenNode Move(int n, int m)
        {
            return SuperOperator(n*state.GridSize + m);
        }


        public object Clone()
        {
            NQueenNode clone = new NQueenNode
            {
                parent = this.parent,
                state = (NQueenState)this.state.Clone(),
                depth = this.depth
            };
            return clone;
        }

        public override string ToString() { return this.state.ToString(); }
    }
}
