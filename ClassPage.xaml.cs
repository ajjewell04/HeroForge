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

        public ClassPage()
        {

            this.InitializeComponent();

            for(int i = 0; i < 18; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = GLOBALS.proflist[i];
                ProfList.Children.Add(checkBox);
            }

            for(int i = 1; i < 21; i++)
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
        }

        void LevelButton(object sender, RoutedEventArgs e)
        {
            StackPanel listBox = new StackPanel();
            listBox.Orientation = Orientation.Horizontal;

            TextBox textBoxn = new TextBox();
            textBoxn.Text = "Enter feature name here";
            TextBox textBox = new TextBox();
            textBox.AcceptsReturn = true;
            textBox.Text = "Enter your new feature here";

            listBox.Children.Add(textBoxn);
            listBox.Children.Add(textBox);

            for (int i =0; i < 18; i++)
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

            equip.Children.Add(textBoxn);
        }

        void OProfButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "Enter other proficiencies here";

            oProf.Children.Add(textBoxn);
        }

        void BackButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
