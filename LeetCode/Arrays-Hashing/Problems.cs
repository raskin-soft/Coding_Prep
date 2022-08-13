using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays_Hashing
{
    public class Problems
    {
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


            //// ------------------------------------------xxxxx Approach - 02 xxxxx------------------------------------------

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
                var FindFirstNumberToAdd = target - nums[i];
                if (NumsDict.ContainsKey(FindFirstNumberToAdd))
                {
                    return new int[] { NumsDict[FindFirstNumberToAdd], i };
                }
                NumsDict[nums[i]] = i;
            }
            return new int[] { };
        }
        #endregion

        #region MEDIUM
        #endregion

        #region HARD
        #endregion
    }
}
