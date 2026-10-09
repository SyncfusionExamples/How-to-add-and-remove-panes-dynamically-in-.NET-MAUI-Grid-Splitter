# How to Add and Remove Panes Dynamically in .NET MAUI Grid Splitter

## Overview

The Grid Splitter control in .NET MAUI helps users resize adjacent panes at runtime, creating more flexible and interactive layouts. While many applications use a fixed number of panes, some scenarios require the ability to add or remove panes dynamically based on user actions. Dynamic pane management enables developers to create highly customizable interfaces where content regions can be introduced or removed without rebuilding the entire page layout.

Applications such as dashboards, editors, reporting tools, data analysis applications, and workspace-oriented systems often need to display additional information on demand. For example, a user may open a new details panel, preview section, properties window, or log viewer while working with the application. Similarly, unnecessary panels can be removed to maximize screen space and reduce clutter. By combining dynamic pane management with the Grid Splitter control, developers can provide users with full control over both the layout structure and pane sizing.

The Syncfusion Grid Splitter control simplifies this process by providing APIs to add and remove panes at runtime. Instead of manually modifying grid row or column definitions, developers can use the `AddPane` and `RemovePane` methods to manage panes dynamically. When a new pane is added, the Grid Splitter automatically updates its layout to include the new content region. Likewise, when a pane is removed, the layout adjusts automatically while preserving the resizing functionality of the remaining panes.

This approach is particularly useful in applications that support customizable workspaces. Users can expand the interface when additional information is needed and simplify the layout when focusing on specific tasks. Since panes are created and removed dynamically, the user interface becomes more responsive to changing workflows and user preferences.

In this example, a Grid Splitter initially contains a single pane. Users can click the **Add Pane** button to create additional panes at runtime. Each new pane is added with its own content and becomes part of the resizable layout. The **Remove Pane** button removes the most recently added pane, allowing the layout to return to its previous configuration. This demonstrates how dynamic pane management can be implemented while maintaining a smooth and intuitive resizing experience.

By using dynamic pane operations, developers can build modern applications that adapt to user requirements while providing efficient screen space management. The Grid Splitter control ensures that pane resizing remains seamless regardless of how many panes are added or removed during runtime.

## Sample

### XAML

```xml
<VerticalStackLayout Spacing="10">
    <gridSplitter:SfGridSplitter x:Name="gridSplitter">
        <gridSplitter:SplitterPane HeightRequest="350">
            <Border Background="LightGreen">
                <Label Text="Pane 1"
                       HorizontalOptions="Center"
                       VerticalOptions="Center" />
            </Border>
        </gridSplitter:SplitterPane>
    </gridSplitter:SfGridSplitter>

    <HorizontalStackLayout Spacing="10">
        <Button Text="Add Pane"
                Clicked="OnAddPaneClicked" />

        <Button Text="Remove Pane"
                Clicked="OnRemovePaneClicked" />
    </HorizontalStackLayout>
</VerticalStackLayout>
```

### C#

```csharp
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

            gridSplitter.AddPane(new SplitterPane
            {
                HeightRequest = 350,
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
```

## Output

- The Grid Splitter initially displays a single pane.
- Clicking **Add Pane** dynamically creates a new pane within the Grid Splitter.
- Each newly added pane becomes part of the resizable layout.
- Users can continue adding multiple panes during runtime.
- Clicking **Remove Pane** removes the most recently added pane.
- The remaining panes automatically adjust to occupy the available space.
- Grid Splitter resizing functionality remains available after panes are added or removed.
- The layout updates dynamically without requiring page reloads.

## Key Benefits

- Supports dynamic workspace customization.
- Allows panes to be added at runtime.
- Enables removal of unnecessary panes to maximize screen space.
- Simplifies layout management through built-in APIs.
- Maintains resizing functionality after layout updates.
- Improves user experience with adaptive interfaces.
- Ideal for dashboards, editors, and multi-pane applications.

## Conclusion

The Syncfusion Grid Splitter control provides built-in methods for dynamically adding and removing panes at runtime. Using the `AddPane` and `RemovePane` APIs, developers can create flexible layouts that adapt to changing user requirements while preserving smooth resizing behavior. This capability helps build modern, customizable applications that efficiently utilize available screen space.