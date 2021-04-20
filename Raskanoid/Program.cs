using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaskanoidGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RaskanoidGame game = new RaskanoidGame(800, 600, 60);
            game.Start();

            Application.Run();
        }
    }
}
