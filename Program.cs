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
        int limit = 20000;
        int numIterations = 1000;

        var recursiveSolver = new RecursiveSolver();
        var iterativeSolver = new IterativeSolver();

        Console.Write("Testing iterative approach... ");
        GetAverageResults(numIterations, limit, iterativeSolver);

        Console.Write("Testing recursive approach... ");
        GetAverageResults(numIterations, limit, recursiveSolver);

        Console.WriteLine("Complete!");
        Console.ReadKey();
    }

    private static void GetAverageResults(int numIterations, int limit, Solver solver)
    {
        double totalResults = 0, summedResults = 0;

        for(int ii = 0; ii < numIterations; ii++)
        {
            totalResults++;
            summedResults += RunAlgorithm(limit, solver);
            solver.Reset();
        }
        var average = summedResults / totalResults;
        Console.WriteLine($"memoization was on average {Math.Round(average, 1)}x faster.");
    }

    private static double RunAlgorithm(int limit, Solver solver)
    {
        var memoizedLengths = new List<int>();
        var memoizedPerformance = Calculate(limit, memoizedLengths, solver.SolveCollatzMemoized);

        var bruteForcedLengths = new List<int>();
        var bruteForceperformance = Calculate(limit, bruteForcedLengths, solver.SolveCollatzBruteForce);

        var maxChainMemoized = GetMaxChain(memoizedLengths);
        var maxChainBruteForced = GetMaxChain(bruteForcedLengths);
        double memoizationGains = (double)bruteForceperformance / (double)memoizedPerformance;

        if (maxChainMemoized == maxChainBruteForced)
        {
            //Console.WriteLine($"Memoization runtime: {memoizedPerformance}ms\nBrute Force runtime: {bruteForceperformance}ms");
            return memoizationGains;
        }
        else
        {
            throw new ArithmeticException($"Brute force length ({maxChainBruteForced}) differs from Memoized length ({maxChainMemoized})");
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