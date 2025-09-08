using CodeMonkey.CSharpCourse.L1500_Projects;

namespace CodeMonkey.CSharpCourse.L1600_PasswordGenerator {

    public class PasswordGenerator_Done {


        /* ** Password Generator **
         * Generate weak and strong passwords
         * 
         * Weak is just random characters
         * Strong is multiple random words with symbols between them
         * */
        public PasswordGenerator_Done() {
            Console.WriteLine("Generating password...");

            string alphabet = "abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZ0123456789_!#$%&";

            string weakPassword = "";
            int passwordLength = 6;
            for (int i = 0; i < passwordLength; i++) {
                weakPassword += alphabet[GenerateRandomNumber(alphabet.Length)];
            }

            Console.WriteLine("<color=#ffff00>Weak Password:</color> " + weakPassword);


            string[] wordArray = new []{ 
                "code",
                "monkey",
                "correct",
                "horse",
                "battery",
                "staple",
                "unity",
                "game",
                "development",
                "aragorn",
                "good",
                "bad",
                "mumble",
                "snooze",
                "cheese",
                "butter",
                "pizza",
                "steak",
                "dinossaur",
                "naruto",
                "goku",
                "kakashi",
                "vegeta",
                "wallet",
                "smartphone",
                "keys",
                "volkswagen",
                "ferrari"
            };
            string strongPassword = "";

            int passwordWordCount = 5;
            for (int i = 0; i < passwordWordCount; i++) {
                strongPassword += wordArray[GenerateRandomNumber(wordArray.Length)];
            }

            int underscoreCount = GenerateRandomNumber(3);
            for (int i = 0; i < underscoreCount; i++) {
                int randomIndex = GenerateRandomNumber(strongPassword.Length);
                strongPassword = strongPassword.Substring(0, randomIndex) + '_' + strongPassword.Substring(randomIndex);
            }

            Console.WriteLine("<color=#00ff00>Strong Password:</color> " + strongPassword);
        }

        private int GenerateRandomNumber(int maxExclusive) {
            // Generates a random number between 0 (include) and maxExclusive (exclusive)
            return new System.Random().Next(maxExclusive);
        }

    }

}