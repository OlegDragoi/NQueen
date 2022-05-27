using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SolutionFinders
{
    public class BackTrackFinder : ASolutionFinder
    {
        int depthBound;
        public BackTrackFinder(NQueenNode startNode) : this(startNode, startNode.GridSize) { }
        public BackTrackFinder(NQueenNode startNode, int depthBound)
            : base(startNode)
        {
            this.depthBound = depthBound;
        }
        public BackTrackFinder(int n) : base(n)
        {
            this.depthBound = n;
        }

        public override NQueenNode FindSolution()
        {
            return Search(StartNode);
        }

        private NQueenNode Search(NQueenNode actualNode)
        {
            if (actualNode == null) return null;
            int depth = actualNode.Depth;
            if (depthBound > 0 && depth > depthBound)
                return null;

            if (actualNode.IsTerminal)
                return actualNode;

            for (int i = 0; i < depthBound; i++)
            {
                NQueenNode terminalNode = Search(actualNode.Move(depth, i));
                if (terminalNode != null)
                    return terminalNode;
    
            }

            return null;
        }
    }
}
