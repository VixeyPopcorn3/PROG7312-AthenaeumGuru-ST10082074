using PROG7312_AthenaeumGuru_ST10082074.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG7312_AthenaeumGuru_ST10082074.Pages
{
    /// <summary>
    /// Interaction logic for IdentifyAreasScreen.xaml
    /// </summary>
    public partial class IdentifyAreasScreen : Window
    {
        private Random random = new Random();
        private StartPage sP;
        private Dictionary<ListBoxItem, SolidColorBrush> itemBackgroundColors = new Dictionary<ListBoxItem, SolidColorBrush>();
        private IdentifyingAreas identifyingAreas;
        private ListBoxItem lastSelectedItem;
        private ListBoxItem lastSelectedRightItem;
        private Dictionary<ListBoxItem, ListBoxItem> lastSelectedRightItems = new Dictionary<ListBoxItem, ListBoxItem>();
        private bool keyside;
        private int Score, CumulativeScore, Counter; 
        private bool checkButtonClicked = false;
        private List<ListBoxItem> selectedItems = new List<ListBoxItem>();


        public IdentifyAreasScreen()
        {
            InitializeComponent();
            LeftBox.Background = null; RightBox.Background = null;
            keyside = random.Next(2) == 0;
            identifyingAreas = new IdentifyingAreas();
            PopulateLeftBoxWithItems(LeftBox);
            PopulateRightBoxWithRandomItems(RightBox);
        }

        /*
        private void LeftBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//changing the colour of the selected item
        {
            ListBox leftBox = (ListBox)sender;

            if (leftBox.SelectedItem != null)
            {
                lastSelectedItem = (ListBoxItem)leftBox.ItemContainerGenerator.ContainerFromItem(leftBox.SelectedItem);

                if (!lastSelectedRightItems.ContainsKey(lastSelectedItem))
                {
                    lastSelectedRightItems[lastSelectedItem] = null; // Initialize with null
                }
                ListBoxItem selectedListBoxItem = (ListBoxItem)leftBox.ItemContainerGenerator.ContainerFromItem(leftBox.SelectedItem);

                // Check if we have a previously stored background color for the item
                if (itemBackgroundColors.ContainsKey(selectedListBoxItem))
                {
                    // Restore the stored background color
                    selectedListBoxItem.Background = itemBackgroundColors[selectedListBoxItem];
                }
                else
                {
                    // Generate a random color for the item
                    Color randomColor = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                    SolidColorBrush brush = new SolidColorBrush(randomColor);

                    // Store the background color for the item
                    itemBackgroundColors[selectedListBoxItem] = brush;

                    // Set the item's background color
                    selectedListBoxItem.Background = brush;
                }
            }
        }
        private void RightBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox rightBox = (ListBox)sender;

            if (rightBox.SelectedItem != null && lastSelectedItem != null)
            {
                ListBoxItem selectedListBoxItem = (ListBoxItem)rightBox.ItemContainerGenerator.ContainerFromItem(rightBox.SelectedItem);

                if (lastSelectedRightItems.ContainsKey(lastSelectedItem))
                {
                    // Reset the previous right item's color
                    if (lastSelectedRightItems[lastSelectedItem] != null)
                    {
                        lastSelectedRightItems[lastSelectedItem].Background = Brushes.Transparent;
                    }

                    // Set the background color of the current right item
                    lastSelectedRightItems[lastSelectedItem] = selectedListBoxItem;
                    if (itemBackgroundColors.ContainsKey(lastSelectedItem))
                    {
                        selectedListBoxItem.Background = itemBackgroundColors[lastSelectedItem];
                    }
                }
            }
        }*/
        private void LeftBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox leftBox = (ListBox)sender;

            if (leftBox.SelectedItem != null)
            {
                lastSelectedItem = (ListBoxItem)leftBox.ItemContainerGenerator.ContainerFromItem(leftBox.SelectedItem);

                if (!lastSelectedRightItems.ContainsKey(lastSelectedItem))
                {
                    lastSelectedRightItems[lastSelectedItem] = null; // Initialize with null
                }
                ListBoxItem selectedListBoxItem = (ListBoxItem)leftBox.ItemContainerGenerator.ContainerFromItem(leftBox.SelectedItem);

                // Check if we have a previously stored background color for the item
                if (itemBackgroundColors.ContainsKey(selectedListBoxItem))
                {
                    // Restore the stored background color
                    selectedListBoxItem.Background = itemBackgroundColors[selectedListBoxItem];
                }
                else
                {
                    // Generate a random color for the item
                    Color randomColor = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                    SolidColorBrush brush = new SolidColorBrush(randomColor);

                    // Store the background color for the item
                    itemBackgroundColors[selectedListBoxItem] = brush;

                    // Set the item's background color
                    selectedListBoxItem.Background = brush;
                }

                // Add the selected item to the list
                if (!selectedItems.Contains(selectedListBoxItem))
                {
                    selectedItems.Add(selectedListBoxItem);
                }
            }
        }

        private void RightBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox rightBox = (ListBox)sender;

            if (rightBox.SelectedItem != null && lastSelectedItem != null)
            {
                ListBoxItem selectedListBoxItem = (ListBoxItem)rightBox.ItemContainerGenerator.ContainerFromItem(rightBox.SelectedItem);

                if (lastSelectedRightItems.ContainsKey(lastSelectedItem))
                {
                    // Reset the previous right item's color
                    if (lastSelectedRightItems[lastSelectedItem] != null)
                    {
                        lastSelectedRightItems[lastSelectedItem].Background = Brushes.Transparent;
                    }

                    // Set the background color of the current right item
                    lastSelectedRightItems[lastSelectedItem] = selectedListBoxItem;
                    if (itemBackgroundColors.ContainsKey(lastSelectedItem))
                    {
                        selectedListBoxItem.Background = itemBackgroundColors[lastSelectedItem];
                    }
                }
            }
        }


        private void PopulateLeftBoxWithItems(ListBox listBox)
        {
            listBox.Items.Clear(); // Clear the list box first

            Dictionary<string, string> items = new Dictionary<string, string>();

            // Add (questions) to the dictionary
            foreach (var pair in identifyingAreas.questionsColumn)
            {
                items[pair.Key] = pair.Value;
            }

            // Decide whether to show keys or values on the right
            bool showKeysOnRight = random.Next(2) == 0; // 50% chance

            foreach (var item in items)
            {
                string textToShow;
                if (keyside == true)//true = left side has keys
                {
                    textToShow = item.Key;
                }
                else//false = left side has values
                {
                    textToShow = item.Value;
                }

                listBox.Items.Add(textToShow);
            }
        }
        private void PopulateRightBoxWithRandomItems(ListBox listBox)
        {
            listBox.Items.Clear(); // Clear the list box first

            Dictionary<string, string> items = new Dictionary<string, string>();

            // Add correct answers (questions) to the dictionary
            foreach (var pair in identifyingAreas.questionsColumn)
            {
                items[pair.Key] = pair.Value;
            }

            // Add incorrect answers
            foreach (var pair in identifyingAreas.incorectAnsColumn)
            {
                items[pair.Key] = pair.Value;
            }

            // Randomize the order of items
            var randomizedItems = items.OrderBy(x => random.Next()).ToDictionary(pair => pair.Key, pair => pair.Value);

            // Decide whether to show keys or values on the right
            bool showKeysOnRight = random.Next(2) == 0; // 50% chance

            foreach (var item in randomizedItems)
            {
                string textToShow;
                if (keyside == true)//true = right side has values
                {
                    textToShow = item.Value;
                }
                else//false = right side has keys
                {
                    textToShow = item.Key;
                }
                listBox.Items.Add(textToShow);
            }
        }
        
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            sP = new StartPage();
            sP.Show();
            this.Close();
        }
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            LeftBox.Items.Clear();
            RightBox.Items.Clear();
            Scorelbl.Content = "Score: ";

            keyside = random.Next(2) == 0;
            identifyingAreas = new IdentifyingAreas();
            PopulateLeftBoxWithItems(LeftBox);
            PopulateRightBoxWithRandomItems(RightBox);
            checkButtonClicked = false;
        }
        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!checkButtonClicked)
            {
                int selectedCount = selectedItems.Count;
                if (selectedCount == 0)
                {
                    MessageBox.Show("You haven't selected any answers. Please select at least one answer before checking.");
                    checkButtonClicked = false;
                }
                else if (selectedCount < 4)
                {
                    MessageBox.Show("You haven't completed all the questions, to get a better score next time try answering them all.");
                    checkButtonClicked = false;
                }
                else
                {
                    CalculateScore();
                    CumulativeScore = CumulativeScore + Score;
                    CumulativeScorelbl.Content = "Cumulative Score: " + CumulativeScore;
                    checkButtonClicked = true;
                }

                
            }
            else
            {
                MessageBox.Show("Please Reset, You can't play a single game over and over. Learn with a new game rather.");
            }
        }
        private void HelpBtn_Click(object sender, EventArgs e)
                {
                    // Show a pop-up window with your help message
                    MessageBox.Show("How to Play:\n\nSelect an item on the left page and then select what you think its corresponding Call Number or Description is on the right page. They will match in colors as you go so you know what you have selected. Once you are done, click check button and see your Score.", "Help");
                }

        // methods need to move to IdentifyingAreas.cs
        private void CalculateScore()
        {
            Score = 0; // Reset the correctAnswers counter before checking.
            Counter = 0;

            // Iterate through each item in the left and right boxes.
            foreach (var leftItem in LeftBox.Items)
            {
                foreach (var rightItem in RightBox.Items)
                {
                    if (leftItem is string && rightItem is string)
                    {
                        ListBoxItem leftListBoxItem = (ListBoxItem)LeftBox.ItemContainerGenerator.ContainerFromItem(leftItem);
                        ListBoxItem rightListBoxItem = (ListBoxItem)RightBox.ItemContainerGenerator.ContainerFromItem(rightItem);

                        // Check if both items have the same background color (user's idea of a match).
                        if (leftListBoxItem.Background == rightListBoxItem.Background)
                        {
                            // If the background colors match, now check if the user's choice is correct.
                            if (IsUserSelectionCorrect(leftItem, rightItem))
                            {
                                // Increase the Score counter for each matching and correct pair.
                                Score++;
                            }
                            Counter++;
                        }
                    }
                }
            }

            // Display the correctAnswers count as a part of your score.
            Scorelbl.Content = "Score: " + Score;
        }
        private bool IsUserSelectionCorrect(object leftItem, object rightItem)
        {
            if (leftItem is string && rightItem is string)
            {
                string leftText = (string)leftItem;
                string rightText = (string)rightItem;

                if (keyside == true)
                {
                    if (Counter < identifyingAreas.questionsColumn.Count)
                    {
                        if (rightText.Equals(identifyingAreas.questionsColumn.ElementAt(Counter).Value))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (Counter < identifyingAreas.questionsColumn.Count)
                    {
                        if (rightText.Equals(identifyingAreas.questionsColumn.ElementAt(Counter).Key))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
