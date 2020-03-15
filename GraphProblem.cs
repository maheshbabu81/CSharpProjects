using System;
namespace AlgorithmConsole
{
    public class GraphProblem
    {

        public int FindNumberOfIsland(int[][] array)
        {
            int count = 0;
            int length = array.Length;
            int length2 = array[0].Length;
            int[][] visitedArray = new int[length][];
            for(int i =0; i< length; i++)
            {
                visitedArray[i] = new int[length2];
            }

            for(int i =0; i<length; i++)
            {
                for(int j =0; j < length2; j++)
                {
                    if(array[i][j] != 0 && visitedArray[i][j] == 0)
                    {
                        visitedArray[i][j] = 1;
                        ExploreIsland(array, i, j, visitedArray);
                        count++;
                    }
                }
            }
            return count;
        }

        public void ExploreIsland(int[][] array, int row, int col, int[][] visitedArray)
        {
            int length = array.Length;
            int length2 = array[0].Length;
            if (row+1 < length && col+1 < length2 && array[row+1][col+1] ==1 && visitedArray[row+1][col+1] != 1)
            {
                visitedArray[row + 1][col + 1] = 1;
                ExploreIsland(array, row + 1, col + 1, visitedArray);
            }

            if (row + 1 < length && col - 1 > 0 && array[row + 1][col - 1] == 1 && visitedArray[row + 1][col - 1] != 1)
            {
                visitedArray[row + 1][col - 1] = 1;
                ExploreIsland(array, row + 1, col - 1, visitedArray);
            }

            if (row + 1 < length  && array[row + 1][col] == 1 && visitedArray[row + 1][col] != 1)
            {
                visitedArray[row + 1][col] = 1;
                ExploreIsland(array, row + 1, col, visitedArray);
            }

            if (row < length && col + 1 < length2 && array[row][col + 1] == 1 && visitedArray[row][col + 1] != 1)
            {
                visitedArray[row][col + 1] = 1;
                ExploreIsland(array, row, col + 1, visitedArray);
            }

            if (row < length && col - 1 > 0 && array[row][col - 1] == 1 && visitedArray[row][col - 1] != 1)
            {
                visitedArray[row][col - 1] = 1;
                ExploreIsland(array, row, col - 1, visitedArray);
            }

            if (row - 1 > 0 && col -1 > 0 && array[row - 1][col - 1] == 1 && visitedArray[row - 1][col - 1] != 1)
            {
                visitedArray[row - 1][col - 1] = 1;
                ExploreIsland(array, row - 1, col - 1, visitedArray);
            }

            if (row - 1 > 0 && array[row - 1][col] == 1 && visitedArray[row - 1][col] != 1)
            {
                visitedArray[row - 1][col] = 1;
                ExploreIsland(array, row - 1, col, visitedArray);
            }

            if (row - 1 > 0 && col + 1 < length2 && array[row - 1][col + 1] == 1 && visitedArray[row - 1][col + 1] != 1)
            {
                visitedArray[row - 1][col + 1] = 1;
                ExploreIsland(array, row - 1, col + 1, visitedArray);
            }
        }

    }
}
