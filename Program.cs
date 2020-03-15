using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char ch = 'y';
            while (ch == 'y')
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("1. String Algorithm");
                Console.WriteLine("2. Integer Algorithm");
                Console.WriteLine("3. Graph Algorithm");
                Console.WriteLine("4. Coins Problem");
                Console.WriteLine("Please select the algorithm.");
                var consoleRead = Console.ReadKey();
                int input = 0;
                if(int.TryParse(consoleRead.KeyChar.ToString(), out input))
                {
                    if(input > 5 || input <= 0)
                    {
                        Console.WriteLine("Exiting the application.");
                        return;
                    }
                    Console.WriteLine("");
                    switch(input)
                    {
                        case 1: StringProblem sp = new StringProblem();
                            Console.WriteLine("Are strings('anagram','nagaram') Anagrams?: " + sp.ValidAnagrams("anagram", "nagaram"));
                            Console.WriteLine("Are strings('abdomhe','kslowdq') Anagrams?: " + sp.ValidAnagrams("abdomhe", "kslowdq"));
                            Console.WriteLine("Longest length without repeating characters(pwwkewl):" + sp.LongestStringWithoutRepeatingCharaacters("pwwkewl"));
                            Console.WriteLine("Longest length without repeating characters(lonekingg):" + sp.LongestStringWithoutRepeatingCharaacters("lonekingg"));
                            break;
                        case 2: IntegerAlgorithm iAlg = new IntegerAlgorithm();
                            Console.WriteLine("Maximum continous sum of [-5,2,1,-5,-6,-3]:" +iAlg.MaximumContinousSum(new int[] { -5, 2, 1, -5, -6, -3 }));
                            Console.WriteLine("Maximum continous sum of [-5,-2,-1,-5,-6,-3]:" + iAlg.MaximumContinousSum(new int[] { -5, -2, -1, -5, -6, -3 }));
                            Console.WriteLine("Maximum continous sum of [5,2,1,5,6,-3]:" + iAlg.MaximumContinousSum(new int[] { 5, 2, 1, 5, 6, -3 }));
                            var locs = iAlg.SumContinousEqualToK(new int[] { 1, 2,3,2,1 }, 3);
                            foreach (Locations l in locs)
                            {
                                Console.WriteLine("Sum of continous [1,2,3,2,1] equal to 3:" +l.start + ":" + l.end);
                            }
                            break;
                        case 3: GraphProblem gp = new GraphProblem();
                            int[][] island = new int[4][];
                            island[0] = new int[4] { 1, 0, 0, 0 };
                            island[1] = new int[4] { 1, 1, 1, 0 };
                            island[2] = new int[4] { 1, 1, 0, 0 };
                            island[3] = new int[4] { 1, 0, 0, 1 };
                            Console.WriteLine("Number of isand:" + gp.FindNumberOfIsland(island));
                            break;
                        case 4: CoinsProblem c = new CoinsProblem();
                            List<int> selectedList = new List<int>();
                            c.FindAllPossibleCombination(18, 0, selectedList);
                            Console.WriteLine("Minimum number of Coins for value 18 :" + c.MinimumNumberOfCoins(18, 0, 0, new Dictionary<string, int>()));
                            break;

                    }

                }
                else
                {
                    Console.WriteLine(consoleRead.KeyChar.ToString() + "is invalid entry.");
                    return;
                }
            }
            /*StringProblem sp = new StringProblem();
            Console.WriteLine("Longest length without repeating characters:"
                + sp.LongestStringWithoutRepeatingCharaacters("pwwkewl"));

            Console.WriteLine("Are strings Anagrams?: " + sp.ValidAnagrams("anagram", "nagaram"));*/

            //IntegerAlgorithm iAlg = new IntegerAlgorithm();
            //Console.WriteLine(iAlg.MaximumContinousSum(new int[] { -5, 2, 1, -5, -6, -3 }));

            //var locs = iAlg.SumContinousEqualToK(new int[] { 1, 1, 1 }, 2);
            //foreach(Locations l in locs)
            //{
              //  Console.WriteLine(l.start + ":" + l.end);
            //}
            /*
            int[][] island = new int[4][];
            island[0] = new int[4] { 1, 0, 0, 0 };
            island[1] = new int[4] { 1, 1, 1, 0 };
            island[2] = new int[4] { 1, 1, 0, 0 };
            island[3] = new int[4] { 1, 0, 0, 1 };
            GraphProblem gp = new GraphProblem();
            Console.WriteLine(gp.FindNumberOfIsland(island));

            int[] array = new int[] { -2, -3, -4, -1, -5, -3 };
            List<int> resultList = new List<int>();
            //List<int> returnList =MaximumNumberOfElements(array,0, 13, resultList);
            Console.WriteLine(FindMaximumContinous(array));

            CoinsProblem c = new CoinsProblem();
            //var list = c.FindAllPossibleCombination(18, 0, new List<int>());
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine(c.MinimumNumberOfCoins(18, 0,0, new Dictionary<string,int>()));
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);*/
        }


        public static int MinimumNumberOfElements(int[] array, int sum)
        {
            int[] table = new int[sum + 1];
            table[0] = 0;
            for(int i =1; i<=sum; i++)
            {
                table[i] = int.MaxValue;
            }
            for (int j = 1; j <= sum; j++)
            {
                foreach (int i in array)
                {
                    if (j >= i && (j-i != i))
                    {
                        if (table[j - i] != int.MaxValue)
                        {
                            int temp = table[j - i] + 1;
                            if (table[j] > temp)
                            {
                                table[j] = temp;
                            }
                        }
                    }
                }
            }
            for(int i =0; i<= sum; i++)
            {
                Console.WriteLine(i + ":" + table[i]);
            }
            return table[sum];
        }

        public static List<int> MaximumNumberOfElements(int[] array, int index, int sum, List<int> selectedList)
        {
            if(sum == 0)
            {
                return selectedList;
            }

            if(sum != 0 && index >= array.Length)
            {
                return null;
            }

            
            var retList = MaximumNumberOfElements(array, index + 1, sum, selectedList);
            if(sum >= array[index])
            {
                List<int> s = new List<int>(selectedList);
                s.Add(array[index]);
                var returnList2 = MaximumNumberOfElements(array, index + 1, sum - array[index], s);
                
                if (retList != null && returnList2 != null)
                {
                    retList = retList.Count < returnList2.Count ? returnList2 : retList;
                }
                else
                {
                    if(retList == null)
                    {
                        retList = returnList2;
                    }
                }
                
            }

            return retList;
        }
        public static int MinimumNumberOfElements(int[] array, int index, int sum, int count)
        {
            if(sum == 0)
            {
                
                Console.WriteLine("======================");
                return count;

            }
            int minimumCost = 0;
            if(sum != 0 && index == array.Length)
            {
                return -1;
            }
            else
            {
                minimumCost = MinimumNumberOfElements(array, index + 1, sum, count);
                if(sum == array[index])
                {
                    return count + 1;
                }

                if(sum > array[index])
                {
                    
                    int result = MinimumNumberOfElements(array, index + 1, sum - array[index], count+1);
                    if((result != -1)&&(minimumCost != -1))
                    {
                        minimumCost = result < minimumCost ? result : minimumCost;
                    }
                    else
                    {
                        if(result!= -1)
                        {
                            minimumCost = result;
                        }
                    }
                    
                }
                return minimumCost;
            }

        }

        public static int FindMaximumContinous(int[] array)
        {
            int sum = 0, max_soFar = 0;
            int startindex = -1, endIndex = -1;
            for(int i = 0; i< array.Length; i++)
            {
                sum = sum + array[i];
                if(sum <= array[i])
                {
                    startindex = i;
                    sum = array[i];
                    endIndex = i;
                }

           
                if(max_soFar < sum)
                {
                    max_soFar = sum;
                    endIndex = i;
                }

                

                if(max_soFar < 0)
                {
                    max_soFar = 0;
                }
            }
            Console.WriteLine(startindex + ":" + endIndex);
            return max_soFar;
        }
    }

   
}
