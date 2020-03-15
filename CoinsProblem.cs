using System;
using System.Collections.Generic;

namespace AlgorithmConsole
{
    public class CoinsProblem
    {
        public readonly List<int> coins;
        public CoinsProblem()
        {
            coins = new List<int>() { 1, 5, 10, 20, 50, 100 };
        }

        public int FindAllPossibleCombination(int sum, int index, List<int> selectedList)
        {
            if(sum == 0)
            {
                var combination = string.Join(",", selectedList);
                Console.WriteLine(combination);
                return 1;
            }

            if(sum != 0 && index == coins.Count)
            {
                return 0;
            }
            int count = 0;
            count += FindAllPossibleCombination(sum, index + 1, selectedList);
            if (sum >= coins[index])
            {
                //var newList = new List<int>(selectedList);
                selectedList.Add(coins[index]);
                count += FindAllPossibleCombination(sum-coins[index], index, selectedList);
                selectedList.Remove(coins[index]);
            }

            
            return count;
        }
        public int MinimumNumberOfCoins(int sum, int index, int count, Dictionary<string, int> cache)
        {
            if(cache.ContainsKey(sum +":" + index+":" + count))
            {
                return cache[sum + ":" + index +":" + count];
            }
            if(sum == 0)
            {
                return count;
            }

            if(index == coins.Count && sum != 0)
            {
                return -1;
            }

            int result = -1;
            if(sum >= coins[index])
            {
                result = MinimumNumberOfCoins(sum - coins[index], index, count + 1, cache);
                   
                
            }
            int mincount = MinimumNumberOfCoins(sum, index + 1, count, cache);

            if (result != -1 && mincount != -1 && result < mincount)
            {
                mincount = result;
            }
            else
            {
                if (mincount == -1 && result != -1)
                {
                    mincount = result;
                }
            }
            cache.Add(sum + ":" + index + ":" + count, mincount);
            return mincount;


        }
    }
}
