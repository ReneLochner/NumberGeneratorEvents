using System;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher einfache Statistiken bereit stellt (Min, Max, Sum, Avg).
    /// </summary>
    public class StatisticsObserver : BaseObserver
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Enthält das Minimum der generierten Zahlen.
        /// </summary>
        public int Min { get; private set; } = int.MaxValue;

        /// <summary>
        /// Enthält das Maximum der generierten Zahlen.
        /// </summary>
        public int Max { get; private set; } = int.MinValue;

        /// <summary>
        /// Enthält die Summe der generierten Zahlen.
        /// </summary>
        public int Sum { get; private set; }

        /// <summary>
        /// Enthält den Durchschnitt der generierten Zahlen.
        /// </summary>
        public int Avg => Sum/CountOfNumbersReceived;

        #endregion

        #region Constructors

        public StatisticsObserver(RandomNumberGenerator numberGenerator, int countOfNumbersToWaitFor) : 
            base(numberGenerator, countOfNumbersToWaitFor) { }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{base.ToString()} => {this.GetType().Name} " +
                $"[{nameof(Min)}='{Min}', {nameof(Max)}='{Max}', {nameof(Sum)}='{Sum}', {nameof(Avg)}='{Avg}']";
        }

        public override void OnNextNumber(int number)
        {
            base.OnNextNumber(number);
            if (number < Min)
                Min = number;
            else if (number > Max)
                Max = number;

            Sum += number;
        }

        #endregion
    }
}
