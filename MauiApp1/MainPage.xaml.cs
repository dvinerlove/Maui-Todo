using MauiApp1.Elements;
namespace MauiApp1
{
    public enum Tabs
    {

        create,
        list
    }


    public partial class MainPage : ContentPage
    {
        Tabs CurrentTab ;
        public MainPage()
        {
            InitializeComponent();

            CreatePage = new CreatePage();
            ListPage = new ListPage();

            OpenTab(Tabs.create);
            OpenTab(Tabs.list);
            OpenTab(Tabs.create);

            
        }

        private void OpenTab(Tabs tab = Tabs.create)
        {

            switch (tab)
            {
                case Tabs.create:
                    if (tab == CurrentTab)
                    {
                        return;
                    }

                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(CreatePage);
                    break;
                case Tabs.list:

                    if (tab == CurrentTab)
                    {
                        ListPage.isPageOpen();
                        return;
                    }

                    MainGrid.Children.Clear();
                    MainGrid.Children.Add(ListPage);
                    ListPage.Update();
                    break;
                default:
                    break;
            }
            CurrentTab = tab;

        }

        public CreatePage CreatePage { get; }

        public ListPage ListPage { get; }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            OpenTab(Tabs.create);
        }

        private void ListButton_Clicked(object sender, EventArgs e)
        {
            OpenTab(Tabs.list);
        }

        protected override bool OnBackButtonPressed()
        {
            switch (CurrentTab)
            {
                case Tabs.create:
                    Environment.Exit(0);
                    return false;
                case Tabs.list:
                    bool isPageOpen = ListPage.isPageOpen();
                    if (isPageOpen == false)
                    {
                        OpenTab(Tabs.create);
                    }
                    break;
                default:
                    break;
            }

            return true;
        }

    }
}