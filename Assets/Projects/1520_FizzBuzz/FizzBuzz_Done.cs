using CodeMonkey.CSharpCourse.L1500_Projects;

namespace CodeMonkey.CSharpCourse.L1520_FizzBuzz {

    public class FizzBuzz_Done {


        /* ** Fizz Buzz **
         * 
         * Loop through Numbers 1-100
         * If Divisible by 3, print Fizz
         * If Divisible by 5, print Buzz
         * If Divisible by 3 AND 5, print FizzBuzz
         * Every other case, print Number
         * 
         * Hint: Use the % modulo operator to get the remainder of the division
         * (6 % 3) == 0
         */
        public FizzBuzz_Done() {
            for (int i = 1; i <= 100; i++) {
                if (i % 3 == 0 && i % 5 == 0) {
                    Console.WriteLine("FizzBuzz");
                } else {
                    if (i % 3 == 0) {
                        Console.WriteLine("Fizz");
                    } else {
                        if (i % 5 == 0) {
                            Console.WriteLine("Buzz");
                        } else {
                            Console.WriteLine(i);
                        }
                    }
                }
                
            }
        }

    }

}