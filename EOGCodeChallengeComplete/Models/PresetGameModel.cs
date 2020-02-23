namespace EOGCodeChallengeComplete.Models
{
    public class PresetGameModel
    {
        public PresetGameModel(int players, int games)
        {
            NumberOfPlayers = players;
            NumberOfGamesToSimulate = games;
        }

        public string PresetName => $"Players: {NumberOfPlayers}, Games: {NumberOfGamesToSimulate}";
        public int NumberOfPlayers { get; set; }
        public int NumberOfGamesToSimulate { get; set; }
    }
}
