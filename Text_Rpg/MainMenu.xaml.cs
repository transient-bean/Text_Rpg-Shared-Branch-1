using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Text_Rpg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the CharacterCreatorMenu class
            CharacterCreatorMenu characterCreatorMenu = new CharacterCreatorMenu();

            // Set the size and state of the character creator menu to match this window
            characterCreatorMenu.Width = this.Width;
            characterCreatorMenu.Height = this.Height;
            characterCreatorMenu.WindowState = this.WindowState;

            // Attach an event handler to CharacterCreatorMenu's Loaded event
            characterCreatorMenu.Loaded += OnCharacterCreatorLoaded;

            // Set the startup location (optional)
            characterCreatorMenu.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // Show the new window
            characterCreatorMenu.Show();
        }

        private void OnCharacterCreatorLoaded(object sender, RoutedEventArgs e)
        {
            // This code executes when the CharacterCreatorMenu finishes loading
            this.Close(); // Reference 'this' for the current MainMenu window
        }
    }
}
