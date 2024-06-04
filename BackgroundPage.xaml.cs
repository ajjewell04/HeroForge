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
    public sealed partial class BackgroundPage : Page
    {

        public BackgroundPage()
        {
            this.InitializeComponent();
            for (int i = 0; i < GLOBALS.proflist.Length; ++i)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = GLOBALS.proflist[i];
                ProfList.Children.Add(checkBox);
            }

            if (GLOBALS.listindex != -1)
            {
                LoadBack();
            }
        }

        void AddClicked(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.AcceptsReturn = true;
            

            if(sender.Equals(profbutt))
            {
                textBox.PlaceholderText = "Enter new proficiency";
                oProfs.Children.Add(textBox);
            }
            else
            {
                textBox.PlaceholderText = "Add new equipment";
                equip.Children.Add(textBox);
            }
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

        void SaveBack(object sender, RoutedEventArgs e)
        {
            if (GLOBALS.listindex == -1)
            {
                GLOBALS.currb = new GLOBALS.Background();
                GLOBALS.backgrounds.Add(GLOBALS.currb);

                ListBoxItem listBox = new ListBoxItem();
                GLOBALS.backlist.Add(listBox);

                GLOBALS.listindex = GLOBALS.backgrounds.Count - 1;
            }


            if (Backname.Text == "")
            {
                Backname.Text = "Unnamed Background";
            }



            GLOBALS.currb.name = Backname.Text;
            GLOBALS.backlist[GLOBALS.listindex].Content = Backname.Text;
            GLOBALS.currb.desc = Backdesc.Text;
            GLOBALS.currb.feat = Backfeat.Text;

            int i = 0;
            foreach (CheckBox c in ProfList.Children)
            {
                if (c.IsChecked == true)
                {
                    GLOBALS.currb.prof[i] = true;
                }
                else
                {
                    GLOBALS.currb.prof[i] = false;
                }

                i++;
            }
            
            i = 0;
            foreach (TextBox t in equip.Children)
            {
                if (GLOBALS.currb.equipment.Count > i)
                    GLOBALS.currb.equipment[i] = t.Text;
                else
                    GLOBALS.currb.equipment.Add(t.Text);

                i++;
            }

            i = 0;
            foreach (TextBox t in oProfs.Children)
            {
                if (GLOBALS.currb.oprof.Count > i)
                    GLOBALS.currb.oprof[i] = t.Text;
                else
                    GLOBALS.currb.oprof.Add(t.Text);

                i++;
            }
        }

        void LoadBack()
        {
            Backname.Text = GLOBALS.currb.name;
            Backdesc.Text = GLOBALS.currb.desc;
            Backfeat.Text = GLOBALS.currb.feat;

            int i = 0;
            foreach (CheckBox c in ProfList.Children)
            {
                if (GLOBALS.currb.prof[i])
                {
                    c.IsChecked = true;
                }
                else
                {
                    c.IsChecked = false;
                }

                i++;
            }


            for (i = 0; i < GLOBALS.currb.equipment.Count; i++)
            {
                TextBox textBoxn = new TextBox();
                textBoxn.Text = GLOBALS.currb.equipment[i];
                textBoxn.AcceptsReturn = true;
                textBoxn.TextWrapping = TextWrapping.Wrap;

                equip.Children.Add(textBoxn);
            }

            for (i = 0; i < GLOBALS.currb.oprof.Count; i++)
            {
                TextBox textBoxn = new TextBox();
                textBoxn.Text = GLOBALS.currb.oprof[i];
                textBoxn.AcceptsReturn = true;
                textBoxn.TextWrapping = TextWrapping.Wrap;

                oProfs.Children.Add(textBoxn);
            }
        }
    }
}
