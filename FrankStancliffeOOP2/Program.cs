using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankStancliffeOOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Die die1 = new Die();
            int total = 0;
            int check =0;
            while (check==0){
                int firstRoll = die1.Roll();
                int secondRoll = die1.Roll();
                int totalRoll = firstRoll + secondRoll;
                Console.WriteLine("1st Roll: {0}", firstRoll);
                Console.WriteLine("2nd Roll: {0}",secondRoll);
                Console.WriteLine("Total: {0}", totalRoll);
                if (totalRoll == 7 || (Console.ReadLine()) == "q")
                {
                    check = 1;
                }
                else {
                    total += totalRoll;
                }
            }
            Console.WriteLine(total);
            Console.ReadLine();
            
        }
    }
}
