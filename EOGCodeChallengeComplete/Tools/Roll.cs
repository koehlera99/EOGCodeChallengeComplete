using EOGCodeChallengeComplete.ViewModels;
using System;
using System.Collections.Generic;

namespace EOGCodeChallengeComplete.Tools
{
    class Roll
    {
        private static Random _random;

        static Roll()
        {
            _random = new Random();
        }

        public static List<DiceSides> RollDice(int chips)
        {
            chips = chips > 3 ? 3 : chips;

            var rolls = new List<DiceSides>();

            for(int i = 0; i < chips; i++)
            {
                rolls.Add((DiceSides)_random.Next(0, 6));
            }

            return rolls;
        }

        public static int Random(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
