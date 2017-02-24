using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanggame
{
    public class Hangsession {

        public String mysteryWord; // Word to be guessed
        private StringBuilder currentGuess;// Current state
        private List<char> previousGuesses = new List<char>(); // Letters that were chosen

        private const int MAX_TRIES = 6;
        private int currentTry = 0;

        private List<string> words = new List<string>();// List of words to random from


        public Hangsession(List<string> word_bank) {

            words = word_bank;
            mysteryWord = pickWord().ToUpper();
            currentGuess = initializeCurrentGuess();
        }

        //_ _ F _ _ G
        public string getFormalCurrentGuess() => "Слово: " + currentGuess.ToString();

        private StringBuilder initializeCurrentGuess() {
            StringBuilder initial = new StringBuilder();
            for(int i = 0; i < mysteryWord.Length * 2; i++) {
                char c = i % 2 == 0 ? '_' : ' ';
                initial.Append(c);
            }
            return initial;
        }

        private string pickWord() => words[(new Random()).Next(0, words.Count - 1)];

        internal bool IsGuessedAlready(char c) {
            return previousGuesses.Contains(c);
        }

        internal bool GameOver() {
            if (didWeWin()) {
                return true;
            }
            else if (didWeLose()) {
                return true;
            }
            return false;
        }
        #region Helpers for GameOver()

        public bool didWeLose() {
            return currentTry >= MAX_TRIES;
        }



        public bool didWeWin() {
            string unformal_guess = getCondensendCurrentGuess();
            return unformal_guess.Equals(mysteryWord);
        }
        public string getCondensendCurrentGuess() {
            string guess = currentGuess.ToString();
            return guess.Replace(" ", "");
        }
        #endregion

        internal bool PlayGuess(char guess) {
            bool isItAGoodGuess = false;
            previousGuesses.Add(guess);
            for (int i = 0; i < mysteryWord.Length; i++) {
                if(mysteryWord[i] == guess) {
                    isItAGoodGuess = true;
                    currentGuess.Replace('_', guess, i * 2, 1);
                    //currentGuess.Insert(i * 2 , guess);

                }
            }
            if (!isItAGoodGuess) {
                currentTry++;
            }
            return isItAGoodGuess;

        }

        #region Drawing
        /// <summary>
        /// Draws the picture according to current guess
        /// </summary>
        /// <returns>String that represents gallows</returns>
        public string DrawPicture() {
            switch (currentTry) {
                case 0: return noPersonDraw();
                case 1: return addHeadDraw();
                case 2: return addBodyDraw();
                case 3: return addOneArmDraw();
                case 4: return addSecondArmDraw();
                case 5: return addFirstLegDraw();
                default: return fullPersonDraw();

            }
        }



        private string addFirstLegDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |    \\|/\n")
             + ("  |     |\n")
             + ("  |    / \\\n")
             + ("  |\n")
             + ("__|__\n");
        }
        private string fullPersonDraw() {
            return ("   _____\n")
                 + ("  |     |\n")
                 + ("  |     O\n")
                 + ("  |    \\|/\n")
                 + ("  |     |\n")
                 + ("  |    / \n")
                 + ("  |\n")
                 + ("__|__\n");
        }

        private string addSecondArmDraw() {
            return ("   _____\n")
             + ("  |     |\n")
             + ("  |     O\n")
             + ("  |    \\|/\n")
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
             + ("  |     |\n")
             + ("  |     \n")
             + ("  |\n")
             + ("  |\n")
             + ("  |\n")
             + ("  |\n")
             + ("__|__\n");
        }

        #endregion
    }

}
