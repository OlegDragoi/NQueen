using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Core;
using Core.SolutionFinders;

namespace NQueen
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 4;
            {
                ASolutionFinder rFinder = new RandomFinder(new NQueenNode(new NQueenState(n)));
                NQueenNode rNode = (NQueenNode)rFinder.FindSolution();
                Console.WriteLine(rNode);
            }

            ASolutionFinder backFinder = new BackTrackFinder(new NQueenNode(new NQueenState(n)), n);
            NQueenNode bNode = (NQueenNode)backFinder.FindSolution();
            Console.WriteLine(bNode);

            Console.ReadKey();
        }
    }
}
