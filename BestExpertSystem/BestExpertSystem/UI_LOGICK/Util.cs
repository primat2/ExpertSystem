using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;


namespace BestExpertSystem.UI_LOGICK
{
    class Util
    {

        public static ListViewItem ListViewItemUnderMouse(ListView lv, Point p)
        {
            var point = lv.PointToClient(p);
            ListViewItem item = lv.GetItemAt(point.X, point.Y);
            return item;
        }

        public static void AddToListBox(ListView listView, List<string> values)
        {
            foreach (string value in values)
            {

                ListViewItem lstViewItem = listView.Items.Add(value);
                //lstViewItem.SubItems.Add(desc);
                //lstViewItem.SubItems.Add(content);
            }
        }


        public static void AddToListView(ListView listView, INFRASTRUCTURE.IOrdered value)
        {
            if (value is MODEL.Rule)
            {
                AddToListView(listView, value as MODEL.Rule);
            }
            else if (value is MODEL.Domain)
            {
                AddToListView(listView, value as MODEL.Domain);

            }
            else if (value is MODEL.Variable)
            {
                AddToListView(listView, value as MODEL.Variable);
            }
            else
            {
                throw new Exception("HZ");
            }
          
         
        }

        // ****************************
        // *** Adding to list views ***
        // ****************************

        public static void AddToListView(ListView listView, MODEL.Rule rule)
        {
            var lvi = listView.Items.Add(rule.Order.ToString());
            lvi.SubItems.Add(rule.name);
        }

        public static void AddToListView(ListView listView, MODEL.Domain domain)
        {
            var lvi = listView.Items.Add(domain.Order.ToString());
            lvi.SubItems.Add(domain.name);
            string values = "";
            foreach (var value in domain.values)
            {
                values = values + value + " ";
            }
            lvi.SubItems.Add(values);
        }

        public static void AddToListView(ListView listView, MODEL.Variable variable)
        {
            var lvi = listView.Items.Add(variable.Order.ToString());
            lvi.SubItems.Add(variable.name);
            lvi.SubItems.Add(variable.domain.ToString());
            lvi.SubItems.Add(variable.variableType.ToString());
        }

        public static void AddToListView(ListView listView, string variable)
        {
            var lvi = listView.Items.Add(variable);
        }

        public static void AddToListView(ListView listView, MODEL.VariableValue variable)
        {
            var lvi = listView.Items.Add(variable.Value);
        }



        public static List<string> ListViewToList(ListView listView)
        {
            return listView.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
        }



        public static void ItemDrag()
        {

        }


        public static DragDropEffects GetDragOverEffect(ListView listView, DragEventArgs e, bool isMouseOverListView = false)
        {
            ListViewItem item = UI_LOGICK.Util.ListViewItemUnderMouse(listView, new Point(e.X, e.Y));


            if (item != null)
            {
                return DragDropEffects.Move;
            }
            else if (isMouseOverListView)
            {
                return DragDropEffects.Link;
            }
            else
            {
                return  DragDropEffects.None;

            }
        }

        public static DragDropEffects GetDragEnterEffect(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                return DragDropEffects.Move;
            else
                return DragDropEffects.None;
        }

        public static void DoDragDrop<T>(ListView listView, int dragIndex, DragEventArgs e, DATA_TYPES.OrderedList<T> values)
            where T : INFRASTRUCTURE.IOrdered
        {
            ListViewItem itemUnderMouse = UI_LOGICK.Util.ListViewItemUnderMouse(
                listView, new Point(e.X, e.Y));

            int newPos = itemUnderMouse.Index;
            int oldPos = dragIndex;

            if (newPos == oldPos) return;

            var deleted = values.RemoveAt(oldPos);
            values.Insert(deleted, newPos);


            UI_LOGICK.Util.UpdateListView(listView, values);
        }


        public static void UpdateListView<T> (ListView listView, DATA_TYPES.OrderedList<T> values) where T : INFRASTRUCTURE.IOrdered
        {
            listView.Items.Clear();
            foreach (var rule in values)
            {
                UI_LOGICK.Util.AddToListView(listView, rule);
            }
        }

        public static void UpdateListView(ListView listView, List<string> values)
        {
            listView.Items.Clear();
            foreach (string rule in values)
            {
                UI_LOGICK.Util.AddToListView(listView, rule);
            }
        }

        public static void UpdateListView(ListView listView, List<MODEL.VariableValue> values)
        {
            listView.Items.Clear();
            foreach (var rule in values)
            {
                UI_LOGICK.Util.AddToListView(listView, rule);
            }
        }
    }
}
