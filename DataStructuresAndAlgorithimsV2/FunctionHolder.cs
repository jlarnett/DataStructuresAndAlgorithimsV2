using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class FunctionHolder
    {
        public static void TwitterExerciseFunction()
        {
            //O(1) -> Time Complexity
            //Find 1st, Find Nth...

            Tweet[] array =
            {
                new Tweet() {Message = "Hi", Date = 2012},
                new Tweet() {Message = "My", Date = 2014},
                new Tweet() {Message = "Teddy", Date = 2018}

            };

            string first = array[0].Message;                            //O(1)
            string last = array[array.Length - 1].Message;              //O(1)
        }

        public class Tweet
        {
            public string Message { get; set; }
            public int Date { get; set; }
        }
    }
}
