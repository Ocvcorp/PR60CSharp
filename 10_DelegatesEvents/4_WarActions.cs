/*
1.	Создайте проект "Военные действия".
•	Классы, задающие противников, взаимно обрабатывают события друг друга. 
•	Например, объект одного класса зажигает событие "атака" (танками, если контратака будет пехотой. На самолеты аттаковать боиться), 
обработчик этого события в другом классе в ответ зажигает событие "контратака".
В процессе атак-контратак противники теряют боевые единицы: 5 чел на один танк.
 */
using System;
namespace ConsoleApp
{
    public class ActionArgs:EventArgs
    {
        public int unitCount;
        public ActionArgs(int unitCount=0)
        {
            this.unitCount = unitCount;
        }
    }
    public class Program
    {
        public class Agressor
        {
            public Agressor(int tanks)
            {
                Tanks = tanks;
            }
            public int Tanks { get; set; }
            //events
            EventHandler<ActionArgs> evnt;
            public event EventHandler<ActionArgs> AttackEvent
            { 
                add
                {
                    if (value.Method.Name == "AirContrAttack")
                    {
                        Console.WriteLine("All the tanks will be destroyed. Commander won't attack!");
                    }
                    else
                        evnt = value;
                }
                remove
                {
                    evnt = null;
                }
            }
            public void OnAttackEvent(int count)
            {
                ActionArgs args = new ActionArgs();
                if (evnt != null)
                {
                    args.unitCount = count;
                    evnt(this, args);
                }
            }
            //handlers
            public void TankDefend(object sender, ActionArgs args)
            {
                Console.WriteLine($"Tanks ({Tanks} units) are destroying till the contrattack");
                Tanks -= (args.unitCount / 5);
                if (Tanks < 0)
                    Tanks = 0;
            }
        }
        public class Pacifier
        {
            public int Airplanes { get; set; }
            public int Soldiers { get; set; }
            public Pacifier(int soldiers, int airplanes)
            {
                Airplanes = airplanes;
                Soldiers = soldiers;
            }
            //events
            public event EventHandler<ActionArgs> ContrAttackEvent;
            public void OnContrAttackEvent(int count)
            {
                ActionArgs args = new ActionArgs(count);
                ContrAttackEvent?.Invoke(this, args);
            }
            //handlers
            public void AirContrAttack(object sender, ActionArgs args)
            {
                Console.WriteLine("Airplane");
            }
            public void SoldiersContrAttack(object sender, ActionArgs args)
            {
                if (Soldiers == 1)
                    Console.WriteLine("We have no forces to make contrattacks");
                else
                Console.WriteLine($"Soldier subdivision (with {Soldiers} persons) contrattacks the enemy.\nUraaa!!!");
                Soldiers -= (5 * args.unitCount);
                if (Soldiers < 0)
                    Soldiers = 1;
            }
        }
        public static void Forces(Agressor agressor, Pacifier pacifier)
        {
            Console.WriteLine($"Agressor forces - {agressor.Tanks} tanks");
            Console.WriteLine("Pacifient forces {0} soldiers, {1} airplanes", pacifier.Soldiers, pacifier.Airplanes);
        }
        public static void Main()
        {
            //two sides
            Agressor agressor = new Agressor(5);
            Pacifier pacifier = new Pacifier(100,5);
            //initial conditions
            Console.WriteLine("Battle 1");
            Forces(agressor, pacifier);
            //event subscription 
            agressor.AttackEvent += pacifier.AirContrAttack;
            agressor.AttackEvent += pacifier.SoldiersContrAttack;
            pacifier.ContrAttackEvent += agressor.TankDefend;
            //attack-contra events
            agressor.OnAttackEvent(4);           
            pacifier.OnContrAttackEvent(20);
            //after Batle 1
            Forces(agressor, pacifier);
            Console.WriteLine("Battle 2");
            //attack-contra events
            agressor.OnAttackEvent(1);
            pacifier.OnContrAttackEvent(20);
            //after batles
            Forces(agressor, pacifier);
            Console.ReadKey();
        }
    }
}
