using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGame
{
    class Enemy : AEntity
    {
        public Enemy(string name, int health, int damage, int critch, int critdmg, int defence) : base(name,health,damage,critch,critdmg,defence)
        {

        }
    }
}
