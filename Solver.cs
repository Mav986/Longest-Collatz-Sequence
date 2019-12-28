using System.Collections.Generic;

namespace CollatzSequence
{
    // The Collatz Sequence of a number is defined as the number of valid operations
    // required to perform on the number to get to 1. The valid operations are:
    //
    // - If number is even, divide it by 2
    // - If number is odd, multiply by 3, then add 1
    public abstract class Solver
    {
        protected Dictionary<long, int> _cache;

        public Solver()
        {
            _cache = new Dictionary<long, int>();
        }

        public void Reset()
        {
            _cache = new Dictionary<long, int>();
        }

        protected void Solve(CollatzChain chain)
        {
            if (chain.CurrentNumber % 2 == 0)
            {
                chain.CurrentNumber /= 2;
            }
            else
            {
                chain.CurrentNumber = chain.CurrentNumber * 3 + 1;
            }
        }

        public abstract int SolveCollatzMemoized(CollatzChain chain);
        public abstract int SolveCollatzBruteForce(CollatzChain chain);
    }
}
