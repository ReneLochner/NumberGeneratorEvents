
using NumberGenerator.Logic;
using System;

namespace NumberGenerator.Ui
{
    class Program
    {
        static void Main()
        {
            // Zufallszahlengenerator erstelltn
            RandomNumberGenerator numberGenerator = new RandomNumberGenerator(250);

            // Beobachter erstellen
            BaseObserver baseObserver = new BaseObserver(numberGenerator, 10);
            StatisticsObserver statisticsObserver = new StatisticsObserver(numberGenerator, 20);
            RangeObserver rangeObserver = new RangeObserver(numberGenerator, 5, 200, 300);
            QuickTippObserver quickTippObserver = new QuickTippObserver(numberGenerator);


            // Nummerngenerierung starten
            numberGenerator.StartNumberGeneration();
            // Resultat ausgeben
            Console.WriteLine("\n--------------------RESULT-----------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(statisticsObserver.ToString());
            Console.WriteLine(rangeObserver.ToString());
            Console.WriteLine(quickTippObserver.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------------------\n");
            Console.Write("Bitte drücken Sie Enter ...");
            Console.ReadLine();
        }
    }
}
