using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

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
            public string name = "";
            public string desc = "";

            public bool[] prof = new bool[18];
            public List<string> equipment = new List<string>();
            public List<string> oprof = new List<string>();
            public string feat = "";
        }

        public class Race
        {
            public Race()
            {
                for (int i = 0; i < 6; i++)
                    asi[i] = "";
            }

            public string name = "";
            public string desc = "";
            public string speed = "";
            public string lang = "";
            public string[] asi = new string[6];
            public List<string> feats = new List<string>();
        }

        public class Classes
        {
            public Classes() 
            {
                for (int i = 0; i < 20; i++)
                    feats[i] = new List<Pair<string, string>>();
            }

            public string name = "";
            public string desc = "";

            public string hp = "";

            public bool[] saves = new bool[6];

            public string profnum = "";
            public bool[] prof = new bool[18];

            public List<string> equipment = new List<string>();
            public List<string> oprof = new List<string>();

            public List<Pair<string,string>>[] feats = new List<Pair<string, string>>[20];
        }

        public class Pair<T, U>
        {
            public Pair()
            {
            }

            public Pair(T first, U second)
            {
                this.First = first;
                this.Second = second;
            }

            public T First { get; set; }
            public U Second { get; set; }
        };

        public static int listindex = -1;

        public static Classes currc;
        public static List<Classes> classes = new List<Classes>();
        public static List<ListBoxItem> classlist = new List<ListBoxItem>();

        public static Race currr;
        public static List<Race> races = new List<Race>();
        public static List<ListBoxItem> racelist = new List<ListBoxItem>();

        public static Background currb;
        public static List<Background> backgrounds = new List<Background>();
        public static List<ListBoxItem> backlist = new List<ListBoxItem>();

        public static string[] proflist = new string[18] {"Acrobatics", "Animal Handling","Arcana", "Athletics", "Deception",
                                                            "History","Insight","Intimidation","Investigation","Medicine","Nature",
                                                            "Perception","Performance","Persuasion","Religon","Sleight of Hand",
                                                            "Stealth","Survival"};
        public static string[] abi = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

        public static bool first = true;
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (GLOBALS.first)
            {

                InitWizard();
                InitHuman();
                InitFolkHero();

                GLOBALS.first = false;
            }

            for (int i = 0; i < GLOBALS.classlist.Count; i++)
            {
                classbox.Items.Add(GLOBALS.classlist[i].Content);
            }
            for (int i = 0; i < GLOBALS.racelist.Count; i++)
            {
                racebox.Items.Add(GLOBALS.racelist[i].Content);
            }
            for (int i = 0; i < GLOBALS.backlist.Count; i++)
            {
                backgroundbox.Items.Add(GLOBALS.backlist[i].Content);
            }
        }

        void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            classbox.Items.Clear();
            racebox.Items.Clear();
            backgroundbox.Items.Clear();

            GLOBALS.listindex = -1;

            if (sender.Equals(HomeButton))
            {
                for (int i = 0; i < GLOBALS.classlist.Count; i++)
                {
                    classbox.Items.Add(GLOBALS.classlist[i].Content);
                }
                for (int i = 0; i < GLOBALS.racelist.Count; i++)
                {
                    racebox.Items.Add(GLOBALS.racelist[i].Content);
                }
                for (int i = 0; i < GLOBALS.backlist.Count; i++)
                {
                    backgroundbox.Items.Add(GLOBALS.backlist[i].Content);
                }
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

        void LoadItem(object sender, RoutedEventArgs e)
        {
            if(sender.Equals(classbox))
            {
                GLOBALS.listindex = classbox.SelectedIndex;
                GLOBALS.currc = GLOBALS.classes[GLOBALS.listindex];
                ClassPage page = new ClassPage();
                this.Content = page;
            }
            else if(sender.Equals(racebox))
            {
                GLOBALS.listindex = racebox.SelectedIndex;
                GLOBALS.currr = GLOBALS.races[GLOBALS.listindex];
                RacePage page = new RacePage();
                this.Content = page;
            }
            else
            {
                GLOBALS.listindex = backgroundbox.SelectedIndex;
                GLOBALS.currb = GLOBALS.backgrounds[GLOBALS.listindex];
                BackgroundPage page = new BackgroundPage();
                this.Content = page;
            }
        }

        void InitWizard()
        {
            ListBoxItem wizard = new ListBoxItem();
            wizard.FontFamily = new FontFamily("Old English Text MT");
            wizard.Content = "Wizard (Prebuilt)";
            GLOBALS.classlist.Add(wizard);

            GLOBALS.Classes wiz = new GLOBALS.Classes();
            GLOBALS.classes.Add(wiz);

            wiz.name = "Wizard (Prebuilt)";
            wiz.desc = "Wizards are supreme magic-users, defined and united as a class by the spells they cast. Drawing on the subtle weave of magic that permeates the cosmos, wizards cast spells of explosive fire, arcing lightning, subtle deception, brute-force mind control, and much more.";
            wiz.hp = "1d6 + Con per level";

            wiz.saves[3] = true;
            wiz.saves[4] = true;

            wiz.oprof.Add("Daggers");
            wiz.oprof.Add("Darts");
            wiz.oprof.Add("Slings");
            wiz.oprof.Add("Quarterstaffs");
            wiz.oprof.Add("Light Crossbows");

            wiz.equipment.Add("(a) a quarterstaff or (b) a dagger");
            wiz.equipment.Add("(a) a component pouch or (b) an arcane focus");
            wiz.equipment.Add("(a) a scholar's pack or (b) an explorer's pack");
            wiz.equipment.Add("A spellbook");

            wiz.profnum = "2";
            wiz.prof[2] = true;
            wiz.prof[5] = true;
            wiz.prof[6] = true;
            wiz.prof[8] = true;
            wiz.prof[9] = true; 
            wiz.prof[14] = true;

            wiz.feats[0].Add(new GLOBALS.Pair<string, string>("Spellcasting", "As a student of arcane magic, you have a spellbook containing spells that show the first glimmerings of your true power."));
            wiz.feats[0].Add(new GLOBALS.Pair<string, string>("Ritual Casting", "You can cast a wizard spell as a ritual if that spell has the ritual tag and you have the spell in your spellbook. You don't need to have the spell prepared."));
            wiz.feats[0].Add(new GLOBALS.Pair<string, string>("Arcane Recovery", "You have learned to regain some of your magical energy by studying your spellbook. Once per day when you finish a short rest, you can choose expended spell slots to recover. The spell slots can have a combined level that is equal to or less than half your wizard level (rounded up), and none of the slots can be 6th level or higher.\r\n\r\nFor example, if you're a 4th-level wizard, you can recover up to two levels worth of spell slots. You can recover either a 2nd-level spell slot or two 1st-level spell slots."));
            wiz.feats[1].Add(new GLOBALS.Pair<string, string>("Arcane Tradition", "When you reach 2nd level, you choose an arcane tradition, shaping your practice of magic through one of the following schools. Your choice grants you features at 2nd level and again at 6th, 10th, and 14th level."));
            wiz.feats[2].Add(new GLOBALS.Pair<string, string>("Cantrip Formulas (Optional)", "At 3rd level, you have scribed a set of arcane formulas in your spellbook that you can use to formulate a cantrip in your mind. Whenever you finish a long rest and consult those formulas in your spellbook, you can replace one wizard cantrip you know with another cantrip from the wizard spell list."));
            wiz.feats[3].Add(new GLOBALS.Pair<string, string>("Ability Score Improvement", "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature."));
            wiz.feats[17].Add(new GLOBALS.Pair<string, string>("Spell Mastery", "At 18th level, you have achieved such mastery over certain spells that you can cast them at will. Choose a 1st-level wizard spell and a 2nd-level wizard spell that are in your spellbook. You can cast those spells at their lowest level without expending a spell slot when you have them prepared. If you want to cast either spell at a higher level, you must expend a spell slot as normal.\r\n\r\nBy spending 8 hours in study, you can exchange one or both of the spells you chose for different spells of the same levels."));
            wiz.feats[19].Add(new GLOBALS.Pair<string, string>("Signature Spells", "When you reach 20th level, you gain mastery over two powerful spells and can cast them with little effort. Choose two 3rd-level wizard spells in your spellbook as your signature spells. You always have these spells prepared, they don't count against the number of spells you have prepared, and you can cast each of them once at 3rd level without expending a spell slot. When you do so, you can't do so again until you finish a short or long rest.\r\n\r\nIf you want to cast either spell at a higher level, you must expend a spell slot as normal."));
        }

        void InitHuman()
        {
            ListBoxItem human = new ListBoxItem();
            human.Content = "Human (Prebuilt)";
            GLOBALS.racelist.Add(human);

            GLOBALS.Race hum = new GLOBALS.Race();
            GLOBALS.races.Add(hum);
            hum.name = "Human (Prebuilt)";
            hum.desc = "In the reckonings of most worlds, humans are the youngest of the common races, late to arrive on the world scene and short-lived in comparison to dwarves, elves, and dragons. Perhaps it is because of their shorter lives that they strive to achieve as much as they can in the years they are given.Or maybe they feel they have something to prove to the elder races, and that's why they build their mighty empires on the foundation of conquest and trade. Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds.";
            hum.speed = "30";
            hum.lang = "Common and one extra language of your choice.";

            for(int i = 0; i<6; i++) 
            {
                hum.asi[i] = "+1";
            }
        }

        void InitFolkHero()
        {
            ListBoxItem folkhero = new ListBoxItem();
            folkhero.Content = "Folk Hero (Prebuilt)";
            GLOBALS.backlist.Add(folkhero);

            GLOBALS.Background folk = new GLOBALS.Background();
            GLOBALS.backgrounds.Add(folk);
            folk.name = "Folk Hero (Prebuilt)";
            folk.desc = "You come from a humble social rank, but you are destined for so much more. Already the people of your home village regard you as their champion, and your destiny calls you to stand against the tyrants and monsters that threaten the common folk everywhere.";
            folk.prof[1] = true;
            folk.prof[16] = true;
            folk.oprof.Add("One type of artisan's tools");
            folk.oprof.Add("vehicles (land)");
            folk.equipment.Add("A set of artisan's tools (one of your choice)");
            folk.equipment.Add("A shovel");
            folk.equipment.Add("An iron pot");
            folk.equipment.Add("A set of common clothes");
            folk.equipment.Add("A pouch containing 10gp");
            folk.feat = "Rustic Hospitality\r\n\r\nSince you come from the ranks of the common folk, you fit in among them with ease. You can find a place to hide, rest, or recuperate among other commoners, unless you have shown yourself to be a danger to them. They will shield you from the law or anyone else searching for you, though they will not risk their lives for you.";

        }
    }
}
