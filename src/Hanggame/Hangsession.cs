using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanggame
{
    public class Hangsession {

        private String mysteryWord;
        private StringBuilder currentGuess;
        private List<char> previousGuesses = new List<char>();

        private const int MAX_TRIES = 6;
        private int currentTry = 0;

        private List<string> words = new List<string>();


        public Hangsession() {
            loadWords();
            for (int i = 0; i < 6; i++) {
                Console.WriteLine( DrawPicture() ); 
                currentTry++;
            }
            mysteryWord = pickWord();
            currentGuess = initializeCurrentGuess();
        }

        public string DrawPicture() {
            switch (currentTry) {
                case 0: return noPersonDraw();
                case 1: return addHeadDraw();
                case 2: return addBodyDraw();
                case 3: return addOneArmDraw();
                case 4: return addSecondArmDraw();
                default: return fullPersonDraw();

            }
        }

        private string fullPersonDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |    \\|/\n")
             + ("  |     |\n")
             + ("  |    / \\\n")
             + ("  |\n")
             + ("__|__\n");
        }

        private string addSecondArmDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |    \\|/n")
             + ("  |      |\n")
             + ("  |\n")
             + ("  |\n")
             + ("__|__\n");
        }

        private string addOneArmDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |    \\|/n")
             + ("  |\n")
             + ("  |\n")
             + ("  |\n")
             + ("__|__\n");
        }

        private string addBodyDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |    \\|/n")
             + ("  |\n")
             + ("  |\n")
             + ("  |\n")
             + ("__|__\n");
        }

        private string addHeadDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |     |\n")
             + ("  |\n")
             + ("  |\n")
             + ("  |\n")
             + ("__|__\n");
        }

        private string noPersonDraw() {
           return ("   _____\n")
            +("  |     |\n")
            +("  |     \n")
            +("  |\n")
            +("  |\n")
            +("  |\n")
            +("  |\n")
            + ("__|__\n");
        }

        private StringBuilder initializeCurrentGuess() {
            StringBuilder initial = new StringBuilder();
            for(int i = 0; i < mysteryWord.Length * 2; i++) {
                char c = i % 2 == 0 ? '_' : ' ';
                initial.Append(c);
            }
            return initial;
        }

        private string pickWord() => words[(new Random(456)).Next(0, words.Count - 1)];

        /// <summary>
        /// Fulfil <see cref="words"/> with words from file
        /// </summary>
        private void loadWords() {
            using (var sr = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory().ToString() + 
                "\\Words.txt"))) {
                string word = sr.ReadLine();
                while (word != null) {
                    words.Add(word);
                    word = sr.ReadLine();
                }
            }
        }

        internal bool GameOver() {
            return false;
        }
    }

}
