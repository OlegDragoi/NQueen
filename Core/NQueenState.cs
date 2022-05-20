using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class NQueenState : AbstractState
    {
        private int n;
        private int[] displacement;

        public NQueenState(int n)
        {
            this.n = n;
            this.displacement = new int[n];
            for (int i = 0; i < n; i++)
            {
                this.displacement[i] = 0;
            }
        }

        public NQueenState(int[] dsp)
        {
            this.n = dsp.Length;
            this.displacement = new int[dsp.Length];
            for (int i = 0; i < n; i++)
            {
                this.displacement[i] = dsp[i];
            }
        }

        public NQueenState Move(int n, int m)
        {
            if(!IsOperator(n,m))
                return null;

            NQueenState actual = (NQueenState)this.Clone();

            this.displacement[n] = m;

            if (!IsState())
            {
                this.displacement[n] = actual.displacement[n];
                return null;
            }
                
            return this;
        }
        public bool IsOperator(int n, int m)
        {
            if (n < 0 || n >= this.n) return false;
            if (m < 0 || m >= this.n) return false;
            return true;
        }

        public override bool IsGoalState()
        {
            for (int i = 0; i < this.n-1; i++)
            {
                for (int j = i + 1; j  < this.n; j ++)
                {
                    //check if there are any Queens on the same row
                    if (this.displacement[i] == this.displacement[j])
                        return false;
                    //check if there are any Queens on the same diagonal
                    if (Math.Abs(i - j) == Math.Abs(this.displacement[i] - this.displacement[j]))
                        return false;
                }
            }
            return true;
        }

        public override bool IsState()
        {
            foreach (int item in this.displacement)
            {
                if (item < 0 || item >= this.n) return false;
            }
            return true;
        }

        public override AbstractState SuperOperator(int i)
        {
            if (i >= (this.n * this.n)) return null;
            int n = i / this.n;
            int m = i % this.n;
            return Move(n, m);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    if (this.displacement[i] == j) builder.Append('Q');
                    else builder.Append('-');
                }
                builder.Append('\n');
            }
            return builder.ToString();
        }

        public object Clone()
        {
            NQueenState clone = new NQueenState(this.displacement);
            return clone;
        }
    }
}
