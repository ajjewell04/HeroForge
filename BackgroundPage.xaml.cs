﻿using System;
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
        }
        void AddClicked(object sender, RoutedEventArgs e)
        {
            if (AddedProf.Text != "")
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = AddedProf.Text;
                //bool dup = false;
                //for (int i = 0; i < ProfList.Children.Count; ++i)
                //{
                //    if (AddedProf.Text == ProfList.Children.ElementAt()
                //        dup = true;
                //}
                //if (!dup)
                ProfList.Children.Add(checkBox);
                AddedProf.Text = "";
                AddedProf.PlaceholderText = "Other";
            }
        }
        void BackButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
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
