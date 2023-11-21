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
using System.Windows.Shapes;

namespace PROG7312_AthenaeumGuru_ST10082074.Pages
{
    /// <summary>
    /// Interaction logic for ReOrderBooks.xaml
    /// </summary>
    public partial class ReOrderBooks : Window
    {
        private Border selectedBook = null; // Store the currently selected book
        private Border leftBook = null;// Stores Book to the left of selected book
        private Border rightBook = null;// Stores Book to the right of selected book

        private StartPage sP;
        private CallNumGen calNumGen;

        List<string> Books;
        List<string> Order;

        private int Score, HighScore;
        private bool Check = false;

        public ReOrderBooks()
        {
            InitializeComponent();
            UpdateBookNums();
        }
        //Updates all Books call numbers
        private void UpdateBookNums()
        {
            calNumGen = new CallNumGen();
            Books = calNumGen.GenerateList();
            Order = calNumGen.SortedOrder();
            //ClearLabels();
            Book1Label.Content = Books[0];
            Book2Label.Content = Books[1];
            Book3Label.Content = Books[2];
            Book4Label.Content = Books[3];
            Book5Label.Content = Books[4];
            Book6Label.Content = Books[5];
            Book7Label.Content = Books[6];
            Book8Label.Content = Books[7];
            Book9Label.Content = Books[8];
            Book10Label.Content = Books[9];

        }

        //Clears all Book Labels 
        private void ClearLabels()
        {
            Book1Label.Content = null;
            Book2Label.Content = null;
            Book3Label.Content = null;
            Book4Label.Content = null;
            Book5Label.Content = null;
            Book6Label.Content = null;
            Book7Label.Content = null;
            Book8Label.Content = null;
            Book9Label.Content = null;
            Book10Label.Content = null;

            Scorelbl.Content = "Score: ";
        }

        //Retrns User to Home Page
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            sP = new StartPage();
            sP.Show();
            this.Close();
        }

        //Resets the Books to a new Game
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearLabels();
            UpdateBookNums();

            selectedBook = null;
            //Clears all Border Highlights
            ClearHighlights();

            //ReEnable Left an Right Buttons
            LeftBtn.IsEnabled = true;
            RightBtn.IsEnabled = true;

