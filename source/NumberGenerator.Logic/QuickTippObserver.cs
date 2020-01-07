using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher auf einen vollständigen Quick-Tipp wartet: 6 unterschiedliche Zahlen zw. 1 und 45.
    /// </summary>
    public class QuickTippObserver : IObserver
    {
        #region Fields

        private RandomNumberGenerator _numberGenerator;

        #endregion

        #region Properties

        public List<int> QuickTippNumbers { get; private set; } = new List<int>();
        public int CountOfNumbersReceived { get; private set; }

        #endregion

        #region Constructor

        public QuickTippObserver(RandomNumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
            _numberGenerator.NextNumber += OnNextNumber;
        }

        #endregion

        #region Methods

        public void OnNextNumber(int number)
        {
            CountOfNumbersReceived++;
            if (number > 0 && number <= 45)
                QuickTippNumbers.Add(number);
            if (QuickTippNumbers.Count >= 6)
                DetachFromNumberGenerator();
        }

        public override string ToString()
        {
            string arrayStringBuild = string.Empty;

            foreach  (int number in QuickTippNumbers)
                arrayStringBuild += $"{number}, ";

            return $"{this.GetType().Name} [{nameof(CountOfNumbersReceived)}='{CountOfNumbersReceived}'] => " +
                $"Quicktipp is {arrayStringBuild}";
        }

        private void DetachFromNumberGenerator()
        {
            _numberGenerator.NextNumber -= OnNextNumber;
        }

        #endregion
    }
}
