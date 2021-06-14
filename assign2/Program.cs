using System;
using System.Collections.Generic;
using System.Linq;
namespace assign2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 2, 3, 1, 1, 3, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "Tampa", "Miami" });
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                //write your code here.
                int[] temp= new int[500];
                int k = 0;
                foreach(int i in nums1)
                {
                    int j = 0;
                    
                    while (nums2.Length > j) 
                    {
                        
                        if (i == nums2[j])
                        {
                            
                            temp[k] = i;
                            k++;
                            //remove element
                            int index = Array.IndexOf(nums2, nums2[j]);
                            nums2 = nums2.Where((e, i) => i != index).ToArray();
                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }
                    j = 0;
                }
                foreach (var item in temp)
                {
                    if (item != 0)
                    {
                        Console.WriteLine(item.ToString());
                    }
                   
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error in intersection");
                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                int min = 0;
                int max = nums.Length - 1;
                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (target == nums[mid])
                    {
                        return ++mid;
                    }
                    else if (target < nums[mid])
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }
                
                }

                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                IDictionary<int, int> numberNames = new Dictionary<int, int>();
                for(int i = 0; i < nums.Length; i++)
                {
                    int result;
                    if (numberNames.TryGetValue(nums[i], out result))
                    {
                        numberNames[nums[i]] = result + 1;
                        
                    }
                    else
                    {
                        numberNames.Add(nums[i], 1);
                    }
                }
                int max = -1;
                foreach(var i in numberNames)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", i.Key, i.Value);
                    if (i.Key > max && i.Key==i.Value)
                    {
                        max = i.Key;

                    }
                }
                //write your code here.
                return max;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {
            try
            {
                //write your code here.
                int maximum = 0;
                int[] nums = new int[n + 1];
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == 0)
                        nums[i] = 0;
                    else if (i == 1)
                        nums[1] = 1;
                    else if (i % 2 == 0)
                        nums[i] = nums[i / 2];
                    else if (i % 2 != 0)
                        nums[i] = nums[(i - 1) / 2] + nums[(i + 1) / 2];



                }
                foreach (int j in nums)
                {
                    if (maximum < j)
                        maximum = j;
                }
                return maximum;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                string word = paths[0][1];
                int i = 1;
                List<List<string>> tempList = new List<List<string>>();
                while (paths.Count>i)
                {
                    if (word == paths[i][0])
                    {
                        word = paths[i][1];
                    }
                    else
                    {
                        tempList.Add(paths[i]);
                        i++;
                    }
                }
                int j = 0;
                while (true)
                {
                    if (tempList[j][0] == word)
                    {
                        j = 0;
                        word = tempList[j][1];
                    }else if (j == tempList.Count - 1)
                    {
                        break;
                    }
                    else 
                    {
                        j++;
                    }
                }
                return word;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                //write your code here.
                for(int i = 0; i < nums.Length-1; i++)
                {
                    if (nums[i] + nums[i + 1] == target)
                    {
                        Console.WriteLine(nums[i].ToString()+" "+nums[i + 1]);
                    }
                }
                Console.WriteLine("Not FOund");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                //write your code here.

                IDictionary<int, int> count = new Dictionary<int, int>();
                bool boolean= true;
                var temp=-1;
                foreach (var i in items)
                {
                    if (boolean) {
                        int result;
                        temp = i;
                        if (count.TryGetValue(i, out result))
                        {
                            count[i] = result;

                        }
                        else
                        {
                            count.Add(i, 0);
                        }
                        boolean = false;
                    }
                    else
                    {
                        int result2;
                        if (count.TryGetValue(temp, out result2))
                        {
                            count[temp] = result2 + i;
                        }
                        boolean = true;
                    }
                    
                    
                }
                foreach (var i in count)
                {
                    
                    int result3;
                    if (count.TryGetValue(i.Key, out result3))
                    {
                        Console.WriteLine("Key: {0}, Value: {1}", i.Key, result3/5);

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                //write your code here.
                while (n > 0)
                {
                    int last = arr[arr.Length - 1];
                    arr = arr.SkipLast(1).ToArray();
                    arr = new int[] { last }.Concat(arr).ToArray();
                    n -= 1;
                }
                foreach(int i in arr)
                {
                    Console.WriteLine(i);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr)
        {
            try
            {
                //write your code here.
                int max = arr[0];
                int currentMax = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    currentMax = System.Math.Max((currentMax + arr[i]), arr[i]);
                    max = System.Math.Max(max, currentMax);
                }

                return max;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                //write your code here.
                int fCost1 = costs[0];
                int fCost2 = costs[1];
                int currentCost = 0;
                for (int i = 2; i < costs.Length; i++)
                {
                    currentCost = costs[i] + Math.Min(fCost1, fCost2);
                    fCost1 = fCost2;
                    fCost2 = currentCost;
                }
                return Math.Min(fCost1, fCost2);
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
//it took me around 4 hours to finish this assignment.
//what is they are pretty much easy but c# is consuming time to solve them.
//My recomendation would be to try new problems which are completely new to people.
