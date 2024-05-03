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
    /// Interaction logic for CharacterCreatorMenu.xaml
    /// </summary>
    public partial class CharacterCreatorMenu : Window
    {
        private bool isClosing = false;
        private CreatorStatsManager statsManager = new CreatorStatsManager();

        private bool isStatsSelectionChanged = false;

        public CharacterCreatorMenu()
        {
            InitializeComponent();

            InitializeDropdowns();

            OriginsDropdown.SelectionChanged += OnDropdownSelectionChanged;
            RacesDropdown.SelectionChanged += OnDropdownSelectionChanged;
            MotivationsDropdown.SelectionChanged += OnDropdownSelectionChanged;
            PerksDropdown.SelectionChanged += OnDropdownSelectionChanged;
            StatsDropdown.SelectionChanged += OnDropdownSelectionChanged;

            this.Closing += OnWindowClosing;

            AddStatButton.Click += AddStatButton_Click;
            RemoveStatButton.Click += RemoveStatButton_Click;
        }

        private void InitializeDropdowns()
        {
            InitializeDropdown(PronounsDropdown, CharacterDataDictionary.Pronouns);
            InitializeDropdown<string[]>(OriginsDropdown, CharacterDataDictionary.Origins.ToDictionary(kv => kv.Key, kv => kv.Value as string[]));
            InitializeDropdown<string[]>(RacesDropdown, CharacterDataDictionary.Races.ToDictionary(kv => kv.Key, kv => kv.Value as string[]));
            InitializeDropdown<string[]>(MotivationsDropdown, CharacterDataDictionary.Motivations.ToDictionary(kv => kv.Key, kv => kv.Value as string[]));
            InitializeDropdown<string[]>(PerksDropdown, CharacterDataDictionary.Perks.ToDictionary(kv => kv.Key, kv => kv.Value as string[]));
            InitializeDropdown<string[]>(StatsDropdown, CharacterDataDictionary.Stats.ToDictionary(kv => kv.Key, kv => kv.Value as string[]));
        }

        private void InitializeDropdown<T>(ComboBox dropdown, IReadOnlyDictionary<string, T> dataDictionary)
        {
            foreach (var item in dataDictionary.Keys)
            {
                dropdown.Items.Add(item);
            }

            dropdown.SelectedIndex = 0;
        }

        private void OnDropdownSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (sender as ComboBox)?.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                if (sender == OriginsDropdown)
                {
                    isStatsSelectionChanged = false;
                    UpdateDescriptionBlock(CharacterDataDictionary.Origins, selectedItem);
                    TrackStatModifiers(CharacterDataDictionary.Origins, selectedItem);
                }
                else if (sender == RacesDropdown)
                {
                    isStatsSelectionChanged = false;
                    UpdateDescriptionBlock(CharacterDataDictionary.Races, selectedItem);
                    TrackStatModifiers(CharacterDataDictionary.Races, selectedItem);
                }
                else if (sender == MotivationsDropdown)
                {
                    isStatsSelectionChanged = false;
                    UpdateDescriptionBlock(CharacterDataDictionary.Motivations, selectedItem);
                }
                else if (sender == PerksDropdown)
                {
                    isStatsSelectionChanged = false;
                    UpdateDescriptionBlock(CharacterDataDictionary.Perks, selectedItem);
                }
                else if (sender == StatsDropdown)
                {
                    isStatsSelectionChanged = true;
                    UpdateDescriptionBlock(CharacterDataDictionary.Stats, selectedItem);
                }
            }
        }

        private void AddStatButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatsDropdown.SelectedItem != null)
            {
                isStatsSelectionChanged = true;
                string statName = StatsDropdown.SelectedItem.ToString();
                statsManager.AddStat(statName, 1);
                UpdateDescriptionBlock(CharacterDataDictionary.Stats, statName);
            }
        }

        private void RemoveStatButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatsDropdown.SelectedItem != null)
            {
                isStatsSelectionChanged = true;
                string statName = StatsDropdown.SelectedItem.ToString();
                statsManager.RemoveStat(statName, 1);
                UpdateDescriptionBlock(CharacterDataDictionary.Stats, statName);
            }
        }

        private void UpdateDescriptionBlock(IReadOnlyDictionary<string, object> dataDictionary, string selectedItem)
        {
            // Check if the selected item exists in the data dictionary
            if (dataDictionary.ContainsKey(selectedItem))
            {
                var characterData = (Dictionary<string, object>)dataDictionary[selectedItem];

                // Extract the necessary data from the characterData dictionary
                string description = (string)characterData["Description"];
                string traits = characterData.ContainsKey("Traits") ? (string)characterData["Traits"] : null;
                string drawbacks = characterData.ContainsKey("Drawbacks") ? (string)characterData["Drawbacks"] : null;
                string goal = characterData.ContainsKey("Goal") ? (string)characterData["Goal"] : null;
                string effect = characterData.ContainsKey("Effect") ? (string)characterData["Effect"] : null;
                string stat = characterData.ContainsKey("Stat") ? (string)characterData["Stat"] : null;

                StringBuilder formattedDescription = new StringBuilder();
                formattedDescription.AppendLine($"{description}");

                // Add stat values and remaining points to the formatted description if the stats selection has changed
                if (isStatsSelectionChanged)
                {
                    formattedDescription.AppendLine("\n\nStat Values:");
                    int totalStatPointsSpent = statsManager.GetTotalStatPoints();
                    int remainingPoints = CreatorStatsManager.MaxStatTotal - totalStatPointsSpent;

                    foreach (var statEntry in statsManager.stats)
                    {
                        int statValue = statsManager.GetStatValue(statEntry.Key);
                        int bonusStatValue = 0;

                        // Check if the selected dropdowns have corresponding modifiers in the CharacterDataDictionary
                        if (OriginsDropdown.SelectedItem != null && CharacterDataDictionary.Origins.ContainsKey(OriginsDropdown.SelectedItem.ToString()))
                        {
                            var originData = (Dictionary<string, object>)CharacterDataDictionary.Origins[OriginsDropdown.SelectedItem.ToString()];
                            if (originData.ContainsKey("TotalStatChanges") && ((Dictionary<string, int>)originData["TotalStatChanges"]).ContainsKey(statEntry.Key))
                            {
                                bonusStatValue += ((Dictionary<string, int>)originData["TotalStatChanges"])[statEntry.Key];
                            }
                        }
                        if (RacesDropdown.SelectedItem != null && CharacterDataDictionary.Races.ContainsKey(RacesDropdown.SelectedItem.ToString()))
                        {
                            var raceData = (Dictionary<string, object>)CharacterDataDictionary.Races[RacesDropdown.SelectedItem.ToString()];
                            if (raceData.ContainsKey("TotalStatChanges") && ((Dictionary<string, int>)raceData["TotalStatChanges"]).ContainsKey(statEntry.Key))
                            {
                                bonusStatValue += ((Dictionary<string, int>)raceData["TotalStatChanges"])[statEntry.Key];
                            }
                        }

                        if (bonusStatValue != 0) // Check if the bonusStatValue is not equal to 0
                        {
                            string bonusStatValueString = bonusStatValue >= 0 ? $"+{bonusStatValue}" : $"{bonusStatValue}";
                            formattedDescription.AppendLine($"{statEntry.Key}: {statValue} ({bonusStatValueString})");
                        }
                        else
                        {
                            formattedDescription.AppendLine($"{statEntry.Key}: {statValue}");
                        }
                    }

                    formattedDescription.AppendLine($"\nRemaining Points: {remainingPoints}");
                }

                // Add traits to the formatted description if they exist
                if (traits != null)
                {
                    formattedDescription.AppendLine($"\nTraits: {traits}");
                }
                // Add drawbacks to the formatted description if they exist
                if (drawbacks != null)
                {
                    formattedDescription.AppendLine($"\nDrawbacks: {drawbacks}");
                }
                // Add goal to the formatted description if it exists
                if (goal != null)
                {
                    formattedDescription.AppendLine($"\nGoal: {goal}");
                }
                // Add effect to the formatted description if it exists
                if (effect != null)
                {
                    formattedDescription.AppendLine($"\nEffect: {effect}");
                }

                // Update the CreatorDescriptionBlock with the formatted description and make it visible
                CreatorDescriptionBlock.Text = formattedDescription.ToString();
                CreatorDescriptionBlock.Visibility = Visibility.Visible;
            }
        }

        private void TrackStatModifiers(IReadOnlyDictionary<string, object> dataDictionary, string selectedItem)
        {
            if (dataDictionary.ContainsKey(selectedItem))
            {
                var characterData = (Dictionary<string, object>)dataDictionary[selectedItem];

                // Check if the characterData dictionary contains the "StatModifiers" key
                if (characterData.ContainsKey("StatModifiers"))
                {
                    var statModifiers = (Dictionary<string, int>)characterData["StatModifiers"];

                    // Loop through the stat modifiers and track them
                    foreach (var statModifier in statModifiers)
                    {
                        // You can do whatever you want with the stat modifiers here
                        // For example, you can update the statsManager with the new modifiers
                        statsManager.AddStat(statModifier.Key, statModifier.Value);
                    }
                }
            }
        }

        public void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isClosing)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Width = this.Width;
                mainMenu.Height = this.Height;
                mainMenu.WindowState = this.WindowState;
                mainMenu.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                mainMenu.Show();

                isClosing = true;
            }
        }

        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            isClosing = true;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}