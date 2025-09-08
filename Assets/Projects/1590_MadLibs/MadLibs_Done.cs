using CodeMonkey.CSharpCourse.L1500_Projects;

namespace CodeMonkey.CSharpCourse.L1590_MadLibs {

    public class MadLibs_Done {


        /* ** MadLibs **
         * 
         * Ask Player for various words like Adjective,
         * Noun, Verb, Noise, etc.
         * 
         * Then take those and put them inside a string to make a funny phrase
         * */
        public MadLibs_Done() {
            string adjective, animal, number, color, noise, verb, noun, exclamation, sillyObject;

            Console.WriteLine("Adjective:");
            adjective = Console.ReadLine();

            Console.WriteLine("Animal:");
            animal = Console.ReadLine();

            Console.WriteLine("Number:");
            number = Console.ReadLine();

            Console.WriteLine("Color:");
            color = Console.ReadLine();

            Console.WriteLine("Noise:");
            noise = Console.ReadLine();

            Console.WriteLine("Verb:");
            verb = Console.ReadLine();

            Console.WriteLine("Noun:");
            noun = Console.ReadLine();

            Console.WriteLine("Exclamation:");
            exclamation = Console.ReadLine();

            Console.WriteLine("SillyObject:");
            sillyObject = Console.ReadLine();

            Console.WriteLine("-");
            Console.WriteLine("Today I went to the zoo and saw a <color=#ffff00>" + adjective + "</color> alien in the <color=#ffff00>" + animal + "</color> exhibit!");
            Console.WriteLine("It had <color=#ffff00>" + number + "</color> eyes, a <color=#ffff00>" + color + "</color> body, and made a sound like <color=#ffff00>" + noise + "</color>.");
            Console.WriteLine("The alien was trying to <color=#ffff00>" + verb + "</color> when suddenly it pulled out a <color=#ffff00>" + noun + "</color> and offered it to me as a gift.");
            Console.WriteLine("I said, <color=#ffff00>\"" + exclamation + "!\"</color>");
            Console.WriteLine("Next time I visit the zoo, I’ll bring a <color=#ffff00>" + sillyObject + "</color> just in case!");
        }

    }

}