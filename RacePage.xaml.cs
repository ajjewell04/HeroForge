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
            }

            for (int i = 1; i < 6; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "New Ability Score Increase:";
                textBlock.Text = "Trait " + i.ToString();
                
                StackPanel listBox = new StackPanel();
                asiPanels.Add(listBox);

                Button button = new Button();
                button.Content = "Level " + i*4 + " ASI";
                button.Click += new RoutedEventHandler(ASIButton);
                asiButton.Add(button);

                asiList.Children.Add(textBlock);
                asiList.Children.Add(listBox);
                asiList.Children.Add(button);
            }

        }

       

        void TraitButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "";
            textBoxn.AcceptsReturn = true;

            trait.Children.Add(textBoxn);
        }

        void ASIButton(object sender, RoutedEventArgs e)
        {
            TextBox textBoxn = new TextBox();
            textBoxn.Text = "";
            textBoxn.AcceptsReturn = true;

            ASI.Children.Add(textBoxn);
        }


        void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
