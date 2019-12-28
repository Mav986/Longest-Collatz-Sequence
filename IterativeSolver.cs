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
            bool finished = false;
            while (!finished)
            {
                if (_cache.ContainsKey(chain.CurrentNumber))
                {
                    chain.Length += _cache[chain.CurrentNumber];
                    finished = true;
                }
                else
                {
                    finished = Solve(chain);
                }
            }

            _cache.Add(chain.NumToCalculate, chain.Length);
            return chain.Length;
        }

        public override int SolveCollatzBruteForce(CollatzChain chain)
        {
            bool finished = false;
            while (!finished)
            {
                finished = Solve(chain);
            }

            return chain.Length;
        }
    }
}
