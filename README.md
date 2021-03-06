# Longest-Collatz-Sequence
Someone asked for help regarding the [14th problem](https://projecteuler.net/problem=14) from 
projecteuler.net in [The Programmer's Hangout Discord](https://discord.gg/programming). I had never 
seen the Collatz Conjecture before, so I was curious. As I came to understand the algorithm, I 
realized it could benefit massively from a use of the Memoization technique, commonly used in 
optimizing game AI algorithms like Minimax. Since I had only recently learned about memoization 
myself, and had never actually implemented it, I thought this would be a good chance to have 
some fun.

I wrote this program to show the performance differences between using and not using memoization. 
I also incorporated the template method design pattern (although strategy would have worked too). 
Execution should take about 25-30 seconds.
