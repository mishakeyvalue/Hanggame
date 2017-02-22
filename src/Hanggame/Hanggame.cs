using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanggame
{
    public class Hanggame
    {
        public CommunicationChannel Chat = new CommunicationChannel();

        public void PlayGame()
        {
            //Вывод правил игры
            Chat.Write("Приветствую тебя возле 'Виселицы'!"
                + "Правила игры следующие:\n"
                + " 1. Я загадываю слово;"
                + " 2. "
                );
            
            Chat.Write("Я загадал слово!");

            bool doYouWantToPlay = true;
            while (doYouWantToPlay) {
                // Setting up the game
                Hangsession game = new Hangsession();
            while (!game.GameOver()) {
                    // Playing the game

                }
            }

            
        }

    }


    public class CommunicationChannel
    {
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
