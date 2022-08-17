using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays_Hashing
{
    public class Problems
    {
        // Statement: 
        // Link: 
        // Tips:

        #region EASY
        public bool ContainsDuplicate(int[] nums)
        {
            // Statement: 217. Contains Duplicate
            // Link: https://leetcode.com/problems/contains-duplicate/
            // Tips: hashset to get unique values in array, to check for duplicates easily

            HashSet<int> hashset = new HashSet<int>();

            foreach (var num in nums)
            {
                if(hashset.Contains(num))
                    return true;

                hashset.Add(num);
            }
            return false;
        }
        public bool Anagram(string s,  string t)
        {
            // Statement: 242. Valid Anagram
            // Link: https://leetcode.com/problems/valid-anagram/
            // Tips: Dictionary to count each char in str1, decrement for str2;

            if(s.Length != t.Length)
                return false;

            // ------------------------------------------------ Approach - 01 -----------------------------------------------
            string s1 = new string(s.OrderBy(c => c).ToArray());
            string t1 = new string(t.OrderBy(c => c).ToArray());

            for (int i = 0; i < s.Length; i++)
            {
                if (s1[i] != t1[i])
                    return false;
            }
            return true;
            // ------------------------------------------------ Approach - 01 -----------------------------------------------


            //// ------------------------------------------????? Approach - 02 ?????------------------------------------------

            //Dictionary<char, int> string1_Dict = new Dictionary<char, int>();
            //Dictionary<char, int> string2_Dict = new Dictionary<char, int>();

            //foreach (char c in s)   
            //    if(!string1_Dict.ContainsKey(c))
            //        string1_Dict.Add(c, 1);

            //foreach (char c in t)
            //    if (!string2_Dict.ContainsKey(c))
            //        string2_Dict.Add(c, 1);

            //// check keys are the same
            //foreach (char k in string1_Dict.Keys)
            //    if (!string2_Dict.ContainsKey(k))
            //        return false;

            //// check values are the same
            //foreach (char k in string1_Dict.Keys)
            //    if (!string1_Dict[k].Equals(string2_Dict[k]))
            //        return false;

            //return true;

            //// ------------------------------------------------ Approach - 02 -----------------------------------------------
        }
        public int[] TwoSum(int[] nums, int target)
        {
            // Statement: 1. Two Sum
            // Link: https://leetcode.com/problems/two-sum/
            // Tips: Dictionary 

            Dictionary<int, int> NumsDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var FindSecondNumberToAdd = target - nums[i];
                if (NumsDict.ContainsKey(FindSecondNumberToAdd))
                {
                    return new int[] { NumsDict[FindSecondNumberToAdd], i };
                }
                NumsDict[nums[i]] = i;
            }
            return new int[] { };
        }
        public bool IsPalindrome(string s)
        {
            // Statement: 125. Valid Palindrome
            // Link: https://leetcode.com/problems/valid-palindrome/
            // Tips: character matching from left and right side

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left])) // skip character other than alphanumeric from left side
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right])) // skip character other than alphanumeric from right side
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right])) // character matching from left and right side
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
            }
            return true;
        }
        public bool IsValidParenthesis(string s)
        {
            // Statement: 20. Valid Parentheses
            // Link: https://leetcode.com/problems/valid-parentheses/
            // Tips: 

            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>()
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{'
            };

            foreach (char c in s)
            {
                if (!pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
        public int MaxProfit(int[] prices)
        {
            // Statement: 121. Best Time to Buy and Sell Stock
            // Link: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
            // Tips:

            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int currPrice = prices[i];
                minPrice = Math.Min(minPrice, currPrice);
                maxProfit = Math.Max(maxProfit, currPrice - minPrice);
            }
            return maxProfit;
        }
        public int BinarySearch(int[] nums, int target)
        {
            // Statement: 704. Binary Search 
            // Link: https://leetcode.com/problems/binary-search/
            // Tips:

            int left = 0, right = nums.Length - 1;

            while(left <= right)
            {
                int mid = left + ((right - left) / 2);

                if (nums[mid] == target)
                    return mid;

                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }

        #endregion

        #region MEDIUM
        #endregion

        #region HARD

        // Contest 306 - HARD
        public int CountSpecialNumbers(int n)
        {
            List<int> list = new List<int>();
            int total = 0, count=0;

            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                total = countRepeatingDigits(list[i]);

                if (total > 0)
                    count++;
            }

            return n-count;
        }

        static int countRepeatingDigits(int N)
        {
            // Initialize a variable to store
            // count of Repeating digits
            int res = 0;

            // Initialize cnt array to
            // store digit count
            int[] cnt = new int[10];

            // Iterate through the digits of N
            while (N > 0)
            {

                // Retrieve the last digit of N
                int rem = N % 10;

                // Increase the count of digit
                cnt[rem]++;

                // Remove the last digit of N
                N = N / 10;
            }

            // Iterate through the cnt array
            for (int i = 0; i < 10; i++)
            {

                // If frequency of digit
                // is greater than 1
                if (cnt[i] > 1)
                {

                    // Increment the count
                    // of Repeating digits
                    res++;
                }
            }

            // Return count of repeating digit
            return res;
        }
        #endregion
    }
}
