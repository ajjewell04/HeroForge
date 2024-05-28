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
                ListBox listBox = new ListBox();
                listBox.Name = i.ToString();

                Button button = new Button();
                button.Content = "New Level " + i + " Feature";
                button.Name = i.ToString();
                //button.Click = i.

                levelList.Children.Add(textBlock);
                levelList.Children.Add(listBox);
                levelList.Children.Add(button);
            }
        }

        void BackButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
