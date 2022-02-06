using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderItem : ContentView
    {
        public event EventHandler OpenPage;
        public string Text { get; private set; }
        public HeaderItem(string text)
        {
            InitializeComponent();
            Text = (string)text;
            CardButton.Text = (string)text;
        }

        private void CardButton_Clicked(object sender, EventArgs e)
        {
            OpenPage?.Invoke(Text, EventArgs.Empty);
        }
    }
}
