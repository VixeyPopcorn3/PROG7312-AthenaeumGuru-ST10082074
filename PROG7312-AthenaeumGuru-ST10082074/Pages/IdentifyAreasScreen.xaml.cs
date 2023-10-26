using PROG7312_AthenaeumGuru_ST10082074.Classes;
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

        public IdentifyAreasScreen()
        {
            InitializeComponent();
            identifyingAreas = new IdentifyingAreas();
            PopulateLeftBoxWithRandomItems(LeftBox);
            PopulateRightBoxWithRandomItems(RightBox);
        }
        

        /*private void LeftBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox leftBox = (ListBox)sender;

            if (leftBox.SelectedItem != null)
            {
                // Check if there's a previously selected item
                if (leftBox.SelectedItem != null)
                {
                    ListBoxItem previousItem = (ListBoxItem)leftBox.ItemContainerGenerator.ContainerFromItem(leftBox.SelectedItem);
                    if (previousItem != null)
                    {
                        // Restore the previous item's background color
                        if (itemBackgroundColors.ContainsKey(previousItem))
                        {
                            previousItem.Background = itemBackgroundColors[previousItem];
                        }
                    }
                }

                // Generate a random color for the newly selected item
                Color randomColor = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                SolidColorBrush brush = new SolidColorBrush(randomColor);

                // Store the background color of the selected item
                ListBoxItem listBoxItem = (ListBoxItem)leftBox.ItemContainerGenerator.ContainerFromItem(leftBox.SelectedItem);
                if (listBoxItem != null)
                {
                    if (!itemBackgroundColors.ContainsKey(listBoxItem))
                    {
                        itemBackgroundColors[listBoxItem] = (SolidColorBrush)listBoxItem.Background;
                    }
                    listBoxItem.Background = brush;
                }
            }
        }*/

        private void LeftBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//changing the colour of the selected item
        {
            ListBox leftBox = (ListBox)sender;

            if (leftBox.SelectedItem != null)
            {
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



        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            sP = new StartPage();
            sP.Show();
            this.Close();
        }
        private void PopulateLeftBoxWithRandomItems(ListBox listBox)
        {
            listBox.Items.Clear(); // Clear the list box first

            Dictionary<string, string> items = new Dictionary<string, string>();

            // Add (questions) to the dictionary
            foreach (var pair in identifyingAreas.questionsColumn)
            {
                items[pair.Key] = pair.Value;
            }

            // Randomize the order of items
            var randomizedItems = items.OrderBy(x => random.Next()).ToDictionary(pair => pair.Key, pair => pair.Value);

            // Decide whether to show keys or values on the right
            bool showKeysOnRight = random.Next(2) == 0; // 50% chance

            foreach (var item in randomizedItems)
            {
                string textToShow = showKeysOnRight ? item.Key : item.Value;
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
                string textToShow = showKeysOnRight ? item.Key : item.Value;
                listBox.Items.Add(textToShow);
            }
        }
    }
}
