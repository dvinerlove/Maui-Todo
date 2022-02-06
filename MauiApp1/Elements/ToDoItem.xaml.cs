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
    public partial class ToDoItem : ContentView
    {
        public string Text
        {
            get
            {
                return TextBox.Text;
            }
            set
            {
                TextBox.Text = value;
            }
        }
        public bool IsChecked
        {
            get
            {
                return CheckBox1.IsChecked;
            }
            set
            {
                CheckBox1.IsChecked = value;
            }
        }
        public ToDoItem()
        {
            InitializeComponent();
        }
        public event EventHandler Close;
        private void Button_Clicked(object sender, EventArgs e)
        {
            Close?.Invoke(this, EventArgs.Empty);
        }
    }
}
