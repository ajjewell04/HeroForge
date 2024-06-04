using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClassPage : Page
    {
        List<StackPanel> levelPanels = new List<StackPanel>();
        List<Button> levelbuttons = new List<Button>();
        double[] width = new double[20];

        public ClassPage()
        {

            this.InitializeComponent();

            for (int i = 0; i < 18; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = GLOBALS.proflist[i];
                ProfList.Children.Add(checkBox);
            }

            for (int i = 0; i < 6; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = GLOBALS.abi[i] + " Saving Throws";
                SaveList.Children.Add(checkBox);
            }

            for (int i = 1; i < 21; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Level " + i + " features:";
                //textBlock.Text = i.ToString() + "butt";

                StackPanel listBox = new StackPanel();
                levelPanels.Add(listBox);

                Button button = new Button();
                button.Content = "New Level " + i + " Feature";
                button.Click += new RoutedEventHandler(LevelButton);
                levelbuttons.Add(button);

                levelList.Children.Add(textBlock);
                levelList.Children.Add(listBox);
                levelList.Children.Add(button);
            }

            if (GLOBALS.listindex != -1)
            {
                LoadClasses();
            }
        }

        void LevelButton(object sender, RoutedEventArgs e)
        {
            StackPanel listBox = new StackPanel();
            listBox.Orientation = Orientation.Horizontal;

            TextBox textBoxn = new TextBox();
            textBoxn.Width = 132;
            textBoxn.Text = "Enter feature name here";
            textBoxn.AcceptsReturn = true;
            textBoxn.TextWrapping = TextWrapping.Wrap;
            TextBox textBox = new TextBox();
            textBox.Width = 300;
            textBox.AcceptsReturn = true;
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Text = "Enter your new feature here";

            listBox.Children.Add(textBoxn);
            listBox.Children.Add(textBox);

            for (int i = 0; i < 20; i++)
            {
                if (sender == levelbuttons[i])
                {
                    levelPanels[i].Children.Add(listBox);
                }
            }
        }

        void EquipButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "Enter new equipment here";
            textBoxn.AcceptsReturn = true;
            textBoxn.TextWrapping = TextWrapping.Wrap;

            equip.Children.Add(textBoxn);
        }

        void OProfButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "Enter other proficiencies here";
            textBoxn.AcceptsReturn = true;
            textBoxn.TextWrapping = TextWrapping.Wrap;

            oProf.Children.Add(textBoxn);
        }

        void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            

            GLOBALS.listindex = -1;
            if (sender.Equals(HomeButton))
            {
                MainPage page = new MainPage();
                this.Content = page;
            }
            else if (sender.Equals(ClassButton))
            {
                ClassPage page = new ClassPage();
                this.Content = page;
            }
            else if (sender.Equals(RaceButton))
            {
                RacePage page = new RacePage();
                this.Content = page;
            }
            else
            {
                BackgroundPage page = new BackgroundPage();
                this.Content = page;
            }
        }

        void SaveClass(object sender, RoutedEventArgs e)
        {
            if (GLOBALS.listindex == -1)
            {
                GLOBALS.currc = new GLOBALS.Classes();
                GLOBALS.classes.Add(GLOBALS.currc);

                ListBoxItem listBox = new ListBoxItem();
                GLOBALS.classlist.Add(listBox);

                GLOBALS.listindex = GLOBALS.classes.Count - 1;
            }


            if (Classname.Text == "")
            {
                Classname.Text = "Unnamed Class";
            }

            GLOBALS.currc.name = Classname.Text;
            GLOBALS.classlist[GLOBALS.listindex].Content = Classname.Text;

            GLOBALS.currc.desc = Classdesc.Text;
            GLOBALS.currc.profnum = Classprof.Text;

            int i = 0;
            foreach (CheckBox c in ProfList.Children)
            {
                if (c.IsChecked == true)
                {
                    GLOBALS.currc.prof[i] = true;
                }
                else
                {
                    GLOBALS.currc.prof[i] = false;
                }

                i++;
            }

            i = 0;
            foreach (CheckBox c in SaveList.Children)
            {
                if (c.IsChecked == true)
                {
                    GLOBALS.currc.saves[i] = true;
                }
                else
                {
                    GLOBALS.currc.saves[i] = false;
                }

                i++;
            }

            i = 0;
            foreach (TextBox t in equip.Children)
            {
                if (GLOBALS.currc.equipment.Count > i)
                    GLOBALS.currc.equipment[i] = t.Text;
                else
                    GLOBALS.currc.equipment.Add(t.Text);

                i++;
            }

            i = 0;
            foreach (TextBox t in oProf.Children)
            {
                if (GLOBALS.currc.oprof.Count > i)
                    GLOBALS.currc.oprof[i] = t.Text;
                else
                    GLOBALS.currc.oprof.Add(t.Text);

                i++;
            }

            for (int j = 0; j < 20; j++)
            {
                StackPanel s = levelPanels[j];

                int k = 0;
                foreach (StackPanel s1 in s.Children)
                {
                    string first = "";
                    string second = "";

                    int l = 0;
                    foreach (TextBox s2 in s1.Children)
                    {
                        if (l == 0)
                            first = s2.Text;
                        else
                            second = s2.Text;

                        l++;
                    }

                    if (GLOBALS.currc.feats[j] != null)
                    {
                        if (GLOBALS.currc.feats[j].Count <= k)
                        {
                            GLOBALS.Pair<string, string> tuple = new GLOBALS.Pair<string, string>(first, second);
                            GLOBALS.currc.feats[j].Add(tuple);
                        }
                        else
                        {
                            GLOBALS.currc.feats[j][k].First = first;
                            GLOBALS.currc.feats[j][k].Second = second;
                        }
                    }

                    k++;
                }
            }
        }

        void LoadClasses()
        {
            Classname.Text = GLOBALS.currc.name;
            Classdesc.Text = GLOBALS.currc.desc;
            Classprof.Text = GLOBALS.currc.profnum;
            Classhp.Text = GLOBALS.currc.hp;

            int i = 0;
            foreach (CheckBox c in ProfList.Children)
            {
                if (GLOBALS.currc.prof[i])
                {
                    c.IsChecked = true;
                }
                else
                {
                    c.IsChecked = false;
                }

                i++;
            }

            i = 0;
            foreach (CheckBox c in SaveList.Children)
            {
                if (GLOBALS.currc.saves[i])
                {
                    c.IsChecked = true;
                }
                else
                {
                    c.IsChecked = false;
                }

                i++;
            }

            for(i = 0; i < GLOBALS.currc.equipment.Count; i++)
            {
                TextBox textBoxn = new TextBox();
                textBoxn.Text = GLOBALS.currc.equipment[i];
                textBoxn.AcceptsReturn = true;
                textBoxn.TextWrapping = TextWrapping.Wrap;

                equip.Children.Add(textBoxn);
            }

            for (i = 0; i < GLOBALS.currc.oprof.Count; i++)
            {
                TextBox textBoxn = new TextBox();
                textBoxn.Text = GLOBALS.currc.oprof[i];
                textBoxn.AcceptsReturn = true;
                textBoxn.TextWrapping = TextWrapping.Wrap;

                oProf.Children.Add(textBoxn);
            }

            for (int j = 0; j < 20; j++)
            {
                StackPanel s = levelPanels[j];

                if(GLOBALS.currc.feats[j] != null)
                {
                    for (int k = 0; k < GLOBALS.currc.feats[j].Count; k++)
                    {
                        StackPanel listBox = new StackPanel();
                        listBox.Orientation = Orientation.Horizontal;
                        TextBox textBoxn = new TextBox();
                        textBoxn.Width = 132;
                        textBoxn.AcceptsReturn = true;
                        textBoxn.TextWrapping = TextWrapping.Wrap;
                        
                        textBoxn.Text = GLOBALS.currc.feats[j][k].First;
                        
                        TextBox textBox = new TextBox();
                        textBox.Width = 300;
                        textBox.AcceptsReturn = true;
                        textBox.AcceptsReturn = true;
                        textBox.TextWrapping = TextWrapping.Wrap;
                        textBox.Text = GLOBALS.currc.feats[j][k].Second;
                        
                        listBox.Children.Add(textBoxn);
                        listBox.Children.Add(textBox);
                        
                        s.Children.Add(listBox);
                    }
                }
            }
        }
    }
}
