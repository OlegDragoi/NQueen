using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class NQueenNode : ANode
    {
        public NQueenNode(AState startState) : base(startState) { }
        public NQueenNode(ANode node) : base(node) { }

        public override List<ANode> Expand()
        {
            List<ANode> nodes = new List<ANode>();
            NQueenNode node = this;
            do
            {
                nodes.Add(node);
                node = (NQueenNode)node.Parent;
            } while (node.Parent != null);
            return nodes;
        }
    }
}
