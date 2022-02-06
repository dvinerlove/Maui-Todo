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
    public partial class ListPage : ContentView
    {
        private ItemPage page;

        public ListPage()
        {
            InitializeComponent();
        }

        internal void Update()
        {
            var filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyTODOFolder");
            var dir = Directory.CreateDirectory(filename);

            FileInfo[] Files = dir.GetFiles("*.json"); 
            Stack.Children.Clear();

            foreach (FileInfo file in Files)
            {
                var item = new HeaderItem(file.Name.Replace(".json", ""));
                item.OpenPage += Item_OpenPage;
                Stack.Children.Add(item);
            }
        }

        private void Item_OpenPage(object sender, EventArgs e)
        {
            PageHolder.Children.Clear();
            page = new ItemPage(sender);
            page.Delete += Page_Delete;
            page.Close += Page_Close;
            PageHolder.Children.Add(page);
            Stack.IsVisible = false;
        }

     

        private void Page_Delete(object sender, EventArgs e)
        {
            Close();
            PathHalper.Delete((string)sender);
            Update();
        }

        private void Page_Close(object sender, EventArgs e)
        {
            Close();

        }

        private void Close()
        {
            Stack.IsVisible = true;
            PageHolder.Children.Clear();
            page = null;
        }

        internal bool isPageOpen()
        {
            var isPageOpen = page!=null;
            if (isPageOpen)
            {
                Close();
            }

            return isPageOpen;
        }
    }
}
