using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanggame
{
    public class Hanggame
    {
        public CommunicationChannel Chat = new CommunicationChannel();

        public Encoding enc = Encoding.GetEncoding(65001);

        public void PlayGame()
        {
            loadWords();
            //Вывод правил игры
            Chat.WriteLine("Приветствую тебя возле 'Виселицы'!"
                + "Правила игры следующие:\n"
                + " 1. Я загадываю слово;"
                + " 2. "
                );
            
            Chat.WriteLine("Я загадал слово!");

            bool doYouWantToPlay = true;
            while (doYouWantToPlay) {
                // Setting up the game
                Hangsession game = new Hangsession(words);

                do {
                    Chat.WriteLine(game.DrawPicture());
                    Chat.WriteLine(game.getFormalCurrentGuess());
                    Chat.WriteLine(game.mysteryWord);
                    Chat.WriteLine("Попытайся догадаться, какая буква есть в этом слове..");
                    // Get the guess
                    get_the_guess:
                    string input = Chat.Read().ToUpper();
                    //-- Is input valid ? --
                        if(input.Length > 1) {
                        Chat.WriteLine("Угадывать нужно по одной букве! Попробуй еще раз!");
                        goto get_the_guess;
                    }
                    char guess = (char)input[0];

                    // Was it guessed before ?
                    if (game.IsGuessedAlready(guess)) {
                        Chat.WriteLine("Эта буква уже была! Попробуй еще раз!");
                        goto get_the_guess;
                    }
                    // Playing the game
                    if (game.PlayGuess(guess)) {

                        if (game.didWeWin()) {
                            Chat.WriteLine("Урра! ты победил!");
                            goto ask_for_next_game;
                        }

                        Chat.WriteLine("Действительно.. Эта буква есть в слове, ты угадал!");
                    }
                    else {
                        if (game.didWeLose()) {
                            Chat.WriteLine($"Попытки закончились и ты проиграл! Загаданное слово: \n{game.mysteryWord}");
                            goto ask_for_next_game;
                        }
                        Chat.WriteLine("Не-а.. Такой буквы в слове нет!");
                    }


                }
                while (!game.GameOver());
                ask_for_next_game:

                Chat.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                Chat.WriteLine("Желаешь сыграть еще?");
                string answer = Chat.Read().ToLower();

                if (positiveAnswers.Contains(answer)) {
                    Chat.WriteLine("Отлично! Начинаем по новой!");
                    doYouWantToPlay = true;
                }
                else if (negativeAnswers.Contains(answer)) {
                    Chat.WriteLine("Ну что ж! Увидимся в следующий раз!");
                    doYouWantToPlay = false;
                }
                else {
                    Chat.WriteLine("Я не расслышал твоего ответа.. Будь добр, повтори.");
                    goto ask_for_next_game;
                }
            }

            
        }

        private List<string> positiveAnswers = new List<string>() {
            "y",
            "yes",
            "da",
            "d",
            "д",
            "да",
            "давай",

        };
        private List<string> negativeAnswers = new List<string>() {
            "n",
            "no",
            "net",
            "ne",
            "н",
            "нет",
            "не",

        };

        private List<string> words = new List<string>();
        /// <summary>
        /// Fulfil <see cref="words"/> with words from file
        /// </summary>
        private List<string> loadWords() {
            try {
                using (var sr = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory().ToString() +
            "\\Words.txt"))) {
                    string word = sr.ReadLine();
                    while (word != null) {
                        words.Add(word);
                        word = sr.ReadLine();
                    }
                }
            }
            catch (Exception e) {

                Console.WriteLine(e.Message);
            }
            return words;
        }

    }


    public class CommunicationChannel
    {
        public void WriteLine(string s = "\n")
        {
            Console.WriteLine(s + "\n");
        }
        public string Read()
        {
            Console.InputEncoding = UTF8Encoding.Unicode;
            return Console.ReadLine();
        }
    }
}
