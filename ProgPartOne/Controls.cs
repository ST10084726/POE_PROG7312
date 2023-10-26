using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPartOne
{
    public class Controls
    {
        //method to swap the indexes -- 1 -7 
        public static void SwapIndexes(int change, ListBox listBox)
        {
            // first ensure the item is selected 
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
            {
                return;
            }

            // target destination 
            int newIndex = listBox.SelectedIndex + change;
            //ensure new destination exists 
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return;

            //object selected 
            object selected = listBox.SelectedItem;
            //insert into a new location 
            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SelectedIndex = newIndex;
        }


        public static void randomizeList(ListBox listbox)
        {
            // new listype of
            var list = new List<string>();
            Random rand = new Random();  // to gen a new list 

            list = listbox.Items.Cast<String>().ToList();

            //shuffle the list items 
            int n = list.Count;
            while (n > 1)
            {
                int k = rand.Next(n);
                n--; //decrements the value
                string value = list[k];
                list[k] = list[n]; //swapping
                list[n] = value;
            }
            listbox.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                listbox.Items.Add(list[i]);
            }


        }
    }
}

