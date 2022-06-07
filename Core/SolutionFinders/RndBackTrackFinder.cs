using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SolutionFinders
{
    public class RndBackTrackFinder : ASolutionFinder
    {
        Random rnd = new Random();
        int depthBound;
        public RndBackTrackFinder(NQueenNode startNode) : this(startNode, startNode.GridSize) { }
        public RndBackTrackFinder(NQueenNode startNode, int depthBound)
            : base(startNode)
        {
            this.depthBound = depthBound;
        }
        public RndBackTrackFinder(int n) : base(n)
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

            List<int> spots = Enumerable.Range(1, actualNode.GridSize).ToList();
            for (int i = 0; i < actualNode.GridSize; i++)
            {
                int rIndex = rnd.Next(spots.Count);
                int chosenIndex = spots[rIndex];
                spots.RemoveAt(rIndex);
                NQueenNode terminalNode = Search(actualNode.Move(depth, chosenIndex));
                if (terminalNode != null)
                    return terminalNode;
    
            }

            return null;
        }
    }
}
