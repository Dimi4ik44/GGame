using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGame
{
    class AttackResult
    {
        public AEntity attaker;
        public AEntity tar;
        public bool crit = false;
        public bool block = false;
        public int dmg = 0;
        public bool kill = false;
    }
}
