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

        public override ANode SuperOperator(int i)
        {
            NQueenNode node = new NQueenNode(this);
            if (node.State.SuperOperator(i) == null) return null;
            return node;
        }

        public override object Clone()
        {
            NQueenNode clone = new NQueenNode
            {
                parent = this.parent,
                state = (NQueenState)this.state.Clone(),
                depth = this.depth
            };
            return clone;
        }
    }
}
