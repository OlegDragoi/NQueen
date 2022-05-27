using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class ASolutionFinder
    {
        private NQueenNode startNode;
        public ASolutionFinder(NQueenNode startNode) { this.startNode = startNode; }
        public ASolutionFinder(int n):this(new NQueenNode(n)) {}

        public NQueenNode StartNode { get { return this.startNode; } }

        public abstract NQueenNode FindSolution();
    }
}
