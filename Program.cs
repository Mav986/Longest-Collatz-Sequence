using CollatzSequence;
using System;
using System.Collections.Generic;

// Small program to show the difference in algorithm speeds with memoization vs without.
// The algorithm used is the Collatz Conjecture. For more information, see Solver.cs
// I've implemented the algorith using both an iterative and recursive approaches.
class MainClass
{
    public static void Main(string[] args)
    {
        int limit = 1000000;

        var recursive = new RecursiveSolver();
        //var iterative = new IterativeSolver();

        var memoizedLengths = new List<int>();
        Console.Write("Calculating Memoized Solution... ");
        var memoizedPerformance = Calculate(limit, memoizedLengths, recursive.SolveCollatzMemoized);
        Console.WriteLine($"completed in {memoizedPerformance}ms!");

        var bruteForcedLengths = new List<int>();
        Console.Write("Calculating Brute Force Solution... ");
        var bruteForceperformance = Calculate(limit, bruteForcedLengths, recursive.SolveCollatzBruteForce);
        Console.WriteLine($"completed in {bruteForceperformance}ms!");

        var maxChainMemoized = GetMaxChain(memoizedLengths);
        var maxChainBruteForced = GetMaxChain(bruteForcedLengths);
        double memoizationGains = (double)bruteForceperformance / (double)memoizedPerformance;

        if (maxChainMemoized == maxChainBruteForced)
        {
            Console.WriteLine($"Memoization was {Math.Round(memoizationGains, 1)}x faster than the brute force approach\nMax chain length is: {maxChainMemoized}");
        }
        else
        {
            Console.WriteLine($"Error calculating lengths: Brute force length ({maxChainBruteForced}) differs from Memoized length ({maxChainMemoized})");
        }
    }

    private static long Calculate(int limit, List<int> chainLengths, Func<CollatzChain, int> calc)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        for (int ii = 1; ii <= limit; ii++)
        {
            var chain = new CollatzChain(ii);
            chainLengths.Add(calc(chain));
        }
        watch.Stop();
        var memoizedPerformance = watch.ElapsedMilliseconds;

        return memoizedPerformance;
    }

    // Get the max chain length we've computed
    private static long GetMaxChain(List<int> chainLengths)
    {
        int max = 0;
        foreach (int entry in chainLengths)
        {
            max = Math.Max(entry, max);
        }

        return max;
    }
}