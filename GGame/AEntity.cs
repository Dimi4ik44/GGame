using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGame
{
    abstract class AEntity : IEntity
    {
        public string Name    { get; set; }
        public int Health     { get; set; }
        public int Defence    { get; set; }
        public int Atack      { get; set; }
        public int Critchance { get; set; }
        public int Critdmg    { get; set; }
        public int Agility    { get; set; }
        public int Accuracity { get; set; }
        public bool IsDead    { get; set; } = false;
        public AEntity Target { get; set; } = null;
        public AEntity(string name,int health, int damage, int critch, int critdmg, int defence)
        {
            Name       = name;
            Health     = health;
            Defence    = defence;
            Atack      = damage;
            Critchance = critch;
            Critdmg    = critdmg;
        }
        public virtual AttackResult takeDamage(int damage)
        {
            bool block=false;
            int dmg=damage;
            Random rnd = new Random();
            //30 a chanse to multi block dmg
            if(rnd.Next(0,100)<=30)
            {
                block = true;
                if (damage <= (Defence * 3))
                {
                    dmg = 0;
                }
                else
                {
                    Health -= damage - (Defence * 3);
                    dmg = damage - (Defence * 3);
                    if (Health <= 0)
                    {
                        Health = 0;
                        IsDead = true;
                    }
                }
            }
            else if (damage <= (int)(Defence * 0.5d))
            {
                dmg = 0;
            }
            else
            {
                Health -= damage - (int)(Defence * 0.5d);
                dmg = damage - (int)(Defence * 0.5d);
                if (Health<=0)
                {
                    Health = 0;
                    IsDead = true;
                }
            }
            return new AttackResult() {block=block,dmg=dmg,kill=IsDead };
        }
        public virtual AttackResult attack()
        {
            AttackResult AR=null;
            bool crit = false;
            if (Target != null)
            {
                if (!IsDead || !Target.IsDead)
                {
                    Random rnd = new Random();
                    if (rnd.Next(0, 100) <= Critchance)
                    {
                        crit = true;
                        AR=Target.takeDamage(Atack + (int)((Atack / 100d) * Critdmg));
                    }
                    else
                    {
                        AR=Target.takeDamage(Atack);
                    }
                }
            }
            else
            {

            }
            if(AR!=null)
            {
                AR.crit    = crit;
                AR.tar     = Target;
                AR.attaker = this;
            }
            return AR;
        }
        public virtual AttackResult attack(AEntity target)
        {
            AttackResult AR = null;
            bool crit = false;
            if (target != null)
            {
                if (!IsDead || !target.IsDead)
                {
                    Random rnd = new Random();
                    if (rnd.Next(0, 100) <= Critchance)
                    {
                        crit = true;
                        AR=target.takeDamage(Atack + (int)((Atack / 100d) * Critdmg));
                    }
                    else
                    {
                        AR=target.takeDamage(Atack);
                    }
                }
            }
            else
            {
             
            }
            if (AR != null)
            {
                AR.crit    = crit;
                AR.tar     = target;
                AR.attaker = this;
            }
            return AR;
        }
        public virtual void settarget(AEntity target)
        {
            Target = target;
        }
    }
}
