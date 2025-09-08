using CodeMonkey.CSharpCourse.L1500_Projects;
using System.Collections.Generic;

namespace CodeMonkey.CSharpCourse.L1600_PasswordGenerator {

    public class PasswordGenerator {


        /* ** Password Generator **
         * Generate weak and strong passwords
         * 
         * Weak is just random characters
         * Strong is multiple random words with symbols between them
         * */
        public PasswordGenerator() {

        }

        private int GenerateRandomNumber(int maxExclusive) {
            // Generates a random number between 0 (include) and maxExclusive (exclusive)
            return new System.Random().Next(maxExclusive);
        }

    }

}