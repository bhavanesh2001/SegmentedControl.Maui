#if IOS 
using PlatformView = SegmentedControl.Maui.Platforms.iOS.MauiSegmentedControl;
#elif ANDROID
using PlatformView = SegmentedControl.Maui.Platforms.Android.MauiSegmentedControl;
#elif WINDOWS
using PlatformView = SegmentedControl.Maui.Platforms.Windows.MauiSegmentedControl;
#elif MACCATALYST
using PlatformView = SegmentedControl.Maui.Platforms.MacCatalyst.MauiSegmentedControl;
#endif
using Microsoft.Maui.Handlers;

namespace SegmentedControl.Maui.Handlers
{
    public partial class SegmentedControlHandler
    {
        public static IPropertyMapper<SegmentedControl, SegmentedControlHandler> PropertyMapper = new PropertyMapper<SegmentedControl, SegmentedControlHandler>(ViewHandler.ViewMapper)
        {
            [nameof(SegmentedControl.BackgroundColor)] = MapBackgroundColor,
            [nameof(SegmentedControl.TextColor)] = MapTextColor,
            [nameof(SegmentedControl.SelectedItemBackgroundColor)] = MapSelectedItemBackground,
            [nameof(SegmentedControl.BorderColor)] = MapBorderColor,
            [nameof(SegmentedControl.HeightRequest)] = MapLayout,
            [nameof(SegmentedControl.WidthRequest)] = MapLayout,
            [nameof(SegmentedControl.SelectedSegmentIndex)] = MapSelectedSegmentIndex,
            [nameof(SegmentedControl.BorderThickness)] = MapBorderThickness,
        };
        public static CommandMapper<SegmentedControl, SegmentedControlHandler> CommandMapper = new(ViewCommandMapper)
        {
#if ANDROID
            ["SizeAllocated"] = MapSizeAllocated
#endif
        };

        public SegmentedControlHandler() : base(PropertyMapper, CommandMapper)
        {
        }

    }
}

