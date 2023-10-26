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

namespace ProgPartOne
{
    /// <summary>
    /// Interaction logic for Area.xaml
    /// </summary>
    public partial class Area : Window
    {
        private Dictionary<string, string> deweySystem;
        private int score;
        private int questionsAnswered;
        private List<string> currentOptions;
        private bool isMatchingCallNumber;
        private const int OptionsCount = 4;

        public Area()
        {
            InitializeComponent();
           
        }
        private void QuizText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Quiz qz = new Quiz();
            qz.Show();
            this.Close();
        }

        private void AnswerText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Answer Messages
            MessageBox.Show(
                "The following are the answers to the next quiz. Kindly explore.\n\n" +
                "000-099: General Works\n" +
                "100-199: Philosophy and Psychology\n" +
                "200-299: Religion\n" +
                "300-399: Social Sciences\n" +
                "400-499: Language\n" +
                "500-599: Natural Sciences and Mathematics\n" +
                "600-699: Technology\n" +
                "700-799: The Arts\n" +
                "800-899: Literature and Rhetoric\n" +
                "900-999: History, Biography and Geography",
                "Quiz Answers", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void HowText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //How to play message box
            string instructions = "Welcome to the Matching Column Game!\n\n" +
                                 "The goal of the game is to match the given ranges of numbers to their respective categories.\n\n" +
                                 "You will see a list of ranges on one side and a list of category names on the other side.\n\n" +
                                 "To play the game:\n\n" +
                                 "1. Click and drag a range to its matching category.\n" +
                                 "2. Release the mouse button to drop the range into the category.\n" +
                                 "3. Continue matching the remaining ranges to their categories.\n\n" +
                                 "Have fun matching the columns and exploring the knowledge!";

            MessageBox.Show(instructions, "How to Play Matching Column Game", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void exitImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();

        }
    }
}
