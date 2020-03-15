using System;
using System.Collections.Generic;
namespace AlgorithmConsole
{
    public class IntegerAlgorithm
    {
        public int MaximumContinousSum(int[] array)
        {
            int sum = 0, maxSoFar = int.MinValue;
            int start = 0, end = 0, s = 0;
            for(int i =0; i< array.Length; i++)
            {
                sum += array[i];
                if(maxSoFar < sum)
                {
                    maxSoFar = sum;
                    start = s;
                    end = i;
                }

                if (sum < 0)
                {
                    sum = 0;
                    s = i + 1;
                }
                
            }
            
            return maxSoFar;
        }

        public List<Locations> SumContinousEqualToK(int[] array, int K)
        {
            int start = 0, end = 0, sum = 0;
            List<Locations> locationList = new List<Locations>();
            // using the sliding window , i will move the end index until sum is either equal to K or greater than K
            // if sum is greater than K, we will move the start index to next index.
            // if sum is equal to K, we will store the results and move the start index.

            while(start < array.Length && end < array.Length)
            {
                sum += array[end];
                if(sum < K)
                {
                    end = end + 1;
                }

                if(sum > K)
                {
                    sum = sum - array[start];
                    start = start + 1;
                }

                if(sum == K)
                {
                    Locations loc = new Locations() { start = start, end = end };
                    locationList.Add(loc);
                    start += 1;
                }
            }
            return locationList;
        }
    }

    public class Locations
    {
        public int start { get; set; }
        public int end { get; set; }
    }
}
