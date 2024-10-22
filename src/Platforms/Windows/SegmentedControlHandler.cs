using System;
using Microsoft.Maui.Handlers;
using SegmentedControl.Maui.Platforms.Windows;

namespace SegmentedControl.Maui.Handlers
{
    public partial class SegmentedControlHandler : ViewHandler<SegmentedControl, MauiSegmentedControl>
    {
        protected override MauiSegmentedControl CreatePlatformView() => new MauiSegmentedControl();

        protected override void ConnectHandler(MauiSegmentedControl platformView)
        {
            base.ConnectHandler(platformView);
        }


        protected override void DisconnectHandler(MauiSegmentedControl platformView)
        {
            base.DisconnectHandler(platformView);
        }

        public static void MapBackgroundColor(SegmentedControlHandler handler, SegmentedControl view)
        {

        }

        public static void MapTextColor(SegmentedControlHandler handler, SegmentedControl view)
        {

        }

        public static void MapSelectedItemBackground(SegmentedControlHandler handler, SegmentedControl view)
        {

        }

        public static void MapBorderColor(SegmentedControlHandler handler, SegmentedControl view)
        {

        }

        public static void MapLayout(SegmentedControlHandler handler, SegmentedControl view)
        {

        }

        public static void MapSelectedSegmentIndex(SegmentedControlHandler handler, SegmentedControl view)
        {

        }

        public static void MapBorderThickness(SegmentedControlHandler handler, SegmentedControl view)
        {

        }
    }

}

