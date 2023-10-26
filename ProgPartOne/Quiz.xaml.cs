using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgPartOne
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        public Quiz()
        {
            InitializeComponent();
            loadDefaults();
            repopulateLists();
        }
        public static int qCount = 4;
        public static bool callQ = true;
        public static int myScore;
        public static int maxScore;
        Random rnd = new Random();


        IDictionary<string, string> baseQuestions = new Dictionary<string, string>();
        IDictionary<string, string> usedQuestions = new Dictionary<string, string>();

        private void loadDefaults()
        {
            baseQuestions.Clear();
            usedQuestions.Clear();
            //List of possible questions 
            baseQuestions.Add("000-099", "General Works");
            baseQuestions.Add("100-199", "Philosophy and Pyschology");
            baseQuestions.Add("200-299", "Religion");
            baseQuestions.Add("300-399", "Social Sciences");
            baseQuestions.Add("400-499", "Language");
            baseQuestions.Add("500-599", "Natural Sciences and Mathematics");
            baseQuestions.Add("600-699", "Technology");
            baseQuestions.Add("700-799", "The Arts");
            baseQuestions.Add("800-899", "Literature and Rhetoric");
            baseQuestions.Add("900-999", "History, Biography and Geography");
        }

        internal static void FindChildren<T>(List<T> results, DependencyObject startNode)
            where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(startNode);
            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
                if ((current.GetType()).Equals(typeof(T)) ||
                        (current.GetType()).GetTypeInfo().IsSubclassOf(typeof(T)))
                {
                    T asType = (T)current;
                    results.Add(asType);
                }
                FindChildren<T>(results, current);
            }
        }

        //method to calc score 
        private int CalcScore()
        {
            int score = 0;
            List<ListBoxItem> list = new List<ListBoxItem>();
            FindChildren(list, BoxTwo);
            for (int i = 0; i < qCount; i++)
            {
                string callNumber;
                string description;
                if (!callQ)
                {
                    callNumber = BoxOne.Items[i].ToString();
                    description = BoxTwo.Items[i].ToString();
                }
                else
                {
                    //flip LB around
                    callNumber = BoxTwo.Items[i].ToString();
                    description = BoxOne.Items[i].ToString();
                }
                //now deal with the used qs and qs 
                if (usedQuestions[callNumber] == description)
                {
                    //pick a color to light them up 
                    list[i].Background = new SolidColorBrush(Colors.Green);
                    //add onto the score 
                    score++;
                }
                else
                {
                    //pick another color to light them up 
                    list[i].Background = new SolidColorBrush(Colors.Red);

                }
            }
            for (int i = qCount; i < BoxTwo.Items.Count; i++)
            {
                //pick another color to light them up 
                list[i].Background = new SolidColorBrush(Colors.Gray);
            }
            return score;
        }//Method Ends 

        private void repopulateLists()
        {
            BoxTwo.Items.Clear();
            BoxOne.Items.Clear();
            //alternate btwn call numbers and descriptions 
            if (callQ)
            {

                //Generate 4 callNo + 4 desc
                for (int i = 0; i < 4; i++)
                {
                    getKVP(out string callNo, out string desc);
                    BoxOne.Items.Add(callNo);
                    BoxTwo.Items.Add(desc);
                }
                //generate 3 more 
                for (int i = 0; i < 3; i++)
                {
                    getKVP(out _, out string desc);
                    BoxTwo.Items.Add(desc);
                }
                //prep alt 
                callQ = false;
            }
            else
            {


                //Generate 4 desc + 4 callNos
                for (int i = 0; i < 4; i++)
                {
                    getKVP(out string callNo, out string desc);
                    BoxOne.Items.Add(desc);
                    BoxTwo.Items.Add(callNo);
                }
                //Generate 3 more
                for (int i = 0; i < 3; i++)
                {
                    getKVP(out string callNo, out _);
                    BoxTwo.Items.Add(callNo);

                }
                //prep alt 
                callQ = true;
            }

            //TODO Randomize lists 
            Controls.randomizeList(BoxOne);
            Controls.randomizeList(BoxTwo);
            //recolor()
            ScoreTb.Text = "Match Columns";
        }

        private void restartImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to start a new game",
                   "This will reset your score", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                myScore = 0;
                maxScore = 0;
                ScoreTb.Text = "Match Columns";
            }
            else
            {
                return;
            }
            loadDefaults();
            repopulateLists();
            submitImg.Visibility = Visibility.Visible;

        }

        private void submitImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int score = CalcScore();

            loadDefaults();
            myScore += score; // Add to the score
            maxScore += qCount; // Ensure the maximum score doesn't exceed a certain value (e.g., 4)

            if (score == 4)
            {
                // Display a badge notification for a perfect score
                MessageBox.Show("Congratulations! You earned the Perfect Score Badge.", "Badge Unlocked");
            }
            else if (score == 0)
            {
                // Display a message to encourage the user to try better next time
                MessageBox.Show("Try better next time!", "Feedback");
            }
            else
            {
                // Provide feedback to the user
                MessageBox.Show("Well done!", "Feedback");
            }

            ScoreTb.Text = "Score: " + myScore + "/" + maxScore;
            submitImg.Visibility = Visibility.Hidden;


        }

        private void downImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //down btn
            Controls.SwapIndexes(1, BoxTwo);
            //can pull the recolor option here

        }

        private void upImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //up btn
            Controls.SwapIndexes(-1, BoxTwo);
            //can pull the recolor option here
        }

        //Dictionary --kvp -- method
        private void getKVP(out string call, out string desc)
        {
            KeyValuePair<string, string> kvp;
            int index = rnd.Next(baseQuestions.Count());
            kvp = baseQuestions.ElementAt(index);
            usedQuestions.Add(kvp);
            baseQuestions.Remove(kvp);
            call = kvp.Key;
            desc = kvp.Value;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Area ar = new Area();
            ar.Show();
            this.Close();
        }
    }
}
