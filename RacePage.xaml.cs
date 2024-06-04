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
    public sealed partial class RacePage : Page
    {
        List<StackPanel> traitPanels = new List<StackPanel>();
        List<Button> traitButton = new List<Button>();

        List<StackPanel> asiPanels = new List<StackPanel>();
        List<Button> asiButton = new List<Button>();

        public RacePage()
        {

            this.InitializeComponent();
            /*
            for (int i = 1; i < 21; i++)
            {
                
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Trait " + i;
                textBlock.Text = "Trait " + i.ToString() + ":";

                StackPanel listBox = new StackPanel();
                traitPanels.Add(listBox);

                Button button = new Button();
                button.Content = "New Trait";
                button.Click += new RoutedEventHandler(TraitButton);
                traitButton.Add(button);

                traitList.Children.Add(textBlock);
                traitList.Children.Add(listBox);
                traitList.Children.Add(button);
            }*/
            /*
            for (int i = 1; i < 6; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "New Ability Score Increase:";
                textBlock.Text = i.ToString() + "butt";

                StackPanel listBox = new StackPanel();
                asiPanels.Add(listBox);

                Button button = new Button();
                button.Content = "Level " + i*4 + " ASI";
                button.Click += new RoutedEventHandler(ASIButton);
                asiButton.Add(button);

                asiList.Children.Add(textBlock);
                asiList.Children.Add(listBox);
                asiList.Children.Add(button);
            }*/

            for(int i = 0; i<6;i++)
            {

            }

            if (GLOBALS.listindex != -1)
            { 
                LoadRace(); 
            }
        }



        void TraitButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "";
            textBoxn.AcceptsReturn = true;
            textBoxn.TextWrapping = TextWrapping.Wrap;

            trait.Children.Add(textBoxn);
        }

        void ASIButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "";
            textBoxn.AcceptsReturn = true;

            //ASI.Children.Add(textBoxn);
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

        void SaveRace(object sender, RoutedEventArgs e)
        {
            if(GLOBALS.listindex == -1) 
            {
                GLOBALS.currr = new GLOBALS.Race();
                GLOBALS.races.Add(GLOBALS.currr);

                ListBoxItem listboxn = new ListBoxItem();
                GLOBALS.racelist.Add(listboxn);

                GLOBALS.listindex = GLOBALS.races.Count - 1;
            }

            if (Racename.Text == "")
            {
                Racename.Text = "Unnamed Race";
            }

            GLOBALS.racelist[GLOBALS.listindex].Content = Racename.Text;
            GLOBALS.currr.name = Racename.Text;
            GLOBALS.currr.desc = Racedesc.Text;
            GLOBALS.currr.speed = Racespeed.Text;
            GLOBALS.currr.lang = Racelang.Text;

            int i = 0;
            foreach(TextBox t in trait.Children)
            {
                if(GLOBALS.currr.feats.Count < i)
                    GLOBALS.currr.feats[i] = t.Text;
                else
                    GLOBALS.currr.feats.Add(t.Text);

                i++;
            }

            GLOBALS.currr.asi[0] = str.Text;
            GLOBALS.currr.asi[1] = dex.Text;
            GLOBALS.currr.asi[2] = con.Text;
            GLOBALS.currr.asi[3] = intel.Text;
            GLOBALS.currr.asi[4] = wis.Text;
            GLOBALS.currr.asi[5] = cha.Text;                        
        }

        void LoadRace()
        {
            Racename.Text = GLOBALS.currr.name;
            Racedesc.Text = GLOBALS.currr.desc;
            Racelang.Text = GLOBALS.currr.lang;
            Racespeed.Text = GLOBALS.currr.speed;

            str.Text = GLOBALS.currr.asi[0];
            dex.Text = GLOBALS.currr.asi[1];
            con.Text = GLOBALS.currr.asi[2];
            intel.Text = GLOBALS.currr.asi[3];
            wis.Text = GLOBALS.currr.asi[4];
            cha.Text = GLOBALS.currr.asi[5];

            for (int i = 0; i < GLOBALS.currr.feats.Count; i++)
            {
                TextBox textBoxn = new TextBox();
                textBoxn.Text = GLOBALS.currr.feats[i];
                textBoxn.AcceptsReturn = true;
                textBoxn.TextWrapping = TextWrapping.Wrap;

                trait.Children.Add(textBoxn);
            }
        }
    }
}
