using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls.Platform;
using RadioButton = Android.Widget.RadioButton;
using Color = Android.Graphics.Color;

namespace SegmentedControl.Maui.Platforms.Android
{
    public class MauiSegmentedControl : RadioGroup
    {

        private SegmentedControl _virtualView;
        public MauiSegmentedControl(Context context, SegmentedControl virtualView) : base(context)
        {
            _virtualView = virtualView;
            Initialize();
        }

        private void Initialize()
        {
            Orientation = Orientation.Horizontal;
            for (int i = 0; i < _virtualView.Children.Count; i++)
            {
                var radioButton = new RadioButton(global::Android.App.Application.Context);
                radioButton.Text = _virtualView.Children[i].Text;
                radioButton.Gravity = GravityFlags.Center;
                radioButton.SetButtonDrawable(null);
                AddView(radioButton);
            }
        }


        public void SetCustomBackGround(Color backGroundColor)
        {
            GradientDrawable border = new GradientDrawable();
            border.SetShape(ShapeType.Rectangle);
            border.SetColor(backGroundColor);
            this.SetBackground(border);
        }
        public Drawable? CreateSegmentBackground(Color selectedColor, Color unselectedColor)
        {
            var states = new StateListDrawable();

            // Selected state
            var selectedShape = new GradientDrawable();
            selectedShape.SetColor(selectedColor);
            states.AddState(new int[] { global::Android.Resource.Attribute.StateChecked }, selectedShape);

            // Unselected state
            var unselectedShape = new GradientDrawable();
            unselectedShape.SetColor(unselectedColor);
            states.AddState(new int[] { -global::Android.Resource.Attribute.StateChecked }, unselectedShape);

            return states;
        }

    }
}

