using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Elements
{

    public class TodoElement
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentView
    {
        private string filename;
        public event EventHandler Close;
        public event EventHandler Delete;
        public ItemPage(object filename)
        {
            InitializeComponent();
            this.filename = (string)filename ?? string.Empty;
            Header.Text = (string)filename;
            Open();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Close?.Invoke(sender, e);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var toDoItem = new ToDoItem();
            ItemsList.Children.Add(toDoItem);
            toDoItem.Close += ToDoItem_Close;
            toDoItem.Focus();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            var path = PathHalper.GetPath(filename);
            List<TodoElement> todoList = new List<TodoElement>();
            foreach (ToDoItem item in ItemsList.Children)
            {
                if (string.IsNullOrEmpty(item.Text) == false)
                {
                    todoList.Add(new TodoElement() { Name = item.Text, IsChecked = item.IsChecked });
                }
            }
            string json = JsonSerializer.Serialize(todoList);
            File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(json);
            }
            Open();
        }
        void Open()
        {
            var path = PathHalper.GetPath(filename);
            if (File.Exists(path) == false)
                return;

            var json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json))
                return;

            List<TodoElement> elements;

            try
            {
                elements = JsonSerializer.Deserialize<List<TodoElement>>(json);

            }
            catch 
            {
                return;
            }

            ItemsList.Children.Clear();
            foreach (var item in elements)
            {
                var toDoItem = new ToDoItem() { IsChecked = item.IsChecked, Text = item.Name };
                toDoItem.Close += ToDoItem_Close;
                ItemsList.Children.Add(toDoItem);
            }

        }

        private void ToDoItem_Close(object sender, EventArgs e)
        {
            ItemsList.Children.Remove((sender as ToDoItem));
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Delete?.Invoke(filename, e);
        }
    }
}
