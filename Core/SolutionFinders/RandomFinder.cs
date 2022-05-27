using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SolutionFinders
{
    public class RandomFinder : ASolutionFinder
    {
        int depthBound = 10000;
        Random rnd = new Random();
        public RandomFinder(NQueenNode startNode) : base(startNode) { }
        public RandomFinder(int n) : base(n) { }

        public override NQueenNode FindSolution()
        {
            NQueenNode solution = this.StartNode;
            while (!solution.IsTerminal && solution.Depth < depthBound)
            {
                solution = solution.SuperOperator(rnd.Next(solution.NrOfOperators));
            }
            if (!solution.IsTerminal)
            {
                return this.FindSolution();
            }
            return solution;
        }
    }
}
