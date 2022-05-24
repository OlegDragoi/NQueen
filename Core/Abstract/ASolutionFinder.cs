using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class ASolutionFinder
    {
        private ANode startNode;
        public ASolutionFinder(ANode startNode) { this.startNode = startNode; }

        public ANode StartNode { get { return this.startNode; } }

        public abstract ANode FindSolution();

        public void PrintSolution(ANode terminalNode)
        {
            if (terminalNode == null)
                return;

            //Stack<Node> solution = new Stack<Node>();
            //Node actualNode = terminalNode;
            //while (actualNode != null)
            //{
            //    solution.Push(actualNode);
            //    actualNode = actualNode.Parent;
            //}

            List<ANode> solution = SolutionStepByStep(terminalNode);
            foreach (ANode node in solution)
                Console.WriteLine(node);
        }
        public List<ANode> SolutionStepByStep(ANode terminalNode)
        {
            List<ANode> solution = new List<ANode>();
            if (terminalNode == null)
                return solution;


            ANode actualNode = terminalNode;
            while (actualNode != null)
            {
                solution.Add(actualNode);
                actualNode = actualNode.Parent;
            }
            return solution;
        }
    }
}
