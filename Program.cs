using System;
using System.Reflection.Metadata;

namespace Capeston_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string piglatin = ""; string[] newStentence = { }; string piglatinFinal = "";
            bool capital = false; string cont = "y"; bool containsNumberEmail = false;

            while (cont == "y")
            {
                piglatinFinal = "";
                string sentence = Get("Enter a line to be translated: ");

                //1 Point: Check that the user has actually entered text before translating
                while (sentence.Length < 1)
                {
                    sentence = Get("INVALID ENTRY\nEnter a line to be translated: ");
                }

                string[] words = sentence.Split();

                foreach (string word in words)
                {
                    int index = FindVowel(word);

                    //1 Point: Don’t translate words that have numbers or symbols. Ex: 189 should be left as 189 and hello@grandcircus.co should be left as hello@grandcircus.co.
                    containsNumberEmail = DoesItContainNumberEmail(word);
  

                    //Input validation. For example, 'c' or 'd'. index will be -1 and the program will crash
                    if (index == -1 && !containsNumberEmail)
                    {
                        bool inValidEntry = true;
                        while (inValidEntry)
                        {
                            Console.WriteLine("Invalid Entry, Try again");
                            inValidEntry = false;
                            break;
                        }
                        break;
                    }

                    capital = IsFirstLetterCapital(word[0]);

                    piglatin = MakePigLatin(containsNumberEmail, index, word);

                    //1 Point: Keep the case of the word, whether its uppercase (WORD), title case (Word), or lowercase (word).
                    if (capital == true)
                    {
                        piglatin = ConvertFirstLetterToCapital(piglatin);
                    }

                    piglatinFinal += piglatin;

                }
                Console.WriteLine(piglatinFinal);

                //There is input validation. If user enters anything other than "y" or "n" it will keep
                //looping and asking him again
                cont = DoYouWantContinue("Translate another line? (y/n):");
            }


        }
        public static int FindVowel(string words)
        {
            int vowelPosition = -1;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == 'a' || words[i] == 'e' || words[i] == 'i' || words[i] == 'o' || words[i] == 'u')
                {
                    vowelPosition = i;
                    return vowelPosition;
                }
            }
            return vowelPosition;
        }
        public static bool IsFirstLetterCapital(char letter)
        {
            bool capital = false;
            if (char.IsUpper(letter))
            {
                capital = true;
            }
            return capital;
        }
        public static string ConvertFirstLetterToCapital(string str)
        {
            char[] lettersArray = str.ToCharArray();
            lettersArray[0] = char.ToUpper(lettersArray[0]);
            str = new string(lettersArray);
            return str;
        }
        public static string Get(string message)
        {
            Console.Write(message);
            string sentence = Console.ReadLine();
            return sentence;
        }
        public static string DoYouWantContinue(string str)
        {
            string input = "y"; bool condition = true;

            while (condition)
            {
                Console.Write(str);
                input = Console.ReadLine().ToLower();

                if (input == "y" || input == "n")
                {
                    condition = false;
                }
            }
            return input;

        }
        public static bool DoesItContainNumberEmail (string str)
        {
            bool containsNumberEmail = false;
            char[] numbersAndEmail = "1234567890@".ToCharArray();
            foreach (char item in numbersAndEmail)
            {
                if (str.Contains(item))
                {
                    containsNumberEmail = true;
                    break;
                }
                else containsNumberEmail = false;
            }
            return containsNumberEmail;
        }
        public static string MakePigLatin (bool ContainsNumberOrEmail, int index, string str)
        {
            string contains =""; string piglatin = "";
            if (ContainsNumberOrEmail)
            {
                contains = "true";
            }
            String wordLowerCase = str.ToLower();

            if (contains == "true")
            {
                piglatin = wordLowerCase + " ";
            }
            else if (index == 0)
            {
                piglatin = wordLowerCase + "way" + " ";
            }

            else
            {
                string secondConsonant = wordLowerCase.Substring(index);
                string firstConsonant = wordLowerCase.Substring(0, index);
                piglatin = secondConsonant + firstConsonant + "ay" + " ";
            }
            return piglatin;
        }
    }
}


