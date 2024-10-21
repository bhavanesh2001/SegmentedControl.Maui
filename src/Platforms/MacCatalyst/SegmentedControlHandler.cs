using System;
using CoreGraphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using SegmentedControl.Maui.Platforms.MacCatalyst;
using UIKit;

namespace SegmentedControl.Maui.Handlers
{
    public partial class SegmentedControlHandler : ViewHandler<SegmentedControl, MauiSegmentedControl>
    {
        protected override MauiSegmentedControl CreatePlatformView() => new MauiSegmentedControl(VirtualView);

        protected override void ConnectHandler(MauiSegmentedControl platformView)
        {
            base.ConnectHandler(platformView);
            platformView.ValueChanged += PlatformView_ValueChanged;
        }

        private void PlatformView_ValueChanged(object? sender, EventArgs e)
        {
                VirtualView.SegmentSelectedCommand?.Execute(VirtualView.SegmentSelectedCommandParameter);
        }

        protected override void DisconnectHandler(MauiSegmentedControl platformView)
        {
            base.DisconnectHandler(platformView);
            platformView.ValueChanged -= PlatformView_ValueChanged;
            platformView.Dispose();
        }


        public static void MapBackgroundColor(SegmentedControlHandler handler, SegmentedControl view)
        {
            handler.PlatformView.BackgroundColor = view.BackgroundColor.ToPlatform();
        }

        public static void MapTextColor(SegmentedControlHandler handler, SegmentedControl view)
        {
            var uita = new UIStringAttributes();
            uita.ForegroundColor = view.TextColor.ToPlatform();
            handler.PlatformView.SetTitleTextAttributes(uita, UIControlState.Normal);
        }

        public static void MapSelectedItemBackground(SegmentedControlHandler handler, SegmentedControl view)
        {
            handler.PlatformView.SelectedSegmentTintColor = view.SelectedItemBackgroundColor.ToPlatform();
        }

        public static void MapBorderColor(SegmentedControlHandler handler, SegmentedControl view)
        {
            handler.PlatformView.Layer.BorderColor = view.BorderColor.ToPlatform().CGColor;
        }

        public static void MapLayout(SegmentedControlHandler handler, SegmentedControl view)
        {
            var frame = new CGRect(0, 0, width: view.WidthRequest, height: view.HeightRequest);
            handler.PlatformView.Frame = frame;
        }

        public static void MapSelectedSegmentIndex(SegmentedControlHandler handler, SegmentedControl view)
        {
            if (view.SelectedSegmentIndex != -1)
            {
                handler.PlatformView.SelectedSegment = view.SelectedSegmentIndex;
            }
        }

        public static void MapBorderThickness(SegmentedControlHandler handler, SegmentedControl view)
        {
            handler.PlatformView.Layer.BorderWidth = (nfloat)view.BorderThickness;
        }
    }
}

