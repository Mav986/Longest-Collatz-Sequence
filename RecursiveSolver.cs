namespace CollatzSequence
{
    public class RecursiveSolver : Solver
    {
        public override int SolveCollatzMemoized(CollatzChain chain)
        {
            GetCollatzSequenceMemoized(chain);
            _cache.Add(chain.NumToCalculate, chain.Length);
            return chain.Length;
        }

        public override int SolveCollatzBruteForce(CollatzChain chain)
        {
            return GetCollatzSequenceBruteForce(chain);
        }

        private void GetCollatzSequenceMemoized(CollatzChain chain)
        {
            if (_cache.ContainsKey(chain.CurrentNumber))
            {
                chain.Length += _cache[chain.CurrentNumber];
            }
            else if (chain.CurrentNumber != 1)
            {
                Solve(chain);
                GetCollatzSequenceMemoized(chain);
            }
        }

        private int GetCollatzSequenceBruteForce(CollatzChain chain)
        {
            if (chain.CurrentNumber == 1)
            {
                return chain.Length;
            }

            Solve(chain);

            return GetCollatzSequenceBruteForce(chain);
        }
    }
}
