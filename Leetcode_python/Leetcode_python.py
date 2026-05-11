class Solution:
    
    def lengthOfLastWord(self, s: str) -> int:
        arry = s.split()
        size = len(arry)
        return len(arry[size -1])

Sol = Solution()
result = Sol.lengthOfLastWord("   fly me   to   the moon  ")
print(result)   

            
class Solution:
    def separateDigits(self, nums: List[int]) -> List[int]:
        result_arr = []
        for i in nums:
            num_arr = []
            while i > 0:
                num_arr.insert(0,i%10)
                i = i//10
            result_arr += num_arr
        return result_arr
