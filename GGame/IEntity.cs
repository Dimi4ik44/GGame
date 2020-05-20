using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGame
{
    interface IEntity
    {
        string Name    { get; set; }
        int Health     { get; set; }
        int Defence    { get; set; }
        int Atack      { get; set; }
        int Critchance { get; set; }
        int Critdmg    { get; set; }
        int Agility    { get; set; }
        int Accuracity { get; set; }
        bool IsDead    { get; set; }
    }
}
