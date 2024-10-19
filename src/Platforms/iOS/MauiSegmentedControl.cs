using System;
using CoreGraphics;
using UIKit;

namespace SegmentedControl.Maui.Platforms.iOS
{
    public class MauiSegmentedControl : UISegmentedControl
    {
        private SegmentedControl virtualView;

        public MauiSegmentedControl(SegmentedControl virtualView)
        {
            this.virtualView = virtualView;
            Initialize();
        }


        private void Initialize()
        {
            for (int i = 0; i < virtualView.Children.Count; i++)
            {
                InsertSegment(virtualView.Children[i].Text, i, true);
            }
        }
    }
}

