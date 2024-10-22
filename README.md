
# SegmentedControl.Maui

[![NuGet](https://img.shields.io/nuget/v/SegmentedControl.Maui)](https://www.nuget.org/packages/SegmentedControl.Maui/)

This plugin provides a customizable segmented control for .NET MAUI, supporting Android, iOS, and MacCatalyst platforms. It allows users to switch between different segments, useful in scenarios where multiple views or actions can be toggled.

## Features

- **Supports Android, iOS, and MacCatalyst**.
- **Customizable segments**: Background, borders, colors can be customized.
- **Smooth segment transitions**.
- **Native look and feel** for each platform.
- **No support for Windows yet** (work in progress).


## Installation

Install the plugin via [NuGet](https://www.nuget.org/packages/SegmentedControl.Maui/):

```bash
dotnet add package SegmentedControl.Maui
```

Or use the NuGet package manager to search for SegmentedControl.Maui and install it into your .NET MAUI project.

## Setup
- To use the segmented control, make sure to call **UseSegmentedControl()** in the **MauiProgram.cs** file:

```csharp
using SegmentedControl.Maui;  // Add the necessary using directive

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSegmentedControl()   // Register the segmented control here
           ....
        return builder.Build();
    }
}
```

## Usage
You can add the segmented control in your XAML or C# code.

**Example XAML**
```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:controls="clr-namespace:SegmentedControl.Maui;assembly=SegmentedControl.Maui"
             x:Class="YourAppNamespace.MainPage">

    <ContentPage.Content>
        <VerticalStackLayout Padding="20">
            <Label Text="Choose an option:" 
                   FontSize="18" 
                   HorizontalOptions="Center" 
                   VerticalOptions="Start" />

           <controls:SegmentedControl x:Name="red"  Margin="10"
                        SelectedSegmentIndex="0"
                        BorderColor="Blue" BorderThickness="2" 
                        BackgroundColor="lime" HorizontalOptions="Fill"
                        TextColor="Black" SegmentSelectedCommandParameter="{Binding .}"
                        SelectedItemBackgroundColor="Yellow"
                        SegmentSelectedCommand="{Binding MyCommand}">
     <controls:Segment Text="Item 1" />
     <controls:Segment Text="Itme 2" />
     <controls:Segment Text="Itme 3" />
</controls:SegmentedControl>

        </VerticalStackLayout>
    </ContentPage.Content>
</ContentPage>
```

Same can be done using C# if required.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
