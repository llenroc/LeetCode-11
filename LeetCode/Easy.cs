﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Easy
    {
        //https://leetcode-cn.com/problems/two-sum/description/
        #region 1. 两数之和
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] arr = new int[2];
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if(nums[j] + nums[i] == target)
                    {
                        arr[0] = i;
                        arr[1] = j;
                        break;
                    }
                }
            }
            return arr;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-integer/description/
        #region 7. 颠倒整数
        public static int Reverse(int x)
        {
            int result = 0;

            while(x != 0)
            {
                int tail = x % 10;
                int newResult = result * 10 + tail;
                if((newResult - tail) / 10 != result)
                    return 0;

                result = newResult;
                x = x / 10;
            }

            return result;
        }
        #endregion

        //https://leetcode-cn.com/problems/merge-two-sorted-lists/description/
        #region 21. 合并两个有序链表
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if(l1 == null)
                return l2;
            if(l2 == null)
                return l1;

            if(l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l2.next, l1);
                return l2;
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/remove-element/description/
        #region 27. 移除元素
        public static int RemoveElement(int[] nums, int val)
        {
            int len = nums.Length;
            int i = 0;
            while(i != len)
            {
                if(nums[i] == val)
                {
                    nums[i] = nums[len - 1];
                    len--;
                }
                else
                {
                    i++;
                }
            }

            return len;
        }
        #endregion

        //https://leetcode-cn.com/problems/length-of-last-word/description/
        #region 58. 最后一个单词的长度
        public static int LengthOfLastWord(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
                return 0;

            string str = s.TrimEnd();
            int i = str.Length - 1;
            int l = 0;
            while(i >= 0)
            {
                if(s[i--] == ' ')
                    break;
                l++;
            }
            return l;
        }
        #endregion

        //https://leetcode-cn.com/problems/sqrtx/description/
        #region 69. x 的平方根
        public static int MySqrt(int x)
        {
            if(x == 0)
                return 0;

            int left = 0;
            int right = x;
            while(true)
            {
                int middle = (right + left) / 2;
                if(middle == x / middle)
                {
                    return middle;
                }

                if(middle > x / middle)
                {
                    right = middle - 1;
                }
                else
                {
                    if(middle + 1 > x / (middle + 1))
                    {
                        return middle;
                    }
                    left = middle + 1;
                }
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/description/
        #region 111. 二叉树的最小深度
        public static int MinDepth(TreeNode root)
        {
            if(root == null)
                return 0;

            int L = MinDepth(root.left), R = MinDepth(root.right);
            return L < R && L > 0 || R < 1 ? 1 + L : 1 + R;
        }
        #endregion

        //https://leetcode-cn.com/problems/single-number/description/
        #region 136. 只出现一次的数字
        public static int SingleNumber(int[] nums)
        {
            int res = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                res ^= nums[i];
            }
            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/rotate-array/description/
        #region 189. 旋转数组
        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            Array.Reverse(nums);

            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k, nums.Length - k);
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-bits/description/
        #region 190. 颠倒二进制位
        public static uint ReverseBits(uint n)
        {
            //uint[] bits = new uint[32];
            //uint num = n;
            //int i = 0;
            //while(num > 0)
            //{
            //    uint r = num % 2;
            //    bits[i++] = r;
            //    num /= 2;
            //}
            //uint res = 0;

            //uint p = 1;
            //for(int j = bits.Length - 1; j >= 0; j--)
            //{
            //    res += (bits[j] * p);
            //    p *= 2;
            //}

            //return res;

            uint m = 0;
            for(int i = 0; i < 32; i++)
            {
                m <<= 1;
                m |= n & 1;
                n >>= 1;
            }
            return m;
        }
        #endregion

        //https://leetcode-cn.com/problems/number-of-1-bits/description/
        #region 191. 位1的个数
        public static int HammingWeight(uint n)
        {
            int c = 0;
            while(n > 0)
            {
                n &= (n - 1);
                c++;
            }
            return c;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-linked-list/description/
        #region 206. 反转链表
        public static ListNode ReverseList(ListNode head)
        {
            ListNode list = null;
            while(head != null)
            {
                var next = head.next;
                head.next = list;
                list = head;
                head = next;
            }

            return list;
        }
        #endregion

        //https://leetcode-cn.com/problems/invert-binary-tree/description/
        #region 226. 翻转二叉树
        public static TreeNode InvertTree(TreeNode root)
        {
            if(root == null)
                return null;
            var tree = root.left;
            root.left = root.right;
            root.right = tree;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
        #endregion

        //https://leetcode-cn.com/problems/power-of-two/description/
        #region 231. 2的幂
        public static bool IsPowerOfTwo(int n)
        {
            int c = 0;
            while(n > 0)
            {
                if((n & 1) == 1 && (++c > 1))
                    return false;
                n >>= 1;
            }
            return c > 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/delete-node-in-a-linked-list/description/
        #region 237. 删除链表的结点
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        #endregion

        //https://leetcode-cn.com/problems/missing-number/description/
        #region 268. 缺失数字
        public static int MissingNumber(int[] nums)
        {
            int sum = 0;
            for(int i = 0; i < nums.Length; i++)
                sum += nums[i];

            return (nums.Length * (nums.Length + 1)) / 2 - sum;
        }
        #endregion

        //https://leetcode-cn.com/problems/move-zeroes/description/
        #region 283. 移动零
        public static void MoveZeroes(int[] nums)
        {
            int i = 0;
            while(i < nums.Length)
            {
                if(nums[i] == 0)
                {
                    int total = 0;
                    for(int j = i + 1; j < nums.Length; j++)
                    {
                        total += nums[j];
                        if(nums[j] != 0)
                        {
                            int t = nums[i];
                            nums[i] = nums[j];
                            nums[j] = t;
                            break;
                        }
                    }
                    if(total == 0)
                        return;
                }
                else
                {
                    i++;
                }
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/power-of-four/description/
        #region 342. 4的幂
        public static bool IsPowerOfFour(int num)
        {
            return (((num - 1) & num) == 0) && ((num & 0x55555555) != 0);
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-string/description/
        #region 344. 反转字符串
        public static string ReverseString(string s)
        {
            char[] chars = new char[s.Length];
            int start = 0;
            int end = s.Length - 1;
            while(start <= end)
            {
                chars[start] = s[end];
                chars[end] = s[start];
                start++;
                end--;
            }
            return new string(chars);
        }
        #endregion

        //https://leetcode-cn.com/problems/sum-of-two-integers/description/
        #region 371. 两整数之和
        public static int GetSum(int a, int b)
        {
            if(b == 0)
                return a;

            int sum, carry;
            sum = a ^ b;
            carry = (a & b) << 1;
            return GetSum(sum, carry);
        }
        #endregion

        //https://leetcode-cn.com/problems/first-unique-character-in-a-string/description/
        #region 387. 字符串中的第一个唯一字符
        public static int FirstUniqChar(string s)
        {
            int[] asicii = new int['z' + 1];
            int[] chars = new int[s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if(asicii[c] == 0)
                {
                    chars[i] = c;
                    asicii[c] = i + 1;
                }
                else
                {
                    chars[asicii[c] - 1] = -1;
                }
            }

            for(int i = 0; i < chars.Length; i++)
                if(chars[i] > 0)
                    return i;

            return -1;
        }
        #endregion

        //https://leetcode-cn.com/problems/find-the-difference/description/
        #region 389. 找不同
        public static char FindTheDifference(string s, string t)
        {
            char res = default(char);
            for(int i = 0; i < s.Length; i++)
                res ^= s[i];
            for(int i = 0; i < t.Length; i++)
                res ^= t[i];

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/sum-of-left-leaves/description/
        #region 404. 左叶子之和
        public static int SumOfLeftLeaves(TreeNode root)
        {
            if(root == null)
                return 0;

            return SumLeft(root.left) + SumRight(root.right);
        }
        private static int SumLeft(TreeNode node)
        {
            if(node == null)
                return 0;

            if(node.left == null && node.right == null)
                return node.val;

            return SumLeft(node.left) + SumRight(node.right);
        }

        private static int SumRight(TreeNode node)
        {
            if(node == null)
                return 0;

            return SumLeft(node.left) + SumRight(node.right);
        }
        #endregion

        //https://leetcode-cn.com/problems/fizz-buzz/description/
        #region 412. Fizz Buzz
        public static IList<string> FizzBuzz(int n)
        {
            List<string> strs = new List<string>();

            for(int i = 1; i <= n; i++)
            {
                if(i % 3 == 0)
                {
                    if(i % 5 == 0)
                    {
                        strs.Add("FizzBuzz");
                    }
                    else
                    {
                        strs.Add("Fizz");
                    }
                }
                else if(i % 5 == 0)
                {
                    if(i % 3 == 0)
                    {
                        strs.Add("FizzBuzz");
                    }
                    else
                    {
                        strs.Add("Buzz");
                    }
                }
                else
                {
                    strs.Add(i.ToString());
                }
            }

            return strs;
        }
        #endregion

        //https://leetcode-cn.com/problems/add-strings/description/
        #region 415. 字符串相加
        public static string AddStrings(string num1, string num2)
        {
            List<char> res = new List<char>();
            int carry = 0, sum = 0;
            int n1 = 0, n2 = 0;

            int i = 1;
            while((num1.Length - i >= 0 || num2.Length - i >= 0) || carry > 0)
            {
                if(num1.Length - i >= 0)
                    n1 = num1[num1.Length - i] - '0';
                else
                    n1 = 0;

                if(num2.Length - i >= 0)
                    n2 = num2[num2.Length - i] - '0';
                else
                    n2 = 0;
                sum = n1 + n2 + carry;
                carry = sum / 10;
                sum %= 10;
                res.Insert(0, (char)(sum + '0'));
                i++;
            }

            return new string(res.ToArray());
        }
        #endregion

        //https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/description/
        #region 448. 找到所有数组中消失的数字
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            int[] arr = new int[nums.Length + 1];
            for(int i = 0; i < nums.Length; i++)
                arr[nums[i]] = nums[i];

            List<int> res = new List<int>();
            for(int i = 1; i < arr.Length; i++)
                if(arr[i] == 0)
                    res.Add(i);

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/island-perimeter/description/
        #region 463. 岛屿的周长
        public static int IslandPerimeter(int[,] grid)
        {
            int res = 0;
            int maxRow = grid.GetUpperBound(0);
            int maxCol = grid.GetUpperBound(1);
            int b, r;
            for(int row = -1; row <= maxRow; row++)
            {
                for(int col = -1; col <= maxCol; col++)
                {
                    int v = row < 0 || col < 0 ? 0 : grid[row, col];

                    b = col < 0 || row == maxRow ? 0 : grid[row + 1, col];
                    r = row < 0 || col == maxCol ? 0 : grid[row, col + 1];

                    if(v != b)
                        res++;
                    if(v != r)
                        res++;
                }
            }

            return res;
        }
        #endregion

        //https://leetcode-cn.com/problems/number-complement/description/
        #region 476. 数字的补数
        public static int FindComplement(int num)
        {
            int i = 1;

            while(i < num)
                i = i | (i << 1);

            return ~num & i;
        }
        #endregion

        //https://leetcode-cn.com/problems/keyboard-row/description/
        #region 500. 键盘行
        public static string[] FindWords(string[] words)
        {
            int[] keyMap = new int['z' - 'A' + 1];
            string row1 = "QWERTYUIOP";
            string row2 = "ASDFGHJKL";
            string row3 = "ZXCVBNM";

            InitMap(row1, keyMap, 1);
            InitMap(row2, keyMap, 2);
            InitMap(row3, keyMap, 3);
            List<string> strs = new List<string>();
            foreach(var word in words)
            {
                if(IsInOneLine(word, keyMap))
                    strs.Add(word);
            }

            return strs.ToArray();
        }
        private static void InitMap(string str, int[] keyMap, int row)
        {
            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                keyMap[c - 'A'] = row;
                keyMap[c - 'A' + 'a' - 'A'] = row;
            }
        }
        private static bool IsInOneLine(string str, int[] keyMap)
        {
            if(string.IsNullOrWhiteSpace(str))
                return false;

            if(str.Length == 1)
                return true;

            int basic = keyMap[str[0] - 'A'];
            for(int i = 1; i < str.Length; i++)
            {
                if(keyMap[str[i] - 'A'] != basic)
                    return false;
            }

            return true;
        }
        #endregion

        //https://leetcode-cn.com/problems/detect-capital/description/
        #region 520. 检测大写字母
        public static bool DetectCapitalUse(string word)
        {
            if(word.Length <= 1)
                return true;

            if(word.Length <= 2)
            {
                if(IsCaptital(word[0]))
                    return true;

                if((!IsCaptital(word[0]) && !IsCaptital(word[1])))
                    return true;

                if((IsCaptital(word[0]) && IsCaptital(word[1])))
                    return true;

                return false;
            }

            for(int i = 0; i <= word.Length - 3; i++)
            {
                if(IsCaptital(word[i]) && IsCaptital(word[i + 1]) && IsCaptital(word[i + 2]))
                    continue;

                if(!IsCaptital(word[i]) && !IsCaptital(word[i + 1]) && !IsCaptital(word[i + 2]))
                    continue;

                if(IsCaptital(word[i]) && !IsCaptital(word[i + 1]) && !IsCaptital(word[i + 2]))
                    continue;

                return false;
            }

            return true;
        }
        private static bool IsCaptital(char c)
        {
            return c - 'a' < 0;
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-string-ii/description/
        #region 541. 反转字符串 II
        public static string ReverseStr(string s, int k)
        {
            char[] str = s.ToArray();
            int l = s.Length;
            if(l == 0)
                return string.Empty;

            if(k > l)
                Swap(str, 0, l);
            else
                for(int i = 0; i < l;)
                {
                    int j = Math.Min(i + k, l);
                    Swap(str, i, j);
                    i += 2 * k;
                }

            return new string(str);
        }
        private static void Swap(char[] chars, int start, int end)
        {
            while(start < end)
            {
                char c = chars[start];
                chars[start++] = chars[--end];
                chars[end] = c;
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/description/
        #region 557. 反转字符串中的单词 III
        public static string ReverseWords(string s)
        {
            var chars = new char[s.Length];
            int start = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i].Equals(' '))
                {
                    chars[i] = ' ';
                    ReverseLetters(s, chars, start, i - 1);
                    start = i + 1;
                }
                else if(i == s.Length - 1)
                {
                    ReverseLetters(s, chars, start, s.Length - 1);
                }
            }

            return new string(chars);
        }
        private static void ReverseLetters(string s, char[] chars, int start, int end)
        {
            while(start <= end)
            {
                chars[start] = s[end];
                chars[end] = s[start];
                start++;
                end--;
            }
        }
        #endregion

        //https://leetcode-cn.com/problems/merge-two-binary-trees/description/
        #region 617. 合并二叉树
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if(t1 == null && t2 == null)
                return null;

            int v = 0;
            if(t1 != null)
                v += t1.val;
            if(t2 != null)
                v += t2.val;

            var res = new TreeNode(v);

            res.left = MergeTrees(t1 != null ? t1.left : null, t2 != null ? t2.left : null);
            res.right = MergeTrees(t1 != null ? t1.right : null, t2 != null ? t2.right : null);

            return res;
        }
        #endregion
    }
}
