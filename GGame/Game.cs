using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GGame
{
    class Game
    {
        Enemy e  = new Enemy("Bot1", 100, 12, 60, 22, 1);
        Enemy e1 = new Enemy("Bot2", 100, 7, 55, 22, 1);
        Enemy e2 = new Enemy("Bot3", 100, 11, 26, 22, 1);
        Enemy e3 = new Enemy("Bot4", 100, 23, 11, 22, 1);
        Player p = new Player("Player1", 100, 14, 5, 100, 2);
        Player p1 = new Player("Player2", 100, 7, 15, 100, 6);
        Player p2 = new Player("Player3", 100, 18, 33, 100, 3);
        Player p3 = new Player("Player4", 100, 3, 20, 100, 1);
        List<AEntity> f  = new List<AEntity>();
        List<AEntity> en = new List<AEntity>();
        public void StartBatle()
        {
            f.AddRange(new List<AEntity>() {p,p1,p2,p3 });
            en.AddRange(new List<AEntity>() {e,e1,e2,e3 });
            Battle batle1 = new Battle(f, en);
            batle1.setTimer();
        }
        

    }
}
