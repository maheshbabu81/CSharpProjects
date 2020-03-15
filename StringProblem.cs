using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AlgorithmConsole
{
    public class StringProblem
    {
        public int LongestStringWithoutRepeatingCharaacters(string s)
        {
            int start = 0, maxLength = 0;
            // Logic is we would maintain the dictionary with key as character and value as index.
            // we increment the endindex as long as char is not found in dictionary.
            // if we found the char in dic ,
            // 1) we reset the start index to dictinary value +1 
            // 2) update the dictinary to current index. AND
            // 3) Calculate the maxlength

            Dictionary<char, int> charIndex = new Dictionary<char, int>();
            for(int i =0; i<s.Length; i++)
            {
                if(charIndex.ContainsKey(s[i]))
                {
                    int length = (i - start);// start - (i-1). but due to zero index we need add one more
                    if(length > maxLength)
                    {
                        maxLength = length;
                    }
                    start = charIndex[s[i]] + 1;
                    charIndex[s[i]] = i;
                }
                else
                {
                    charIndex.Add(s[i], i);
                    
                }
            }

            if(maxLength < (s.Length-start))
            {
                maxLength = s.Length - start;
            }
            return maxLength;
        }

        public bool ValidAnagrams(string s1, string s2)
        {
            // given all are alphabetic characters, we create a hash code for each string with character followed by
            // number of occurrence. characters are sorted by alphabetic order.

            // if the hashcode matches of two string then strings are anagrams.
            if(!s1.Length.Equals(s2.Length))
            {
                return false;
            }

            string hashCode1 = GenerateHashCode(s1);
            string hashCode2 = GenerateHashCode(s2);
            
            return hashCode1.Equals(hashCode2);

        }

        private string GenerateHashCode(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for(int i = 0; i< s.Length; i++)
            {
                if(dict.ContainsKey(s[i]))
                {
                    dict[s[i]] = dict[s[i]] + 1;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }

            string hashcode = string.Empty;
            for(int i = 97; i<=122; i++)
            {
                char ch = (char)i;
                if(dict.ContainsKey(ch))
                {
                    hashcode += ch + dict[ch].ToString();
                }
            }
            return hashcode;
        }

        public string FrequencySort(string s)
        {
            Dictionary<char, int> freqIndex = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (freqIndex.ContainsKey(s[i]))
                {
                    freqIndex[s[i]] = freqIndex[s[i]] + 1;
                }
                else
                {
                    freqIndex.Add(s[i], 1);
                }
            }


            StringBuilder result = new StringBuilder();
            
            foreach (KeyValuePair<char, int> pair in freqIndex.OrderByDescending(p => p.Value))
            {

                for (int i = 0; i < pair.Value; i++)
                    result.Append(pair.Key);
            }
            return result.ToString();
        }
    }

    /*
     * public ListNode MergeLinkedList(ListNode l1, ListNode l2)
     * {
     *    if(l1 == null) return l2;
     *    if(l2 == null) return l1;
     *    if(l1 == null && l2== null) return null;
     *    ListNode head = null;
     *    if(l1.val > l2.val)
     *    {
     *      head = l2;
     *      l2.next = MergeLinkedList(l1, l2.next);
     *     }
     *     else
     *     {
     *        head = l1;
     *        l1.next = MergeLinkedList(l1.next, l2);
     *     }
     *     return head;
     * }
     */
}
