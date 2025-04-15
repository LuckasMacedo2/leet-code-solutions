using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(MaximumTime("?0:15"));
    }

    /// <summary>
    /// 2185. Counting Words With a Given Prefix
    /// </summary>
    public int PrefixCount(string[] words, string pref)
    {
        return words.Count(x => x.StartsWith(pref));
    }

    /// <summary>
    /// 2011. Final Value of Variable After Performing Operations
    /// </summary>
    public int FinalValueAfterOperations(string[] operations)
    {
        var result = 0;

        foreach (var item in operations)
            result += item.Contains("++") ? 1 : -1;

        return result;
    }

    /// <summary>
    /// 1736. Latest Time by Replacing Hidden Digits
    /// </summary>
    public static string MaximumTime(string time)
    {
        char[] timeArray = time.ToCharArray();

        if (timeArray[0] == '?')
            if(timeArray[1] > '3' && timeArray[1] != '?')
                timeArray[0] = '1';
            else
                timeArray[0] = '2';

        if (timeArray[1] == '?')
                if (timeArray[0] == '2')
                    timeArray[1] = '3';
                else
                    timeArray[1] = '9';

        if (timeArray[3] == '?')
            timeArray[3] = '5';

        if (timeArray[4] == '?')
                timeArray[4] = '9';


        return new string(timeArray);
    }

    /// <summary>
    /// 1672. Richest Customer Wealth
    /// </summary>
    public int MaximumWealth(int[][] accounts)
    {
        int maior = 0;

        for (int i = 0; i < accounts.Length; i++)
        {
            var soma = accounts[i].Sum();
            if (soma > maior)
                maior = soma;
        }

        return maior;
    }

    /// <summary>
    /// 1662. Check If Two String Arrays are Equivalent
    /// </summary>
    public static bool ArrayStringsAreEqual(string[] word1, string[] word2) => string.Join("", word1).Equals(string.Join("", word2));

    /// <summary>
    /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
    /// </summary>
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(" ");

        for (int i = 0; i < words.Length; i++)
            if (words[i].StartsWith(searchWord)) return i + 1;

        return -1;
    }

    /// <summary>
    /// 1446. Consecutive Characters
    /// </summary>
    public int MaxPower(string s)
    {
        var caracterAnterior = s[0];
        int count = 1;
        int max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if(caracterAnterior == s[i])
            {
                count++;
                if (count > max) max = count;
            }
            else
            {
                caracterAnterior = s[i];
                count = 1;
            }
        }
        return max;
    }

    /// <summary>
    /// 1437. Check If All 1's Are at Least Length K Places Away
    /// </summary>
    public bool KLengthApart(int[] nums, int k)
    {
        int count = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (count != -1 && count < k) return false;
                count = 0;
            }
            else if (count != -1) count++;
        }

        return true;
    }

    /// <summary>
    /// 1431. Kids With the Greatest Number of Candies
    /// </summary>
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        List<bool> result = new List<bool>();
        var max = candies.Max();


        foreach (var item in candies)
            result.Add(item + extraCandies >= max);
        return result;
    }

    /// <summary>
    /// 1470. Shuffle the Array
    /// </summary>
    public int[] Shuffle(int[] nums, int n)
    {
        int[] result = new int[2 * n];

        int j = 0;
        for (int i = 0; i < nums.Length / 2; i++)
        {
            result[j] = nums[i];
            j++;
            result[j] = nums[i + n];
            j ++;
        }

        return result;
    }

    /// <summary>
    /// 1491. Average Salary Excluding the Minimum and Maximum Salary
    /// </summary>
    public static double Average(int[] salary) => Math.Round((double)(salary.Sum() - salary.Min()- salary.Max()) / (salary.Length - 2), 5);

    /// <summary>
    /// 1523. Count Odd Numbers in an Interval Range
    /// </summary>
    public int CountOdds(int low, int high)
    {
        return high - (high / 2) - (low / 2);
    }

    /// <summary>
    /// 1572. Matrix Diagonal Sum
    /// </summary>
    public static int DiagonalSum(int[][] mat)
    {
        var n = mat.Length;

        var sum = 0;
        var m = n - 1;
        for (int i = 0; i < n; i++)
        {
            sum += mat[i][i] + (m != i ? mat[m][i] : 0);
            m--;
        }

        return sum;
    }

    /// <summary>
    /// 1576. Replace All ?'s to Avoid Consecutive Repeating Characters
    /// </summary>
    public string ModifyString(string s)
    {
        string charAdd = "";


        foreach (var item in s)
        {
            if(item == '?')
            {
                charAdd = "a";
                while (s.Contains(charAdd) || (s.IndexOf(charAdd) > 0 && s[s.IndexOf(charAdd) - 1] == charAdd[0]) || (s.IndexOf(charAdd) < s.Length - 1 && s[s.IndexOf(charAdd) + 1] == charAdd[0]))
                {
                    charAdd = Convert.ToChar(charAdd[0] + 1).ToString();
                }
                s = s.Replace("?", charAdd);
            }
        }

        return s;
    }

    /// <summary>
    /// 1550. Three Consecutive Odds
    /// </summary>
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        var qtdOdds = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                qtdOdds = 0;
            }
            else
            {
                qtdOdds++;
                if(qtdOdds == 3)
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 1528. Shuffle String
    /// </summary>
    public static string RestoreString(string s, int[] indices)
    {
        var result = "";
        for (int i = 0; i < s.Length; i++)
            result += s[Array.IndexOf(indices, i)];

        return result;
    }

    /// <summary>
    /// 1507. Reformat Date
    /// </summary>
    public static string ReformatDate(string date)
    {
        List<string> meses = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        string[] dataSplit = date.Split(" ");
        var mes = meses.IndexOf(dataSplit[1]) + 1;
        var dia = Convert.ToInt16(dataSplit[0].Substring(0, dataSplit[0].Length - 2));

        return $"{dataSplit[2]}-{(mes < 10 ? mes.ToString("D2") : mes.ToString())}-{(dia < 10 ? dia.ToString("D2") : dia.ToString())}";
    }

    /// <summary>
    /// 1480. Running Sum of 1d Array
    /// </summary>
    public static int[] RunningSum(int[] nums)
    {
        var numsSum = new int[nums.Length];
        var sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            numsSum[i] = sum;
        }
        return numsSum;
    }

    /// <summary>
    /// 1360. Number of Days Between Two Dates
    /// </summary>
    public static int DaysBetweenDates(string date1, string date2) => Math.Abs((DateTime.Parse(date2) - DateTime.Parse(date1)).Days);

    /// <summary>
    /// 1295. Find Numbers with Even Number of Digits
    /// </summary>
    public int FindNumbers(int[] nums)
    {
        var count = 0;

        foreach (var n in nums)
            count += n.ToString().Length % 2 == 0 ? 1 : 0;

        return count;
    }

    /// <summary>
    /// 1281. Subtract the Product and Sum of Digits of an Integer
    /// </summary>
    public static int SubtractProductAndSum(int n)
    {
        int sum = 0;
        int multiply = 1;

        while(n > 0)
        {
            int digit = n % 10;
            sum += digit;
            multiply *= digit;
            n /= 10;
        }

        return multiply - sum;
    }

    /// <summary>
    /// 1309. Decrypt String from Alphabet to Integer Mapping
    /// </summary>
    public static string FreqAlphabets(string s)
    {
        string resultado = "";
        const string ESCAPE_CARACTER = "#";

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if(s[i] == ESCAPE_CARACTER[0])
            {
                resultado += (char)(int.Parse(s.Substring(i - 2, 2)) + 96);
                i -= 2;
            }
            else
            {
                resultado += (char)(int.Parse(s[i].ToString()) + 96);
            }
        }

        return new string(resultado.Reverse().ToArray());
    }

    /// <summary>
    /// 1009. Complement of Base 10 Integer
    /// </summary>
    public static int BitwiseComplement(int n)
    {
        if (n == 0) return 1;
        return FindComplement(n);
    }

    /// <summary>
    /// 905. Sort Array By Parity
    /// </summary>
    public static int[] SortArrayByParityII(int[] nums)
    {
        var impar = new int[nums.Length / 2];
        var par = new int[nums.Length / 2];


        int idxPar = 0;
        int idxImpar = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                par[idxPar] = nums[i];
                idxPar++;
            }
            else
            {
                impar[idxImpar] = nums[i];
                idxImpar++;
            }
        }

        par = par.OrderBy(x => x).ToArray();
        impar = impar.OrderBy(x => x).ToArray();

        idxPar = 0;
        idxImpar = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0)
            {
                nums[i] = par[idxPar];
                idxPar++;
            }
            else
            {
                nums[i] = impar[idxImpar];
                idxImpar++;
            }
        }

        return nums;

    }

    /// <summary>
    /// 905. Sort Array By Parity
    /// </summary>
    public static int[] SortArrayByParity(int[] nums)
    {
        int idxUltimoPar = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] % 2 == 0)
            {
                var a = nums[idxUltimoPar];
                nums[idxUltimoPar] = nums[i];
                nums[i] = a;
                idxUltimoPar++;
            }
        }

        return nums;
    }

    /// <summary>
    /// 896. Monotonic Array
    /// </summary>
    public static bool IsMonotonic(int[] nums)
    {
        short direcao = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if(MonotoneIncrease(nums[i], nums[i + 1]))
            {
                if (direcao == 0)
                {
                    direcao = 1;
                }
                else if (direcao == -1)
                {
                    return false;
                }
            }
            else if (MonotoneDecrease(nums[i], nums[i + 1]))
            {
                if (direcao == 0)
                {
                    direcao = -1;
                }
                else if (direcao == 1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool MonotoneIncrease(int numI, int numJ)
    {
        return numI < numJ;
    }

    public static bool MonotoneDecrease(int numI, int numJ)
    {
        return numI > numJ;
    }

    /// <summary>
    /// 830. Positions of Large Groups
    /// </summary>
    public static IList<IList<int>> LargeGroupPositions(string s)
    {
        var result = new List<IList<int>>();
        var caracterAtual = s[0];
        var qtdCaracteresAtual = 0;
        var iInicioPalavraAtual = 0;
        for (int i = 0; i < s.Length; i++, qtdCaracteresAtual++)
        {
            if (caracterAtual != s[i])
            {
                caracterAtual = s[i];
                if (qtdCaracteresAtual >= 3)
                {
                    result.Add(new List<int> { iInicioPalavraAtual, i - 1 });
                }
                qtdCaracteresAtual = 0;
                iInicioPalavraAtual = i;
            }
        }

        if(qtdCaracteresAtual >= 3) result.Add(new List<int> { iInicioPalavraAtual, s.Length - 1 });

        return result;
    }

    /// <summary>
    /// 868. Binary Gap
    /// </summary>
    public static int BinaryGap(int n)
    {
        var nStr = Convert.ToString(n, 2);
        int dist = 0;

        List<int> numsI = new List<int>();

        for (int i = 0; i < nStr.Length; i++)
        {
            if(nStr[i] == '1')
                numsI.Add(i);
        }

        for (int i = 0; i < numsI.Count() - 1; i++)
        {
            int distAtual = numsI[i + 1] - numsI[i];
            if (distAtual > dist)
                dist = distAtual;
        }

        return dist;
    }

    /// <summary>
    /// 557. Reverse Words in a String III
    /// </summary>
    public static string ReverseWords(string s)
    {
        var words = s.Split(" ");
        var result = new List<string>();

        foreach (var word in words)
        {
            result.Add(new string(word.Reverse().ToArray()));
        }

        return string.Join(" ", result);
    }

    /// <summary>
    /// 520. Detect Capital
    /// </summary>
    public static bool DetectCapitalUse(string word)
    {
        if (word.Equals(word.ToUpperInvariant())) return true;

        if (word.Equals(word.ToLower())) return true;

        if(word.Length > 1)
            if ((word[0].ToString().ToUpperInvariant() + word.Substring(1, word.Length - 1).ToLowerInvariant()).Equals(word)) return true;

        return false;
    }

    /// <summary>
    /// 504. Base 7
    /// </summary>
    public static string ConvertToBase7(int num)
    {
        if(num == 0) return "0";
        const short BASE = 7;
        int numBase = 0;
        string resultado = "";

        int sinal = 1;
        if(num < 0)
        {
            sinal = -1;
            num *= -1;
        }

        while (num > 0)
        {
            numBase = (num % BASE); 
            num /= BASE;
            resultado += Convert.ToString(numBase);
        }

        resultado = string.Join("", resultado.Reverse());

        if (sinal == -1)
        {
            resultado = $"-{resultado}";
        }

        return resultado;
    }

    /// <summary>
    /// 476. Number Complement
    /// </summary>
    public static int FindComplement(int num)
    {
        int binario = 0;
        double resultado = 0;
        int i = 0;
        while (num > 0)
        {
            binario = (num % 2); // Pega o bit menos significativo e adiciona na frente
            num /= 2; // Divide por 2
            resultado += (1 - binario) * Math.Pow(2, i);
            i++;
        }

        return Convert.ToInt32(resultado);
    }

    /// <summary>
    /// 283. Move Zeroes
    /// </summary>
    public static void MoveZeroes(int[] nums)
    {
        var qtdZero = nums.Count(x => x == 0);
        nums = nums.Where(x => x != 0).ToArray();
        nums = nums.Concat(Enumerable.Repeat(0, qtdZero)).ToArray();
    }

    /// <summary>
    /// 342. Power of Four
    /// </summary>
    public bool IsPowerOfFour(int n)
    {
        return Math.Log(n) / Math.Log(4) % 1 == 0;
    }

    /// <summary>
    /// 367. Valid Perfect Square
    /// </summary>
    public static bool IsPerfectSquare(int num)
    {
        return Math.Sqrt(num) % 1 == 0;
    }

    /// <summary>
    /// 412. Fizz Buzz
    /// </summary>
    public static IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if(i % 3 == 0 && i % 5 == 0)
            {
                result.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                result.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                result.Add("Buzz");
            }
            else
            {
                result.Add(i.ToString());
            }
        }

        return result;
    }

    /// <summary>
    /// 415. Add Strings - No complete
    /// </summary>
    public static string AddStrings(string num1, string num2)
    {        
        return (Convert.ToUInt64(num1) + Convert.ToUInt64(num2)).ToString();
    }

    /// <summary>
    /// 434. Number of Segments in a String
    /// </summary>
    public static int CountSegments(string s)
    {
        return s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>
    /// 448. Find All Numbers Disappeared in an Array
    /// </summary>
    public static IList<int> FindDisappearedNumbers(int[] nums)
    {
        var r = new List<int>();
        for (int i = 1; i <= nums.Length; i++)
        {
            if(!nums.Contains(i))
            {
                r.Add(i);
            }
        }

        return r;

    }

/// <summary>
/// 231. Power of Two
/// </summary>
public static bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }

    /// <summary>
    /// 169. Majority Element
    /// </summary>
    public static int MajorityElement(int[] nums)
    {
        return nums.GroupBy(x => x).OrderByDescending(n => n.Count()).FirstOrDefault().FirstOrDefault();
    }

    /// <summary>
    /// 136. Single Number
    /// </summary>
    public static int SingleNumber(int[] nums)
    {
        return nums.GroupBy(x => x).FirstOrDefault(n => n.Count() == 1).FirstOrDefault();
    }

    /// <summary>
    /// 125. Valid Palindrome
    /// </summary>
    public static bool IsPalindrome(string s)
    {
        var strTratada = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();
        if(string.IsNullOrEmpty(strTratada)) return true;

        return strTratada.Equals(new string(strTratada.Reverse().ToArray()));
    }

    /// <summary>
    /// 29. Divide Two Integers
    /// </summary>
    /// Not complete
    public static int Divide(int dividend, int divisor)
    {
        int resultSign = (dividend < 0) ^ (divisor < 0) ? -1 : 1;
        if(Math.Abs((long)divisor) == 1) return (int)(resultSign * Math.Abs((long)dividend));

        var count = 0;
        var val = 0;
        while(Math.Abs((long)val) <= Math.Abs((long)dividend))
        {
            count ++;
            val += divisor;
        }
        count --;

        return resultSign * count;
    }

    /// <summary>
    /// 69. Sqrt(x)
    /// </summary>
    public static int MySqrt(int x)
    {
        double value = 0;
        while (value * value <= x) {
            value++;
        };
        return Convert.ToInt32(value - 1);
    }

    /// <summary>
    /// 58. Length of Last Word
    /// </summary>
    public static int LengthOfLastWord(string s)
    {
        return s.TrimEnd().Split(" ").Last().Length;
    }

    /// <summary>
    /// 14. Longest Common Prefix
    /// </summary>
    public static string LongestCommonPrefix(string[] strs)
    {
        var minStr = strs.Min();
        var prefix = !string.IsNullOrEmpty(minStr) ? minStr[0].ToString(): "";
        for (int i = 0; i <= minStr.Length; i++)
        {
            if (strs.All(x => x.StartsWith(minStr.Substring(0, i))))
            {
                prefix = minStr.Substring(0, i);
            }
        }

        return prefix;
    }

    /// <summary>
    /// 1. Two Sum
    /// </summary>
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i ++)
        {
            
            if(map.ContainsKey(target - nums[i]))
            {
                return new int[] { map[target - nums[i]], i };
            }
            map[nums[i]] = i;
        }
        return new int[] { };

        // Brute force
        /*int[] intOrder = nums.OrderBy(x => x).ToArray();

        for (int i = 0; i < nums.Length; i ++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new int[] { i, j };
            }
        }
        return null;*/
    }

    /// <summary>
    /// 9. Palindrome Number
    /// </summary>
    public static bool IsPalindrome(int x)
    {
        return x.ToString() == new string(x.ToString().Reverse().ToArray());
    }

    /// <summary>
    /// 989. Add to Array-Form of Integer
    /// </summary>
    public static IList<int> AddToArrayForm(int[] num, int k)
    {
        int numIndex = num.Length - 1;
        int resto = 0;
        IList<int> result = new List<int>();

        while(numIndex >= 0 || k > 0 || resto > 0)
        {
            resto += (numIndex >= 0 ? num[numIndex] : 0) + (k % 10);
            result.Add(resto % 10);
            resto /= 10;
            k /= 10;
            numIndex--;
        }

        return result.Reverse().ToList();
    }
}
