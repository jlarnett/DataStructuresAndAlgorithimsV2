using System;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nemo = {"nemo"};

            FindNemo(nemo);
        }

        public static void FindNemo(string[] array)
        {
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "nemo")
                {
                    Console.WriteLine("Found Nemo");
                }
            }
        }
    }
}
