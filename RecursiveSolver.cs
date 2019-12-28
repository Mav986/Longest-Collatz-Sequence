namespace CollatzSequence
{
    public class RecursiveSolver : Solver
    {
        public override int SolveCollatzMemoized(CollatzChain chain)
        {
            var length = GetCollatzSequenceMemoized(chain);
            _cache.Add(chain.NumToCalculate, length);
            return length;
        }

        public override int SolveCollatzBruteForce(CollatzChain chain)
        {
            return GetCollatzSequenceBruteForce(chain);
        }

        private int GetCollatzSequenceMemoized(CollatzChain chain)
        {
            if (_cache.ContainsKey(chain.CurrentNumber))
            {
                chain.Length += _cache[chain.CurrentNumber];
            }
            else if (chain.CurrentNumber != 1)
            {
                Solve(chain);
                chain.Length = GetCollatzSequenceMemoized(chain);
            }

            return chain.Length;
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
