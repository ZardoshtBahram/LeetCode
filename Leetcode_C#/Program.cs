using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Leetcode_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] array2 = { 12, 45, 78, 34, 56, 89 };

            int[] candidates = { 16, 17, 71, 62, 12, 24, 14 };
            Console.WriteLine(LargestCombination(candidates));
            
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
  
        // 2938 Oct 15, 2024
        public static long MinimumSteps(string s)
        {
            long sawp = 0;
            long blockofones = 0;

            foreach (char item in s)
            {
                if (item == '0')
                    sawp += blockofones;
                
                else
                    blockofones++;
            }

            return sawp;
        }

        // 1405 Oct 16, 2024
        public static string LongestDiverseString(int a, int b, int c)
        {
            string result = "";

            if (a > b && a > c)
            {
                if (a > (b + c + 1) * 2)
                    a = (b + c + 1) * 2;

                result += "aa";
                a -= 2; 
            }
            else if (b > a && b > c)
            {
                if (b > (a + c + 1) * 2)
                    b = (a + c + 1) * 2;

                result += "bb";
                b -= 2;
            }
            else if (c > a && c > b)
            {
                if (c > (b + a + 1) * 2)
                    c = (b + a + 1) * 2;

                result += "cc";
                c -= 2;
            }



            while (a > 0 || b > 0 || c > 0)
            {

                if (a > b)
                {
                    if (b > c)
                    {
                        // a max
                        // b second

                        if (result[result.Length - 1] != 'a' && result[result.Length - 2] != 'a')
                        {
                            result += 'a';
                            a--;
                        }
                        else 
                        {
                            result += 'b';
                            b--;
                        }

                    }
                    else if (a > c)
                    {
                        // a max
                        // c second

                        if (result[result.Length - 1] != 'a' && result[result.Length - 2] != 'a')
                        {
                            result += 'a';
                            a--;
                        }
                        else
                        {
                            result += 'c';
                            c--;
                        }
                    }
                    else
                    {
                        // c max 
                        // a second

                        if (result[result.Length - 1] != 'c' && result[result.Length - 2] != 'c')
                        {
                            result += 'c';
                            c--;
                        }
                        else
                        {
                            result += 'a';
                            a--;
                        }
                    }
                }
                else
                {
                    if (a > c)
                    {
                        // b max
                        // a second
                        if (result[result.Length - 1] != 'b' && result[result.Length - 2] != 'b')
                        {
                            result += 'b';
                            b--;
                        }
                        else
                        {
                            result += 'a';
                            a--;
                        }
                    }
                    else if (b > c)
                    {
                        // b max
                        // c second
                        if (result[result.Length - 1] != 'b' && result[result.Length - 2] != 'b')
                        {
                            result += 'b';
                            b--;
                        }
                        else
                        {
                            result += 'c';
                            c--;
                        }
                    }
                    else
                    {
                        // c max 
                        // b second
                        if (result[result.Length - 1] != 'c' && result[result.Length - 2] != 'c')
                        {
                            result += 'c';
                            c--;
                        }
                        else
                        {
                            result += 'b';
                            b--;
                        }
                    }
                }

            }

            return result;
        }

        // 1957 Nov 1, 2024
        public static string MakeFancyString(string s)
       {

            //for (int i = 2; i < s.Length; i++) 
            //{
            //    if (s[i] == s[i - 1] && s[i] == s[i - 2]) 
            //    {
            //        int j = i;
            //        while (s[i] == s[j]) 
            //        {
            //            j++;
            //            if (s.Length == j)
            //                break;
            //        }
            //        s = s.Remove(i,j-i);


            //    }
            //}




            //for (int i = 0; i < s.Length-2; i++) 
            //{

            //    if (s[i] == s[i + 1] && s[i] == s[i + 2]) 
            //    {
            //        int j = i + 2;
            //        while (s[i] == s[j])
            //        {
            //            j++;
            //            if (s.Length == j)
            //                break;
            //        }
            //        s = s.Remove(i, j - i - 2);

            //    }


            //}


            //string result = "";
            //bool flag = false;


            //for (int i = 0; i < s.Length - 2; i++) 
            //{
            //    if (s[i] == s[i + 1] && s[i] == s[i + 2])
            //    {
            //        int j = i + 2;
            //        while (s[i] == s[j])
            //        {
            //            j++;
            //            if (s.Length == j) 
            //            {
            //                flag = true; 
            //                break;
            //            }

            //        }
            //        i += j - i - 2;
            //    } 

            //    result += s[i];
            //}

            //if (!flag) 
            //    result += s[s.Length - 2];


            //result += s[s.Length - 1];

                var result = new System.Text.StringBuilder();
                foreach (char c in s)
                {
                    int len = result.Length;
                    if (len >= 2 && result[len - 1] == c && result[len - 2] == c)
                    {
                        continue;
                    }
                    result.Append(c);
                }
                return result.ToString();
         

       }

        //2275 Nov 7, 2024
        public static int LargestCombination(int[] candidates)
        {
            int maxBitwise = -1;
            int size = 0;

            if (candidates.Length > 1)
            {
                for (int i = 0; i < candidates.Length; i++)
                {
                    for (int j = i + 1; j < candidates.Length; j++)
                    {
                        int thisbitwise = candidates[j];
                        //calculating the bitwise
                        for (int x = i; x <= j; x++)
                        {
                            thisbitwise &= candidates[x];
                        }

                        if (thisbitwise >= maxBitwise) 
                        {
                            maxBitwise = thisbitwise;
                            if ((j - i + 1) >= size)
                                size = (j - i + 1);
                        }
                    }
                }
            }

            return size;

        }

    }
}


