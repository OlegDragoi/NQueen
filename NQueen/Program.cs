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
            int n = 8;
            {
                ASolutionFinder rFinder = new RandomFinder(n);
                NQueenNode rNode = rFinder.FindSolution();
                Console.WriteLine(rNode);
            }

            ASolutionFinder backFinder = new BackTrackFinder(n);
            NQueenNode bNode = backFinder.FindSolution();
            Console.WriteLine(bNode);

            Console.ReadKey();
        }
    }
}
