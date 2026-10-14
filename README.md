# How to Add and Remove Panes Dynamically in .NET MAUI Grid Splitter

This repository contains a sample explaining how to add and remove panes dynamically in the .NET MAUI Grid Splitter using the Syncfusion `SfGridSplitter` control.

Dynamic pane management is a useful feature in applications where the user interface needs to adapt at runtime. Instead of defining all panes during initialization, developers can add new panes when additional content is required and remove panes when they are no longer needed. This approach provides flexibility and enables applications to respond to changing user requirements.

The `SfGridSplitter` control provides built-in methods for dynamically managing panes through the `AddPane` and `RemovePane` APIs. These methods allow developers to modify the layout while the application is running without recreating the entire control.

In this example, the application initially displays a single pane. Users can click the **Add Pane** button to create additional panes dynamically. Each newly added pane is automatically incorporated into the Grid Splitter layout and can be resized using the splitter. The **Remove Pane** button removes the most recently added pane, allowing the layout to be simplified when necessary.

## Sample

### XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:gridSplitter="clr-namespace:Syncfusion.Maui.GridSplitter;assembly=Syncfusion.Maui.GridSplitter"
             x:Class="GridSplitter.MainPage">

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

</ContentPage>
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

## Explanation

This example demonstrates runtime pane management using the Grid Splitter control.

### Adding Panes

The `AddPane` method is used to create a new pane dynamically when the user clicks the **Add Pane** button.

```csharp
gridSplitter.AddPane(new SplitterPane
{
    Content = new Border
    {
        Background = Colors.LightGreen
    }
});
```

Each newly added pane:

- Is automatically inserted into the Grid Splitter.
- Receives a unique pane number.
- Can be resized using the splitter.
- Participates in the existing layout without requiring a page refresh.

### Removing Panes

The `RemovePane` method is used to remove the most recently added pane.

```csharp
gridSplitter.RemovePane(gridSplitter.SplitterPanes.Count - 1);
```

Before removing a pane, the sample checks whether more than one pane is available to ensure that at least one pane remains in the layout.

### Pane Counter

A simple counter tracks the number of panes currently displayed.

```csharp
private int paneCount = 1;
```

The counter is incremented when a pane is added and decremented when a pane is removed, ensuring that each dynamically created pane displays the correct label.

## How It Works

The Grid Splitter initially displays a single pane labeled **Pane 1**.

When the user clicks **Add Pane**:

1. A new `SplitterPane` is created.
2. The pane is added to the Grid Splitter using the `AddPane` method.
3. A splitter is automatically generated between adjacent panes.
4. Users can resize the newly added pane immediately.

When the user clicks **Remove Pane**:

1. The last pane in the collection is identified.
2. The pane is removed using the `RemovePane` method.
3. The layout is automatically updated.
4. Remaining panes continue to function normally.

## Output

When the application runs, the following behavior can be observed:

- The Grid Splitter initially displays one pane.
- Clicking **Add Pane** dynamically creates additional panes.
- Newly added panes appear immediately in the layout.
- Splitters are automatically generated between panes.
- Users can resize all panes interactively.
- Clicking **Remove Pane** removes the most recently added pane.
- The layout automatically adjusts after panes are added or removed.
- The application remains responsive throughout the process.

## Benefits

Dynamic pane management provides several advantages:

- Allows layouts to adapt at runtime.
- Improves flexibility for end users.
- Reduces the need for predefined static layouts.
- Supports dynamic dashboard and workspace scenarios.
- Simplifies the creation of customizable user interfaces.
- Enables efficient use of available screen space.

## Common Use Cases

Adding and removing panes dynamically is useful in applications such as:

- Dashboard applications.
- Data visualization tools.
- Project management systems.
- File explorer interfaces.
- Reporting and analytics platforms.
- Multi-document workspaces.
- Administrative portals.
- Enterprise productivity applications.

## Conclusion

The Syncfusion `SfGridSplitter` control provides simple APIs for dynamically adding and removing panes at runtime. By using the `AddPane` and `RemovePane` methods, developers can create highly flexible layouts that adapt to user interactions while maintaining the built-in pane resizing functionality of the Grid Splitter.