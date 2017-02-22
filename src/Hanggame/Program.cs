using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanggame
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.GetEncoding(65001);
            Hanggame game = new Hanggame();
            game.PlayGame();
        }
    }
}
