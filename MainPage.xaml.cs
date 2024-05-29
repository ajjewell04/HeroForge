using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public static class GLOBALS
    {
        public class Background
        {
            string name;
            int[] prof;
            string equipment;
            string featName;
            string feat;
        }

        public class Race
        {
            string name;
            int[] asi;
            string[] feats;
        }

        public class Classes
        {
            public string name;
            int[] prof;
            List<List<string>> feats;
        }

        public static int listnum = 0;
        public static List<Classes> classes = new List<Classes>();
        public static List<ListBoxItem> classlist = new List<ListBoxItem>();
        public static List<Race> races = new List<Race>();
        public static List<ListBoxItem> racelist = new List<ListBoxItem>();
        public static List<Background> backgrounds = new List<Background>();
        public static List<ListBoxItem> backlist = new List<ListBoxItem>();

        public static string[] proflist = new string[18] {"Acrobatics", "Animal Handling","Arcana", "Athletics", "Deception",
                                                            "History","Insight","Intimidation","Investigation","Medicine","Nature",
                                                            "Perception","Performance","Persuasion","Religon","Sleight of Hand",
                                                            "Stealth","Survival"};

        public static bool first = true;
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if(GLOBALS.first)
            {
                ListBoxItem wizard = new ListBoxItem();
                wizard.Content = "Wizard";
                GLOBALS.classlist.Add(wizard);

                ListBoxItem human = new ListBoxItem();
                human.Content = "Human";
                GLOBALS.racelist.Add(human);

                ListBoxItem folkhero = new ListBoxItem();
                folkhero.Content = "Folk Hero";
                GLOBALS.backlist.Add(folkhero);

                GLOBALS.first = false;
            }
        }

        void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            current.Items.Clear();

            if (sender.Equals(ClassButton))
            {
                for(int i = 0; i < GLOBALS.classlist.Count; i++)
                {
                     current.Items.Add(GLOBALS.classlist[i].Content);
                }
                GLOBALS.listnum = 0;
            }
            else if (sender.Equals(RaceButton))
            {
                for (int i = 0; i < GLOBALS.racelist.Count; i++)
                {
                    current.Items.Add(GLOBALS.racelist[i].Content);
                }
                GLOBALS.listnum = 1;
            }
            else
            {
                for (int i = 0; i < GLOBALS.backlist.Count; i++)
                {
                    current.Items.Add(GLOBALS.backlist[i].Content);
                }
                GLOBALS.listnum = 2;
            }
        }

        void CreateNewButton(object sender, RoutedEventArgs e)
        {
            switch(GLOBALS.listnum)
            {
                case 0:
                    Frame.Navigate(typeof(ClassPage));
                    break;
                case 1:
                    Frame.Navigate(typeof(RacePage));
                    break;
                default:
                    Frame.Navigate(typeof(BackgroundPage));
                    break;
            }
            
        }

        void LoadItem(object sender, RoutedEventArgs e)
        {

        }
    }
}
