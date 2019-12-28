namespace CollatzSequence
{
    public class IterativeSolver : Solver
    {
        // Here is an example of solving the problem while using memoization. In every loop
        // we first check if the local cache has the collatz chain length stored for the
        // current number. If it does, we use the precomputed value for our calculation
        // instead of recalculating it all over again. If the chain length isn't stored,
        // we simply continue on with the algorithm as normal.
        public override int SolveCollatzMemoized(CollatzChain chain)
        {
            while (true)
            {
                if (_cache.ContainsKey(chain.CurrentNumber))
                {
                    chain.Length += _cache[chain.CurrentNumber];
                    break;
                }
                else if (chain.CurrentNumber != 1) Solve(chain);
                else break;
            }

            _cache.Add(chain.NumToCalculate, chain.Length);
            return chain.Length;
        }

        public override int SolveCollatzBruteForce(CollatzChain chain)
        {
            while (true)
            {
                if (chain.CurrentNumber != 1) Solve(chain);
                else break;
            }

            return chain.Length;
        }
    }
}
