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
    public partial class CreatePage : ContentView
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Save();

        }

        private void Save()
        {
            string text = Input.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            Input.Text = "";
            var filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyTODOFolder");
            Directory.CreateDirectory(filename);

            filename = PathHalper.GetPath(text);
            if (File.Exists(filename))
            {
                return;
            }
            else
            {
                File.Create(filename).Close();
            }
        }


    }
}
