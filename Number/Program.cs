using System;

namespace Number
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.WriteLine("请输入号码:");
                    string Numbers = Console.ReadLine();
                    string[] nums = Numbers.Split(',');
                    int[] arr = new int[nums.Length];
                    for (int i = 0; i < nums.Length; i++)
                    {
                        arr[i] = Convert.ToInt32(nums[i]);
                    }
                    int sum = 0;
                    string result = "";
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sum += arr[i];
                        if ((i + 1) % 4 == 0)
                        {
                            if (sum % 10 < 10)
                            {
                                result += sum % 10 + ",";
                            }
                            if (i == arr.Length - 1)
                            {
                                result = result.Substring(0, 9);
                            }
                            sum = 0;
                        }

                    }
                    Console.WriteLine(result);
                } while (true); 
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("录入号码有误！");
            }
        }
    }
}
