namespace Leetcode_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
  
        public long MinimumSteps(string s)
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
    }
}
