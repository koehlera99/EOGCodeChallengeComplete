namespace EOGCodeChallengeComplete.ViewModels
{
    class GameModel : ViewModelBase
    {
        private int _numberOfPlayers;
        private int _numberOfGamesToSimulate;
        private int _shortestGame;
        private int _longestGame;
        private int _averageGame;
        private int _numberOfTurns;

        public int NumberOfPlayers
        {
            get => _numberOfPlayers;
            set
            {
                value = value < 3 ? 3 : value;
                SetProperty(ref _numberOfPlayers, value);
            }
        }

        public int NumberOfGamesToSimulate
        {
            get => _numberOfGamesToSimulate;
            set => SetProperty(ref _numberOfGamesToSimulate, value);
        }

        public int NumberOfTurns
        {
            get => _numberOfTurns;
            set => SetProperty(ref _numberOfTurns, value);
        }

        public int ShortestLengthGame
        {
            get => _shortestGame;
            set => SetProperty(ref _shortestGame, value);
        }

        public int LongestLengthGame
        {
            get => _longestGame;
            set => SetProperty(ref _longestGame, value);
        }

        public int AverageLengthGame
        {
            get => _averageGame;
            set => SetProperty(ref _averageGame, value);
        }
    }
}
