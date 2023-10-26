using System;
using System.Collections;
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

namespace ProgPartOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables
        DoublyLinkedList<string> linkedlist = new DoublyLinkedList<string>();
        Random random = new Random(); // Create a Random object for generating random numbers
        int count = 0; // for badge
        public MainWindow()
        {
            InitializeComponent();
        }

        // Method to generate random letters
        static string GenerateRandomLetters(Random random, string alphabet, int count)
        {
            char[] letters = new char[count];

            for (int i = 0; i < count; i++)
            {
                // Select a random index within the alphabet
                int index = random.Next(0, alphabet.Length);

                // Add the randomly selected letter to the result
                letters[i] = alphabet[index];
            }

            return new string(letters);
        }

        // Method to generate a random call number based
        public string GenerateRandomCallNumber(Random random)
        {
            // Generate a random integer between 100 and 999 (3-digit number)
            int integerPart = random.Next(100, 1000);

            // Generate a random decimal between 0 and 0.999 (3 decimal places)
            double decimals = random.NextDouble();
            double decimalPart = Math.Round(decimals, 3);

            // Combine the integer and decimal parts to form the final number
            double randomNumber = integerPart + decimalPart;

            return Convert.ToString(randomNumber);
        }

        //method to send numbers to the listbox
        public void updatedListBox()
        {
            callNumList.Items.Clear();
            foreach (var item in linkedlist)
            {
                callNumList.Items.Add(item);
            }
        }

        private void ListBoxItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;
                if (draggedItem != null)
                {
                    //allow the drag drop to happen
                    DragDrop.DoDragDrop(draggedItem, draggedItem.Content,
                        DragDropEffects.Move);
                }
            }

        }
        private void ListBoxItem_Drop(object sender, DragEventArgs e)
        {
            ListBoxItem targetItem = sender as ListBoxItem;
            if (targetItem != null)
            {
                int targetIndex = callNumList.Items.IndexOf(targetItem.Content);
                int draggedItem = linkedlist.IndexOf((string)e.Data.GetData(typeof(string)));

                if (targetIndex >= 0 && draggedItem >= 0)
                {
                    linkedlist.Move(draggedItem, targetIndex);
                    updatedListBox();// update method to refresh
                }
            }
        }

        private bool IsAscendingOrder(ItemCollection items)
        {
            //sorting method - bubble sort
            for (int i = 0; i < items.Count - 1; i++)
            {
                if (string.Compare(items[i].ToString(), items[i + 1].ToString()) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void startImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            callNumList.Items.Clear();
            linkedlist.Clear();
            // Define the alphabet
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Generate and save 10 call numbers in the list
            for (int i = 0; i < 10; i++)
            {
                string Number = GenerateRandomCallNumber(random);
                string randomLetters = GenerateRandomLetters(random, alphabet, 3);
                string callNumber = Number + " " + randomLetters;
                linkedlist.Add(callNumber);
            }

            updatedListBox(); //updates listbox
        }

        private void submitImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var items = callNumList.Items; // variable of listbox

            if (IsAscendingOrder(items)) //perform ascending order check
            {
                MessageBox.Show("You arranged the numbers in ascending order. Excellent work!", "Successful", MessageBoxButton.OK, MessageBoxImage.Information); //success message

                //gamification feature - badges
                count++; //increase correct answer count
                switch (count)
                {
                    case 1: //if user has 1 correct answer
                        if (oneCorrect.IsOpen)
                        {
                            oneCorrect.IsOpen = false;
                        }
                        else
                        {
                            oneCorrect.IsOpen = true;
                        }
                        break;
                    case 5: //if user has 5 correct answers
                        if (fiveCorrect.IsOpen)
                        {
                            fiveCorrect.IsOpen = false;
                        }
                        else
                        {
                            fiveCorrect.IsOpen = true;
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("You did not arrange the numbers in ascending order. Please try again!", "Unsuccessful", MessageBoxButton.OK, MessageBoxImage.Information); //fail message
            }
        }

        private void returnImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home hm = new Home(); //object of main window
            hm.Show();

            // Close the current window
            this.Close();
        }

        private void helpImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //help message
            MessageBox.Show("To begin the training, press the play button. There will be ten call numbers presented, and you must sort them in ascending order (lowest to highest)." +
                " This is accomplished by dragging a number from the listbox and inserting it in its proper spot with your mouse." +
                " To enter your response, click the submit button. A popup message will display your results.", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

        }
        public Node head;//start
        public Node tail;//end

        // method to add values
        public void Add(T value)
        {
            Node newNode = new Node { Value = value };
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public int IndexOf(T value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                // it needs  to compare the 2 values
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                    return index;
                index++;
                current = current.Next;
            }
            //once the position --> ie item is sorted
            //take away that slot as well
            return -1;
        }

        public void Move(int sourceIndex, int destinationIndex)
        {
            //check while you move things around in this list ?
            if (sourceIndex < 0 || sourceIndex >= Count
                || destinationIndex < 0 || destinationIndex >= Count)
                return;

            Node sourceNode = GetNodeAtIndex(sourceIndex); //it will add the method in a bit
            Node destNode = GetNodeAtIndex(destinationIndex); //will add the method in a bit

            T temp = sourceNode.Value;
            sourceNode.Value = destNode.Value; //flipping them around
            destNode.Value = temp; //flipping them around
        }

        private Node GetNodeAtIndex(int index)
        {
            //right click and choose generate method to get this
            //remove throws
            Node current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;//will move onto the next node
            }
            return current;
        }

        public void Clear()
        {
            while (head != null)
            {
                Node temp = head;
                head = head.Next;
                temp = null; // Remove the node from memory
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                Node current = head;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }
    }
}
