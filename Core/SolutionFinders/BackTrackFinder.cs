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
        public BackTrackFinder(ANode startNode) : this(startNode, 0) { }
        public BackTrackFinder(ANode startNode, int depthBound)
            : base(startNode)
        {
            this.depthBound = depthBound;
        }

        public override ANode FindSolution()
        {
            return Search(StartNode);
        }

        private ANode Search(ANode actualNode)
        {
            int depth = actualNode.Depth;
            if (depthBound > 0 && depth >= depthBound)
                return null;

            if (actualNode.IsTerminal)
                return actualNode;

            for (int i = 0; i < actualNode.NrOfOperators; i++)
            {
                ANode newNode = actualNode.SuperOperator(i);
                ANode terminalNode = Search(newNode);
                if (terminalNode != null)
                    return terminalNode;
    
            }

            return null;
        }
    }
}
