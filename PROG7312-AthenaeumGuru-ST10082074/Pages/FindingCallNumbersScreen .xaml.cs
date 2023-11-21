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
        private string b1, b2, b3, b4, t, temp, temp2, b1l3, b2l3,b3l3,b4l3;

        private int score = 0;
        private int tempLevel =0;

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
        }

        private void PopulateRandomNodes()
        {
            /*// Get 4 random second-level nodes
            List<TreeNode> randomSecondLevelNodes = _logic.GetRandomSecondLevelNodes(4);

            // Get random Fourth-level node from one of the second-level nodes
            _randomFourthLevelNode = _logic.GetRandomFourthLevelNode(randomSecondLevelNodes);

            // Get 4 random Third-level nodes under the same second-level node
            //List<TreeNode> randomThirdLevelNodes = _logic.GetRandomThirdLevelNodes(randomSecondLevelNodes, 4);
            //List<TreeNode> randomThirdLevelNodes = _logic.GetRandomThirdLevelNodes(_randomFourthLevelNode.Parent, 4);
            List<TreeNode> randomThirdLevelNodes = _logic.GetRandomThirdLevelNodes(_randomFourthLevelNode, 4);*/


            // Get 4 random second-level nodes
            List<TreeNode> randomSecondLevelNodes = _logic.GetRandomSecondLevelNodes(4);

            // Get 4 random third-level nodes under one of the randomly chosen second-level nodes
            List<TreeNode> randomThirdLevelNodes = _logic.GetRandomThirdLevelNodes(randomSecondLevelNodes[0], 4);

            // Get 1 random fourth-level node from the randomly chosen third-level nodes
            _randomFourthLevelNode = _logic.GetRandomFourthLevelNode(randomThirdLevelNodes);



            // Display random nodes on buttons and label
            Opt1btn.Content = $"{randomSecondLevelNodes[0].CallNumber}\n{randomSecondLevelNodes[0].Description}";
            b1 = $"{randomSecondLevelNodes[0].CallNumber}\t{randomSecondLevelNodes[0].Description}";

            Opt2btn.Content = $"{randomSecondLevelNodes[1].CallNumber}\n{randomSecondLevelNodes[1].Description}";
            b2 = $"{randomSecondLevelNodes[1].CallNumber}\t{randomSecondLevelNodes[2].Description}";

            Opt3btn.Content = $"{randomSecondLevelNodes[2].CallNumber}\n{randomSecondLevelNodes[2].Description}";
            b3 = $"{randomSecondLevelNodes[2].CallNumber}\t{randomSecondLevelNodes[2].Description}";

            Opt4btn.Content = $"{randomSecondLevelNodes[3].CallNumber}\n{randomSecondLevelNodes[3].Description}";
            b4 = $"{randomSecondLevelNodes[3].CallNumber}\t{randomSecondLevelNodes[3].Description}";

            t = _randomFourthLevelNode.CallNumber;
            FourthLevellbl.Content = $"{_randomFourthLevelNode.Description}";

            b1l3 = $"{randomThirdLevelNodes[0].CallNumber}\t{randomThirdLevelNodes[0].Description}";
            b2l3 = $"{randomThirdLevelNodes[1].CallNumber}\t{randomThirdLevelNodes[1].Description}";
            b3l3 = $"{randomThirdLevelNodes[2].CallNumber}\t{randomThirdLevelNodes[2].Description}";
            b4l3 = $"{randomThirdLevelNodes[3].CallNumber}\t{randomThirdLevelNodes[3].Description}";

            
        }

        private void Opt1btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 0;
            temp = b1;
            temp2 = b1l3;
        }
        private void Opt2btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 1;
            temp = b2;
            temp2 = b2l3;
        }
        private void Opt3btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 2;
            temp = b3;
            temp2 = b3l3;
        }
        private void Opt4btn_Click(object sender, RoutedEventArgs e)
        {
            selectedBook = 3;
            temp = b4;
            temp2 = b4l3;
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            sP = new StartPage();
            sP.Show();
            this.Close();
        }
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateRandomNodes();
        }
        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            //string callNumber = _randomSecondLevelNodes[0].CallNumber;
            if (selectedBook==-1)
            {
                MessageBox.Show("Try Again:\n\n Please select a Book on the right that matches the Text on the left page", "Help");
            }
            else
            {
                if (tempLevel == 0)//first round
                {
                    if (_logic.CheckUser(temp[0], t[0]))//Answer Correct
                    {
                        score++;
                        selectedBook = -1;
                        Scorelbl.Content = "Score: " + score;
                        MessageBox.Show($"Well Done:\n\nYou selected the Correct Answer.\n{_randomFourthLevelNode.Description} \nfalls under \n{temp}", "Yay");
                        tempLevel = 1;
                        temp = null;
                        NextLevel();
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect Answer:\n\nYou have sadly selected the wrong answer.\n{t} {_randomFourthLevelNode.Description}\ndoes not falls under \n{temp}", "Incorrect");
                        PopulateRandomNodes();
                    }
                }
                else if(tempLevel == 1)//second round
                {
                    if (_logic.CheckUser(temp2[1], t[1]))//Answer Correct
                    {
                        score++;
                        selectedBook = -1;
                        Scorelbl.Content = "Score: " + score;
                        MessageBox.Show($"Well Done:\n\nYou selected the Correct Answer.\n{t} {_randomFourthLevelNode.Description} \nfalls under \n{temp2}", "Yay");
                        tempLevel = 0;
                        PopulateRandomNodes();
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect Answer:\n\nYou have sadly selected the wrong answer.\n{t} {_randomFourthLevelNode.Description}\ndoes not falls under \n{temp2}", "Incorrect");

                        PopulateRandomNodes();
                    }
                }
                

            }
        }
        private void NextLevel() 
        {
            Opt1btn.Content = b1l3;

            Opt2btn.Content = b2l3;

            Opt3btn.Content = b3l3;

            Opt4btn.Content = b4l3;
        }
        private void HelpBtn_Click(object sender, EventArgs e)
        {
            // Show a pop-up window with your help message
            MessageBox.Show("How to Play:\n\nThe text on the left page is a third level Dewey Decimal catagory, the buttons on the right are First level catagories one of these corrospond with the catagory on the left. Select one of the right buttons that is the top level of the left third level text. Once you are done, click check button and see your Score.", "Help");
        }


    }
}
