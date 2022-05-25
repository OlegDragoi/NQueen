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

        public NQueenNode StartNode { get { return this.startNode; } }

        public abstract NQueenNode FindSolution();

        public void PrintSolution(NQueenNode terminalNode)
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

            List<NQueenNode> solution = SolutionStepByStep(terminalNode);
            foreach (NQueenNode node in solution)
                Console.WriteLine(node);
        }
        public List<NQueenNode> SolutionStepByStep(NQueenNode terminalNode)
        {
            List<NQueenNode> solution = new List<NQueenNode>();
            if (terminalNode == null)
                return solution;


            NQueenNode actualNode = terminalNode;
            while (actualNode != null)
            {
                solution.Add(actualNode);
                actualNode = actualNode.Parent;
            }
            return solution;
        }
    }
}
