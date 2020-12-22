using BankOfBitsAndBytes;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfBitsNByteAkshay
{
    class Program
    {
        static BankOfBitsNBytes bbb = new BankOfBitsNBytes();
        static int amountOfMoney = 0;
        static int MaxAcceptableCharLength { get { return BankOfBitsNBytes.acceptablePasswordChars.Length; } }
        public delegate void MyDelegate(string msg);

        public delegate void delg();
        MyDelegate del ;





        static void Main(string[] args)
        {

            MultiThredBegin();

            Console.ReadLine();

        }




        public static void MultiThredBegin( )
        {

            for (int i = 0; i <bbb.passwordLength ; i++)
            {
                
                int[] intArrayForThread = new int[bbb.passwordLength];
                ThreadStart ts = new ThreadStart( PassGeneratorForThread(i,intArrayForThread)) ;
                Thread t = new Thread(ts);
                t.Start();



            }
            
        }





       /* public static void IncrementIntArray(ref int[] toIncrese, int maxAcceptableChar)
        {
            toIncrese[toIncrese.Length - 1]++;

            for (int i = toIncrese.Length-1; i >=0 ; i--)
            {

                if (toIncrese[i] >= maxAcceptableChar)
                {
                    toIncrese[i] = 0;
                    if (i != 0)
                    {
                        toIncrese[i - 1]++;



                    }
                }

                else
                {
                    return;
                }
                    

            }

        }*/


        public static void PassGeneratorForThread(int indexOfArray, int[] toIncrese)
        {
            char[] passArray = ConvertIntToCharArrayOne(toIncrese);
            passArray[indexOfArray] = BankOfBitsNBytes.acceptablePasswordChars[toIncrese[indexOfArray]];



            Console.WriteLine("Thread : " + indexOfArray + " = " + new string(passArray));

            amountOfMoney += bbb.WithdrawMoney(passArray);


            Console.WriteLine("My Current Bankbalance :" + amountOfMoney);

            toIncrese[indexOfArray]++;

            if (toIncrese[indexOfArray] >= BankOfBitsNBytes.acceptablePasswordChars.Length)
            {
                toIncrese[indexOfArray] = 0;

            }


        }





       /* public static char[] ConvertIntToCharArray(int[] toconvert,char[] intConversionArray)
        {

            char[] toReturn = new char[toconvert.Length];
            for (int i = 0; i < toconvert.Length; i++)
            {

                toReturn[i] = intConversionArray[toconvert[i]];


            }
            return toReturn;
        }*/

        public static char[] ConvertIntToCharArrayOne(int[] toconvert)
        {

            char[] toReturn = new char[toconvert.Length];
            char[] intConversionArray = BankOfBitsNBytes.acceptablePasswordChars;
            for (int i = 0; i < toconvert.Length; i++)
            {

                toReturn[i] = intConversionArray[toconvert[i]];


            }
            return toReturn;
        }


        private static void DebugOutputCharArray(char[] toString)
        {

            Console.WriteLine(new string(toString));
        }

    }

}









/*
ThreadStart ts = new ThreadStart(MultiThredBegin); ;
Thread t = new Thread(ts);
t.Start();

int[] intArray = new int[bbb.passwordLength];
while (amountOfMoney < 5000)

{
    //char[] passGussCharArray = new char[MaxAcceptableCharLength];
    char[] passGussCharArray = ConvertIntToCharArray(intArray, BankOfBitsNBytes.acceptablePasswordChars);
    DebugOutputCharArray(passGussCharArray);

    amountOfMoney += bbb.WithdrawMoney(passGussCharArray);
    intArray[intArray.Length - 1]++;


    if (intArray[intArray.Length - 1] >= MaxAcceptableCharLength)
    {
        IncrementIntArray(ref intArray, MaxAcceptableCharLength);



    }
    MultiThredBegin(intArray);

}

Console.WriteLine("We robbed the Bank We rich now. Press any key to continue ");
Console.Read();
*/






