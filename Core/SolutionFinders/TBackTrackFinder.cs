using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Core.SolutionFinders
{
    public class TBackTrackFinder : ASolutionFinder
    {
        int depthBound;
        NQueenNode finalNode;
        List<Thread> threads = new List<Thread>();
        public TBackTrackFinder(NQueenNode startNode) : this(startNode, startNode.GridSize) { }
        public TBackTrackFinder(NQueenNode startNode, int depthBound)
            : base(startNode)
        {
            this.depthBound = depthBound;
        }
        public TBackTrackFinder(int n) : base(n)
        {
            this.depthBound = n;
        }

        public override NQueenNode FindSolution()
        {
            Search(this.StartNode);
            while (threads.Count != 0)
            {
                lock (threads)
                {
                    if (!threads[0].IsAlive)
                    {
                        threads[0].Interrupt();
                        threads.RemoveAt(0);
                    }
                }
            }
            return finalNode;
        }

        private void Search(NQueenNode actualNode)
        {
            if (actualNode == null) return;
            int depth = actualNode.Depth;
            if (depthBound > 0 && depth > depthBound)
                return;

            if (actualNode.IsTerminal)
            {
                lock (threads)
                {
                    finalNode = actualNode;
                }
            }

            try
            {
                for (int i = 0; i < actualNode.GridSize; i++)
                {
                    lock (threads)
                    {
                        Thread newTread = new Thread(x => Search(actualNode.Move(depth, i)));
                        threads.Add(newTread);
                        newTread.IsBackground = true;
                        newTread.Start();
                    }
                }
            }
            catch(Exception e) { }
            
        }
    }
}
