using CodeMonkey.CSharpCourse.L1500_Projects;

namespace CodeMonkey.CSharpCourse.L1610_PalindromeChecker {

    public class PalindromeChecker_Done {


        /* ** Palindrome Checker **
         * 
         * Identify Palindromes
         * Word or Phrase that is the same 
         * backwards as it is forwards
         * 
         * Examples:
         * "Eve"
         * "Madam, I'm Adam"
         * "Do Geese see God?"
         * "Mr. Owl ate my metal worm."
         * "Go hang a salami, I'm a lasagna hog!"
         */
        public PalindromeChecker_Done() {
            Console.WriteLine("Input a word or phrase:");
            string line = Console.ReadLine();
            line = line.ToLower();

            string symbols = ",;:_- .?'!#$%&";
            // Remove spaces and symbols
            for (int i = 0; i < line.Length; i++) {
                if (symbols.Contains(line[i])) {
                    // Remove this one
                    line = line.Substring(0, i) + line.Substring(i + 1);
                    i--;
                }
            }

            Console.WriteLine("No Symbols: " + line);

            Console.WriteLine("Checking if it's a Palindrome...");

            for (int i = 0; i <= line.Length / 2; i++) {
                char startChar = line[i];
                char endChar = line[line.Length - i - 1];

                Console.WriteLine(startChar + " :: " + endChar);

                if (startChar != endChar) {
                    Console.WriteLine("<color=#ffff00>It's NOT a Palindrome!</color>");
                    return;
                }
            }
            Console.WriteLine("<color=#00ff00>It is a Palindrome!</color>");
        }

    }

}