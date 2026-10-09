using Syncfusion.Maui.GridSplitter;

namespace GridSplitter
{
    public partial class MainPage : ContentPage
    {
       private int paneCount = 1;
        public MainPage()
        {
            InitializeComponent();
        }
 
        private void OnAddPaneClicked(object sender, EventArgs e)
        {
            paneCount++;

            gridSplitter.AddPane(new Syncfusion.Maui.GridSplitter.SplitterPane
            {
                HeightRequest=350,
                Content = new Border
                {
                    Background = Colors.LightGreen,
                    Content = new Label
                    {
                        Text = $"Pane {paneCount}",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            });
        }

        private void OnRemovePaneClicked(object sender, EventArgs e)
        {
            if (gridSplitter.Children.Count > 1)
            {
                gridSplitter.RemovePane(gridSplitter.SplitterPanes.Count - 1);
                paneCount--;
            }
        }
    }
}
