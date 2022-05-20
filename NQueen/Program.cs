using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Core;

namespace NQueen
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 5;
            int nn = n * n;
            NQueenState state = new NQueenState(n);
            Console.WriteLine(state);
            while (!state.IsGoalState())
            {
                //int move = rnd.Next(nn);
                //state.SuperOperator(rnd.Next(move));
                state.Move(rnd.Next(n), rnd.Next(n));
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(state);
                //Console.WriteLine(move);
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }
    }
}
