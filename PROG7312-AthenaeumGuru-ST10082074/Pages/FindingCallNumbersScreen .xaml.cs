using PROG7312_AthenaeumGuru_ST10082074.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Shapes;

namespace PROG7312_AthenaeumGuru_ST10082074.Pages
{
    /// <summary>
    /// Interaction logic for FindingCallNumbers.xaml
    /// </summary>
    public partial class FindingCallNumbersScreen : Window
    {
        private readonly Tree _deweyTree;
        private readonly FindingCallNumbers _logic;
        private List<TreeNode> _randomSecondLevelNodes;
        private TreeNode _randomFourthLevelNode;
        private StartPage sP;

        private int selectedBook = -1; // Store the currently selected book
        private string b1, b2, b3, b4, t, temp, temp2, b1l3, b2l3,b3l3,b4l3; //temp values 

        private int score = 0;///for tracking current score
        private int tScore = 0;//for tracking Total score
        private int tempLevel =0;// for tracking current level
        private bool music = true;

        // Constructor: Initializes the FindingCallNumbersScreen class, loads the Dewey Decimal System tree, and populates random nodes.
        public FindingCallNumbersScreen()
        {
            InitializeComponent();

            // Load Dewey Decimal System tree
            string filePath = "C:\\Users\\zanne\\source\\repos\\PROG7312-AthenaeumGuru-ST10082074\\PROG7312-AthenaeumGuru-ST10082074\\Resources\\DeweyDecimal.txt";
            _deweyTree = TreeNode.BuildDeweyTree(filePath);

            // Initialize logic class with the tree
            _logic = new FindingCallNumbers(_deweyTree);

            // Populate buttons and label with random nodes
            PopulateRandomNodes();

            // To play the music
            backgroundMusic.Play();
        }

        private void Musicbtn_Click(object sender, RoutedEventArgs e)
        {
            if(music)
            {
                // To pause the music
                backgroundMusic.Pause();
                music = false;
            }
            else
            {
                // To play the music
                backgroundMusic.Play();
                music = true;
            }
        }

        // PopulateRandomNodes: Populates the buttons and label with random Cattagories.
        private void PopulateRandomNodes()
        {
            // Get 4 random second-level nodes
            List<TreeNode> randomSecondLevelNodes = _logic.GetRandomSecondLevelNodes(4);

            // Get 4 random third-level nodes under one of the randomly chosen second-level nodes
            List<TreeNode> randomThirdLevelNodes = _logic.GetRandomThirdLevelNodes(randomSecondLevelNodes[0], 4);

            // Get 1 random fourth-level node from the randomly chosen third-level nodes
            _randomFourthLevelNode = _logic.GetRandomFourthLevelNode(randomThirdLevelNodes);



            // Display random second level catagories on buttons
            Opt1btn.Content = $"{randomSecondLevelNodes[0].CallNumber}\n{randomSecondLevelNodes[0].Description}";
            b1 = $"{randomSecondLevelNodes[0].CallNumber}\t{randomSecondLevelNodes[0].Description}";

            Opt2btn.Content = $"{randomSecondLevelNodes[1].CallNumber}\n{randomSecondLevelNodes[1].Description}";
            b2 = $"{randomSecondLevelNodes[1].CallNumber}\t{randomSecondLevelNodes[2].Description}";

            Opt3btn.Content = $"{randomSecondLevelNodes[2].CallNumber}\n{randomSecondLevelNodes[2].Description}";
            b3 = $"{randomSecondLevelNodes[2].CallNumber}\t{randomSecondLevelNodes[2].Description}";

            Opt4btn.Content = $"{randomSecondLevelNodes[3].CallNumber}\n{randomSecondLevelNodes[3].Description}";
            b4 = $"{randomSecondLevelNodes[3].CallNumber}\t{randomSecondLevelNodes[3].Description}";

            // Display random fourth level catagory on label
            t = _randomFourthLevelNode.CallNumber;
            FourthLevellbl.Content = $"{_randomFourthLevelNode.Description}";

            //stores third level catagories for next level
            b1l3 = $"{randomThirdLevelNodes[0].CallNumber}\t{randomThirdLevelNodes[0].Description}";
            b2l3 = $"{randomThirdLevelNodes[1].CallNumber}\t{randomThirdLevelNodes[1].Description}";
            b3l3 = $"{randomThirdLevelNodes[2].CallNumber}\t{randomThirdLevelNodes[2].Description}";
            b4l3 = $"{randomThirdLevelNodes[3].CallNumber}\t{randomThirdLevelNodes[3].Description}";


            
        }

