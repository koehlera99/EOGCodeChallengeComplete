using EOGCodeChallengeComplete.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EOGCodeChallengeComplete.Controllers
{
    class GameController
    {
        private GameModel _gameModel;
        private bool _isGameOver;
        private List<int> _turnsPerGame;

        //tjhis would normally be an interface / depencyinjected
        public GameController(GameModel gameModel)
        {
            _gameModel = gameModel;
        }

        public TurnManager Turn { get; set; }

        public void SimulateGames()
        {
            if(_gameModel.NumberOfGamesToSimulate > 0)
            {
                _turnsPerGame = new List<int>();

                Turn = new TurnManager(_gameModel.NumberOfPlayers);

                for (int i = 0; i < _gameModel.NumberOfGamesToSimulate; i++)
                    SimulateSingleGame();

                _gameModel.LongestLengthGame = _turnsPerGame.Max();
                _gameModel.ShortestLengthGame = _turnsPerGame.Min();
                _gameModel.AverageLengthGame = (int)_turnsPerGame.Average();
            }
        }

        private void SimulateSingleGame()
        {
            Turn.InitializeNewGame();
            _gameModel.NumberOfTurns = 0;

            while (!_isGameOver)
            {
                _gameModel.NumberOfTurns++;
                SimulateSingleTurn();
            }

            _turnsPerGame.Add(_gameModel.NumberOfTurns);
            _isGameOver = false;
        }

        private void SimulateSingleTurn()
        {
            var currentPlayer = Turn.GetNextPlayer();

            if(!currentPlayer.HasNoChips)
            {
                var rolls = Tools.Roll.RollDice(currentPlayer.Chips);

                foreach (var roll in rolls)
                {
                    switch(roll)
                    {
                        case DiceSides.Left:
                            currentPlayer.Chips -= 1;
                            Turn.GetLeftPlayer(currentPlayer.PlayerNumber).Chips += 1;
                            break;
                        case DiceSides.Right:
                            currentPlayer.Chips -= 1;
                            Turn.GetRightPlayer(currentPlayer.PlayerNumber).Chips += 1;
                            break;
                        case DiceSides.Center:
                            currentPlayer.Chips -= 1;
                            break;
                        default:
                            break;
                    }
                }
            }

            CheckForGameOver();
        }

        private void CheckForGameOver()
        {
            var playersWithNoChips = Turn.Players.Where(x => x.Chips == 0).Count();

            _isGameOver = playersWithNoChips == _gameModel.NumberOfPlayers - 1;
        }
    }
}
