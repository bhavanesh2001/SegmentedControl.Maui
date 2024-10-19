using Android.Widget;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using SegmentedControl.Maui.Platforms.Android;
#nullable disable
namespace SegmentedControl.Maui.Handlers
{
    public partial class SegmentedControlHandler : ViewHandler<SegmentedControl, MauiSegmentedControl>
    {

        protected override MauiSegmentedControl CreatePlatformView() => new MauiSegmentedControl(Context, VirtualView);

        protected override void ConnectHandler(MauiSegmentedControl platformView)
        {
            base.ConnectHandler(platformView);
            platformView.CheckedChange += Selection_Changed;
        }
        protected override void DisconnectHandler(MauiSegmentedControl platformView)
        {
            base.DisconnectHandler(platformView);
            platformView.CheckedChange -= Selection_Changed;
            platformView.Dispose();
        }

        private void Selection_Changed(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            VirtualView?.SegmentSelectedCommand.Execute(null);
        }

        public static void MapBackgroundColor(SegmentedControlHandler handler, SegmentedControl view)
        {
            MapSelectedItemBackground(handler, view);
        }

        public static void MapTextColor(SegmentedControlHandler handler, SegmentedControl view)
        {
            for (int i = 0; i < handler.PlatformView.ChildCount; i++)
            {
                var button = handler.PlatformView.GetChildAt(i);
                if (button is global::Android.Widget.RadioButton radioButton)
                {
                    radioButton.SetTextColor(view.TextColor.ToPlatform());
                }
            }
        }

        public static void MapSelectedItemBackground(SegmentedControlHandler handler, SegmentedControl view)
        {
            for (int i = 0; i < handler.PlatformView.ChildCount; i++)
            {
                var button = handler.PlatformView.GetChildAt(i);
                if (button is global::Android.Widget.RadioButton radioButton)
                {
                    button.SetBackground(handler.PlatformView.CreateSegmentBackground(view.SelectedItemBackgroundColor.ToPlatform(),
                                                                                       view.BackgroundColor.ToPlatform()));
                }
            }

        }

        public static void MapBorderColor(SegmentedControlHandler handler, SegmentedControl view)
        {
            handler.PlatformView.SetCustomBackGround(view.BorderColor.ToPlatform());
        }

        public static void MapLayout(SegmentedControlHandler handler, SegmentedControl view)
        {
            handler.PlatformView.LayoutParameters = new LinearLayout.LayoutParams(view.WidthRequest.ToPixels(), view.HeightRequest.ToPixels());
        }

        public static void MapSelectedSegmentIndex(SegmentedControlHandler handler, SegmentedControl view)
        {

            var button = handler.PlatformView.GetChildAt(view.SelectedSegmentIndex);
            if (button is global::Android.Widget.RadioButton radioButton) radioButton.Checked = true;
        }

        public static void MapBorderThickness(SegmentedControlHandler handler, SegmentedControl view)
        {
            if (handler.PlatformView.Width < 1)
                return;
            for (int i = 0; i < handler.PlatformView.ChildCount; i++)
            {
                var segment = handler.PlatformView.GetChildAt(i);
                var parmas = new LinearLayout.LayoutParams(handler.PlatformView.Width / handler.PlatformView.ChildCount, LinearLayout.LayoutParams.MatchParent, 1f);
                parmas.SetMargins(view.BorderThickness.ToPixels(), view.BorderThickness.ToPixels(), view.BorderThickness.ToPixels(), view.BorderThickness.ToPixels());
                segment.LayoutParameters = parmas;
            }

        }

        private static void MapSizeAllocated(SegmentedControlHandler handler, SegmentedControl control, object arg3)
        {
            for (int i = 0; i < handler.PlatformView.ChildCount; i++)
            {
                var width = ((double)arg3).ToPixels();
                var segment = handler.PlatformView.GetChildAt(i);
                var parmas = new LinearLayout.LayoutParams(width / handler.PlatformView.ChildCount, LinearLayout.LayoutParams.MatchParent, 1f);
                parmas.SetMargins(control.BorderThickness.ToPixels(), control.BorderThickness.ToPixels(), control.BorderThickness.ToPixels(), control.BorderThickness.ToPixels());
                segment.LayoutParameters = parmas;
            }
            handler.PlatformView.Post(() =>
            {
                handler.PlatformView.RequestLayout();
                handler.PlatformView.Invalidate();
            });

        }

    }

    public static class Extensions
    {
        public static int ToPixels(this double dp)
        {
            var density = DeviceDisplay.MainDisplayInfo.Density;
            return (int)(dp * density);
        }
    }
}

