using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class NQueenNode : ANode
    {
        private NQueenNode() { }
        public NQueenNode(NQueenState startState) : base(startState) { }
        public NQueenNode(NQueenNode node) : base(node) { }

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
            if (this.State.SuperOperator(i) == null) return null;
            return node;
        }

        public override object Clone()
        {
            NQueenNode clone = new NQueenNode();
            clone.parent = this.parent;
            clone.state = (NQueenState)this.state.Clone();
            clone.depth = this.depth;
            return clone;
        }
    }
}
