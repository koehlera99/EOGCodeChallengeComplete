using EOGCodeChallengeComplete.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EOGCodeChallengeComplete.Controllers
{
    class TurnManager
    {
        ///Normally, this would not be a model, but a business object that interacts with the model
        public List<PlayerModel> Players;
        private int _numberOfPlayers;
        private int _currentPlayer;

        public TurnManager(int numberOfPlayers)
        {
            _currentPlayer = 0;
            _numberOfPlayers = numberOfPlayers;
            InitializeNewGame();
        }

        public void InitializeNewGame()
        {
            Players = new List<PlayerModel>();

            for (int i = 0; i < _numberOfPlayers; i++)
            {
                Players.Add(new PlayerModel(i + 1));
            }
        }

        public PlayerModel GetNextPlayer()
        {
            _currentPlayer++;

            if (_currentPlayer >= _numberOfPlayers)
                _currentPlayer = 0;

            return Players[_currentPlayer];
        }

        public PlayerModel GetLeftPlayer(int currentPlayerNumber)
        {
            int leftPlayerNumber = currentPlayerNumber == 1 ? _numberOfPlayers : currentPlayerNumber - 1;

            return GetPlayerByNumber(leftPlayerNumber);
        }

        public PlayerModel GetRightPlayer(int currentPlayerNumber)
        {
            int leftPlayerNumber = currentPlayerNumber == _numberOfPlayers ? 1 : currentPlayerNumber + 1;

            return GetPlayerByNumber(leftPlayerNumber);
        }

        public PlayerModel GetPlayerByNumber(int playerNumber)
        {
            return Players.Where(x => x.PlayerNumber == playerNumber).First();
        }
    }
}
