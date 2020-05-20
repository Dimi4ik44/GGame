using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GGame
{
    class Battle
    {
        Random rnd = new Random();
        List<AEntity> Team1;
        List<AEntity> Team2;
        bool batleEnd = false;
        public Battle(List<AEntity> t1, List<AEntity> t2)
        {
            Team1 = t1;
            Team2 = t2;
        }
        
        public void setTimer()
        {
            Timer t = new Timer(2000);
            t.Start();
            t.Elapsed += nexStepBatle;
        }
        public void nexStepBatle(Object source, ElapsedEventArgs e)
        {
            int deathCount = 0;
            AttackResult ar = new AttackResult();
            foreach (AEntity ae in Team1)
            {
                if (ae.IsDead)
                {
                    deathCount++;
                }
            }
            if (deathCount == Team1.Count)
            {
                batleEnd = true;
                Console.WriteLine("TEAM2 WIN");
                Console.WriteLine($"{Team2[0].Name}  ::  {Team2[0].Health}");
                Console.WriteLine($"{Team2[1].Name}  ::  {Team2[1].Health}");
                Console.WriteLine($"{Team2[2].Name}  ::  {Team2[2].Health}");
                Console.WriteLine($"{Team2[3].Name}  ::  {Team2[3].Health}");
                Console.WriteLine($"{Team1[0].Name}  ::  {Team1[0].Health}");
                Console.WriteLine($"{Team1[1].Name}  ::  {Team1[1].Health}");
                Console.WriteLine($"{Team1[2].Name}  ::  {Team1[2].Health}");
                Console.WriteLine($"{Team1[3].Name}  ::  {Team1[3].Health}");
            }
            deathCount = 0;
            foreach (AEntity ae in Team2)
            {
                if (ae.IsDead)
                {
                    deathCount++;
                }
            }
            if (deathCount == Team2.Count)
            {
                batleEnd = true;
                Console.WriteLine("TEAM1 WIN");
                Console.WriteLine($"{Team2[0].Name}  ::  {Team2[0].Health}");
                Console.WriteLine($"{Team2[1].Name}  ::  {Team2[1].Health}");
                Console.WriteLine($"{Team2[2].Name}  ::  {Team2[2].Health}");
                Console.WriteLine($"{Team2[3].Name}  ::  {Team2[3].Health}");
                Console.WriteLine($"{Team1[0].Name}  ::  {Team1[0].Health}");
                Console.WriteLine($"{Team1[1].Name}  ::  {Team1[1].Health}");
                Console.WriteLine($"{Team1[2].Name}  ::  {Team1[2].Health}");
                Console.WriteLine($"{Team1[3].Name}  ::  {Team1[3].Health}");
            }
            if (!batleEnd)
            { 
                foreach (AEntity ae in Team1)
                {
                    if (ae.Target != null)
                    {
                        if (!ae.Target.IsDead)
                        {
                            ar = ae.attack();
                        }
                        else
                        {
                            while (true)
                            {
                                int index = rnd.Next(0, Team2.Count);
                                if (!Team2[index].IsDead)
                                {
                                    ar = ae.attack(Team2[index]);
                                    ShowLog(ar);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            int index = rnd.Next(0, Team2.Count);
                            if (!Team2[index].IsDead)
                            {
                                ar = ae.attack(Team2[index]);
                                ShowLog(ar);
                                break;
                            }
                        }
                    }
                }
            foreach (AEntity ae in Team2)
            {
                if (ae.Target != null)
                {
                    if (!ae.Target.IsDead)
                    {
                        ar = ae.attack();
                        ShowLog(ar);
                    }
                    else
                    {
                        while (true)
                        {
                            int index = rnd.Next(0, Team1.Count);
                            if (!Team1[index].IsDead)
                            {
                                ar = ae.attack(Team1[index]);
                                ShowLog(ar);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        int index = rnd.Next(0, Team1.Count);
                        if (!Team1[index].IsDead)
                        {
                            ar = ae.attack(Team1[index]);
                            ShowLog(ar);
                            break;
                        }
                    }
                }
            }
                Console.WriteLine($"{Team2[0].Name}  ::  {Team2[0].Health}");
                Console.WriteLine($"{Team2[1].Name}  ::  {Team2[1].Health}");
                Console.WriteLine($"{Team2[2].Name}  ::  {Team2[2].Health}");
                Console.WriteLine($"{Team2[3].Name}  ::  {Team2[3].Health}");
                Console.WriteLine($"{Team1[0].Name}  ::  {Team1[0].Health}");
                Console.WriteLine($"{Team1[1].Name}  ::  {Team1[1].Health}");
                Console.WriteLine($"{Team1[2].Name}  ::  {Team1[2].Health}");
                Console.WriteLine($"{Team1[3].Name}  ::  {Team1[3].Health}");

            }
        }
        public void addToTeam1(AEntity target)
        {
            Team1.Add(target);
        }
        public void addToTeam2(AEntity target)
        {
            Team2.Add(target);
        }
        public void ShowLog(AttackResult ar)
        {
            if(ar.kill)
            {
                Console.WriteLine($"{ar.attaker.Name} Убил {ar.tar.Name}");
            }
            else if (ar.block&&ar.crit)
            {
                Console.WriteLine($"{ar.attaker.Name} пытаеться очень сильно ударить но {ar.tar.Name} блокирует часть урона и получает {ar.dmg} урона");
            }
            else if (ar.block)
            {
                Console.WriteLine($"{ar.attaker.Name} пытаеться ударить но {ar.tar.Name} блокирует часть урона и получает {ar.dmg} урона");
            }
            else if (ar.crit)
            {
                Console.WriteLine($"{ar.attaker.Name} пытаеться очень сильно ударить {ar.tar.Name} и попадает по нему с уроном в размере {ar.dmg}");
            }else Console.WriteLine($"{ar.attaker.Name} ударил {ar.tar.Name} на {ar.dmg}");
        }
    }
}
