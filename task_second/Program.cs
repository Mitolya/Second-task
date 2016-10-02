using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_second
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1000000;
            int temp;
            List<int> primeCandidates = new List<int>();
            primeCandidates.Add(2); // the number 2 is always prime
            for (int i = 2; i < (N + 1) / 2; i++)//adding all odd numbers
                primeCandidates.Add(2 * i - 1);

            for (int j = 0; j < primeCandidates.Count; ++j)
            {
                // initialize first prime
                int prime = primeCandidates[j];

                //go through the multiples of the prime - 
                for (int multiple = 2; multiple * prime <= N; ++multiple)
                {                    
                    if (prime == 2)
                        break; // first prime
                    if ((multiple * prime) % 2 == 0)// if even number skip because there are no such numbers
                        continue;
                    if (!primeCandidates.Contains(multiple * prime))//skip when there are no such num
                        continue;                                        
                    primeCandidates.Remove(multiple * prime);
                }
                temp = prime;
                if (temp>10)
                {
                    while (temp != 0)
                    {
                        int val = temp % 10;

                        if ((val % 2 == 0)||(val==5))//checking if curent prime value has 0,2,4,5,6,8
                        {
                            primeCandidates.Remove(prime);
                            break;
                        }
                        temp /= 10;
                    } 
                }
            }

            for (int i = 0; i < primeCandidates.Count; i++)
            {
                if (primeCandidates[i] > 10)
                {
                    int num = primeCandidates[i];
                    for (int j = 0; j < primeCandidates[i].ToString().Length; j++)
                    {
                        num = Rotate(num, primeCandidates[i].ToString().Length);
                        
                        if (!primeCandidates.Contains(num))
                        {
                            primeCandidates.RemoveAt(i);
                            i--;
                            break;
                        }

                    }
                }
            }
            
            Console.WriteLine(@"ammount prime {0}",primeCandidates.Count);
            Console.Read();
        }

        public static int Rotate(int Num, int digit)//rotation of number
        {
            int givenNo = Num;
            int rem = (int)Num % 10;
            int first = (int)Num / 10;
            return (int)((rem * Math.Pow(10, digit - 1)) + first);
        }
    }
}