            Check = false;
        }

        // Event handlers for clicking on a book
        private void Book1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }

            }
        }
        private void Book2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }
        private void Book10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBook)
            {
                // Deselect the previously selected book (if any)
                if (selectedBook != null && Check == false)
                {
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                    selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
                }
                if (Check == false)
                {
                    // Select the clicked book
                    selectedBook = clickedBook;
                    selectedBook.BorderBrush = new SolidColorBrush(Colors.HotPink);
                    selectedBook.BorderThickness = new Thickness(3); // Highlight the selected book
                }
            }
        }

        //to move the books Left or Right
        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            leftBook = null; rightBook = null;
            if (selectedBook != null && (Canvas.GetLeft(selectedBook) != 918))
            {
                // Get the Canvas.Left position of the selected book
                double selectedBookLeft = Canvas.GetLeft(selectedBook);

                foreach (var child in BookCanvas.Children)
                {
                    if (child is Border book)
                    {
                        double bookLeft = Canvas.GetLeft(book);

                        if (book != selectedBook)
                        {
                            if (bookLeft < selectedBookLeft)
                            {
                                // This book is to the left of the selected book
                                if (leftBook == null || bookLeft > Canvas.GetLeft(leftBook))
                                {
                                    leftBook = book;
                                }
                            }
                            else if (bookLeft > selectedBookLeft)
                            {
                                // This book is to the right of the selected book
                                if (rightBook == null || bookLeft < Canvas.GetLeft(rightBook))
                                {
                                    rightBook = book;

                                }
                            }
                        }
                    }
                }
                //Swap the 2 books positions
                Canvas.SetLeft(selectedBook, Canvas.GetLeft(selectedBook) + 102);
                Canvas.SetLeft(rightBook, Canvas.GetLeft(rightBook) - 102);
            }
        }
        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            leftBook = null; rightBook = null;
            if (selectedBook != null && (Canvas.GetLeft(selectedBook) != 0))
            {
                // Get the Canvas.Left position of the selected book
                double selectedBookLeft = Canvas.GetLeft(selectedBook);

                foreach (var child in BookCanvas.Children)
                {
                    if (child is Border book)
                    {
                        double bookLeft = Canvas.GetLeft(book);

                        if (book != selectedBook)
                        {
                            if (bookLeft < selectedBookLeft)
                            {
                                // This book is to the left of the selected book
                                if (leftBook == null || bookLeft > Canvas.GetLeft(leftBook))
                                {
                                    leftBook = book;
                                }
                            }
                            else if (bookLeft > selectedBookLeft)
                            {
                                // This book is to the right of the selected book
                                if (rightBook == null || bookLeft < Canvas.GetLeft(rightBook))
                                {
                                    rightBook = book;

                                }
                            }
                        }
                    }
                }
                //Swap the 2 books positions
                Canvas.SetLeft(selectedBook, Canvas.GetLeft(selectedBook) - 102);
                Canvas.SetLeft(leftBook, Canvas.GetLeft(leftBook) + 102);
            }
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Scorelbl.Content = "Score: ";
            Score = 0;
            Check = true;
            // Deselect the previously selected book (if any)
            if (selectedBook != null)
            {
                selectedBook.BorderBrush = new SolidColorBrush(Colors.Black);
                selectedBook.BorderThickness = new Thickness(1); // Reset the border thickness
            }

            //Disable Left an Right Buttons
            LeftBtn.IsEnabled = false;
            RightBtn.IsEnabled = false;

            Books.Sort();

            int Count = 0;

            foreach (UIElement element in BookCanvas.Children)
            {
                if (element is Border bookBorder)
                {
                    double left = Canvas.GetLeft(bookBorder);

                    //Compares position of book to the order it should be in
                    if (left.ToString().Equals(Order[Count]))
                    {

                        bookBorder.BorderBrush = new SolidColorBrush(Colors.Green);
                        bookBorder.BorderThickness = new Thickness(5); // Highlight the book Thats at the correct Position in Green
                        Count++;
                        Score++;
                    }
                    else
                    {
                        bookBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                        bookBorder.BorderThickness = new Thickness(5); // Highlight the book Thats at the incorrect Position in red
                        Count++;
                    }
                }
            }
            Scorelbl.Content = Scorelbl.Content + Score.ToString() + "/10";
            CheckHighScore();
        }

        private void ClearHighlights()
        {
            Book1.BorderBrush = new SolidColorBrush(Colors.Black);
            Book1.BorderThickness = new Thickness(1);

            Book2.BorderBrush = new SolidColorBrush(Colors.Black);
            Book2.BorderThickness = new Thickness(1);

            Book3.BorderBrush = new SolidColorBrush(Colors.Black);
            Book3.BorderThickness = new Thickness(1);

            Book4.BorderBrush = new SolidColorBrush(Colors.Black);
            Book4.BorderThickness = new Thickness(1);

            Book5.BorderBrush = new SolidColorBrush(Colors.Black);
            Book5.BorderThickness = new Thickness(1);

            Book6.BorderBrush = new SolidColorBrush(Colors.Black);
            Book6.BorderThickness = new Thickness(1);

            Book7.BorderBrush = new SolidColorBrush(Colors.Black);
            Book7.BorderThickness = new Thickness(1);

            Book8.BorderBrush = new SolidColorBrush(Colors.Black);
            Book8.BorderThickness = new Thickness(1);

            Book9.BorderBrush = new SolidColorBrush(Colors.Black);
            Book9.BorderThickness = new Thickness(1);

            Book10.BorderBrush = new SolidColorBrush(Colors.Black);
            Book10.BorderThickness = new Thickness(1);
        }

        private void CheckHighScore()
        {
            if (HighScore < Score)
            {
                HighScore = Score;
                HighScorelbl.Content = "Your HighScore: " + HighScore.ToString() + "/10";
            }
        }
    }
}
