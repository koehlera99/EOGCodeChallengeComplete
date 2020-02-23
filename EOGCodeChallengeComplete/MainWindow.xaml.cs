using EOGCodeChallengeComplete.Controllers;
using EOGCodeChallengeComplete.Models;
using EOGCodeChallengeComplete.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EOGCodeChallengeComplete
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameModel _game;
        public List<PresetGameModel> PresetGames;

        public MainWindow()
        {
            InitializeComponent();

            _game = new GameModel();
            grid1.DataContext = _game;

            InitializePresetGames();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource gameModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("gameModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // gameModelViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var gameController = new GameController(_game);

            if (int.TryParse(numberOfPlayersTextBox.Text, out int numberOfPlayers))
            {

                _game.NumberOfPlayers = numberOfPlayers;
                gameController.SimulateGames();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void InitializePresetGames()
        {
            PresetGames = new List<PresetGameModel>();

            PresetGames.Add(new PresetGameModel(3, 100));
            PresetGames.Add(new PresetGameModel(4, 100));
            PresetGames.Add(new PresetGameModel(5, 100));
            PresetGames.Add(new PresetGameModel(5, 1000));
            PresetGames.Add(new PresetGameModel(5, 10000));
            PresetGames.Add(new PresetGameModel(5, 1000000));
            PresetGames.Add(new PresetGameModel(6, 100));
            PresetGames.Add(new PresetGameModel(7, 100));

            cmbPresets.ItemsSource = PresetGames;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = (ComboBox)sender;

            var preset = (PresetGameModel)combobox.SelectedItem;

            _game.NumberOfGamesToSimulate = preset.NumberOfGamesToSimulate;
            _game.NumberOfPlayers = preset.NumberOfPlayers;
        }
    }
}
