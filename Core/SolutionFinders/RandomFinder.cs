using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SolutionFinders
{
    public class RandomFinder : ASolutionFinder
    {
        Random rnd = new Random();
        public RandomFinder(ANode startNode) : base(startNode) { }

        public override ANode FindSolution()
        {
            ANode solution = this.StartNode;
            while (!solution.IsTerminal)
            {
                solution = solution.SuperOperator(rnd.Next(solution.NrOfOperators));
            }
            return solution;
        }
    }
}