        // Opt1btn_Click: Event handler for the first book click, stores information about the selected book.
        private void Opt1btn_Click(object sender, RoutedEventArgs e)
        {
            Opt1btn.BorderThickness = new Thickness(3);
            selectedBook = 0;
            temp = b1;
            temp2 = b1l3;
        }

        // Opt2btn_Click: Event handler for the second book click, stores information about the selected book.
        private void Opt2btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 1;
            temp = b2;
            temp2 = b2l3;
        }

        // Opt3btn_Click: Event handler for the third book click, stores information about the selected book.
        private void Opt3btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 2;
            temp = b3;
            temp2 = b3l3;
        }

        // Opt4btn_Click: Event handler for the fourth book click, stores information about the selected book.
        private void Opt4btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 3;
            temp = b4;
            temp2 = b4l3;
        }

        // ReturnBtn_Click: Event handler for the return button click, resets scores and returns to the start page.
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            tScore = 0;
            // Stop the background music when the window is closed
            backgroundMusic.Stop();
            sP = new StartPage();
            sP.Show();
            this.Close();
        }

        // ResetBtn_Click: Event handler for the reset button click, repopulates the random catagories.
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateRandomNodes();
        }

        // CheckBtn_Click: Event handler for the check button click, checks the user's answer and updates scores.
        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBook == -1)
            {
                MessageBox.Show("Try Again:\n\n Please select a Book on the right that matches the Text on the left page", "Help");
            }
            else
            {
                if (tempLevel == 0)//first round
                {
                    if (_logic.CheckUser(temp[0], t[0]))//Answer Correct
                    {
                        tScore++;
                        score++;
                        selectedBook = -1;
                        Scorelbl.Content = "Score: " + score;
                        TotalScorelbl.Content = "Total Score: " + tScore;
                        MessageBox.Show($"Well Done:\n\nYou selected the Correct Answer.\n{_randomFourthLevelNode.Description} \nfalls under \n{temp}", "Yay");
                        tempLevel = 1;
                        temp = null;
                        NextLevel();
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect Answer:\n\nYou have sadly selected the wrong answer.\n{t} {_randomFourthLevelNode.Description}\ndoes not falls under \n{temp}", "Incorrect");
                        score = 0;
                        PopulateRandomNodes();
                    }
                }
                else if(tempLevel == 1)//second round
                {
                    if (_logic.CheckUser(temp2[1], t[1]))//Answer Correct
                    {
                        tScore++;
                        score++;
                        selectedBook = -1;
                        Scorelbl.Content = "Score: " + score;
                        TotalScorelbl.Content = "Total Score: " + tScore;
                        MessageBox.Show($"Well Done:\n\nYou selected the Correct Answer.\n{t} {_randomFourthLevelNode.Description} \nfalls under \n{temp2}", "Yay");
                        tempLevel = 0;
                        score = 0;
                        PopulateRandomNodes();
                        
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect Answer:\n\nYou have sadly selected the wrong answer.\n{t} {_randomFourthLevelNode.Description}\ndoes not falls under \n{temp2}", "Incorrect");
                        score = 0;
                        tempLevel = 0;
                        PopulateRandomNodes();
                    }
                }
                

            }
        }

        // NextLevel: Switches to the next level of the game by updating button contents.
        private void NextLevel() 
        {
            Opt1btn.Content = b1l3;

            Opt2btn.Content = b2l3;

            Opt3btn.Content = b3l3;

            Opt4btn.Content = b4l3;
        }

        // HelpBtn_Click: Event handler for the help button click, displays a pop-up help message on how to play the game.
        private void HelpBtn_Click(object sender, EventArgs e)
        {
            // Show a pop-up window with your help message
            MessageBox.Show("How to Play:\n\nThe text on the left page is a third level Dewey Decimal catagory, the buttons on the right are First level catagories one of these corrospond with the catagory on the left. Select one of the right buttons that is the top level of the left third level text. Once you are done, click check button and see your Score.", "Help");
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            // Stop the background music when the window is closed
            backgroundMusic.Stop();
        }

    }
}
