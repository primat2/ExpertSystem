using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
//using System.Windows.Controls;



namespace BestExpertSystem.Forms_ES
{
    public partial class ExplanationForm : Form
    {

        private readonly MODEL.MemoryComponent workingMemory;
        private bool isExpanded;


        public ExplanationForm(MODEL.MemoryComponent WorkingMemory)
        {
            workingMemory = WorkingMemory;
            InitializeComponent();

            this.isExpanded = false;
            //foreach (var fact in workingMemory.TrueFacts)
            //{
            //    this.lvVars.Items.Add(new ListBoxItem
            //    {
            //        Content = fact.ToString,
            //        Tag = fact
            //    });
            //}
            this.InitializeTreeView();
            //tvRules.SelectedItemChanged += HighLite;
            //lvVars.SelectionMode = SelectionMode.Multiple;
        }


        private void InitializeTreeView()
        {
            this.InitializeTreeViewItem(this.workingMemory.GoalVariable);
        }

        private void InitializeTreeViewItem(MODEL.Variable variable, TreeNode parent = null)
        {
            var str1 = "ЦЕЛЬ: " + variable.name;

            var fact1 = this.workingMemory
                .TrueFacts
                .FirstOrDefault(f => f.Variable == variable);

            var str2 = fact1 == null ? str1 + " НЕ УДАЛОСЬ ВЫВЕСТИ" : str1 + " = " + fact1.DomainValue.Value;

            if (variable.variableType == MODEL.VariableType.Requested)
            {
                str2 += " [ЗАПРОШЕНА]";
            }

            var treeViewItem1 = new TreeNode(str2);

            var parent1 = treeViewItem1;
            if (parent != null)
            {
                parent.Nodes.Add(parent1);
            }
            else
            {
                this.tvAppliedRules.Nodes.Add(parent1);
            }

            if (!this.workingMemory.InferenceDictionary.ContainsKey(variable))
                return;

            var inference = this.workingMemory.InferenceDictionary[variable];
            var items = parent1.Nodes;
            var treeViewItem2 = new TreeNode(inference.ToString());
            treeViewItem2.Tag = inference;
            items.Add(treeViewItem2);
            foreach (var fact2 in inference.antecedents)
            {
                this.InitializeTreeViewItem(fact2.Variable, parent1);
            }
        }

        //private void expCollapseLink_Click(object sender, RoutedEventArgs e)
        //{
        //    this.expCollapseText.Content = this.isExpanded ? "Раскрыть" : "Скрыть";

        //    foreach (var item in tvRules.Items)
        //        AllExpand(item, !isExpanded);

        //    this.isExpanded = !this.isExpanded;
        //}


        private void AllExpand(object temp, bool expand)
        {
            if (temp is TreeNode item)
            {
                item.Expand();
                foreach (var subitem in item.Nodes)
                {
                    this.AllExpand(subitem, expand);
                }
            }
        }

        //private void HighLite(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    var rule = (e.NewValue as TreeViewItem)?.Tag as Rule;

        //    foreach (var obj in lvVars.Items)
        //    {
        //        var selitem = obj as ListBoxItem;
        //        var item = selitem?.Tag as Fact;
        //        if (item == null)
        //            continue;
        //        bool f = false;
        //        for (int i = 0; rule != null && i < rule.Premise.Count; i++)
        //            f |= rule.Premise[i].IsEqualTo(item);
        //        if (rule != null && (f || rule.Conclusion.Contains(item)))
        //            selitem.IsSelected = true;
        //        else
        //            selitem.IsSelected = false;
        //    }
        //}


    }
}
