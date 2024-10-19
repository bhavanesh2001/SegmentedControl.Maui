using System.Windows.Input;

namespace SegmentedControl.Maui
{

    [ContentProperty(nameof(Children))]
    public class SegmentedControl : View
    {
        public SegmentedControl()
        {
            Children = new List<Segment>();
        }

        public static readonly BindableProperty ChildrenProperty = BindableProperty.Create(nameof(Children), typeof(IList<Segment>), typeof(SegmentedControl), default(IList<Segment>));


        public IList<Segment> Children
        {
            get => (IList<Segment>)GetValue(ChildrenProperty);
            set => SetValue(ChildrenProperty, value);
        }

        public static readonly BindableProperty SelectedSegmentIndexProperty = BindableProperty.Create(nameof(SelectedSegmentIndex), typeof(int), typeof(SegmentedControl), -1);
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(SegmentedControl), defaultBindingMode: BindingMode.TwoWay);

        public int SelectedSegmentIndex
        {
            get => (int)GetValue(SelectedSegmentIndexProperty);
            set => SetValue(SelectedSegmentIndexProperty, value);
        }

        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(SegmentedControl),
            defaultValue: default(Color));

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(SegmentedControl), defaultValueCreator: bindable => ((SegmentedControl)bindable).BackgroundColor);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
            (nameof(BorderThickness)),
            typeof(double),
            typeof(SegmentedControl),
            1.0
        );

        public double BorderThickness
        {
            get => (double)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public static readonly BindableProperty SelectedItemBackgroundColorProperty = BindableProperty.Create(
            nameof(SelectedItemBackgroundColor),
            typeof(Color),
            typeof(SegmentedControl),
            default(Color));

        public Color SelectedItemBackgroundColor
        {
            get => (Color)GetValue(SelectedItemBackgroundColorProperty);
            set => SetValue(SelectedItemBackgroundColorProperty, value);
        }

        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            nameof(BackgroundColor),
            typeof(Color),
            typeof(SegmentedControl),
            default(Color)
        );

        public Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }


        public static readonly BindableProperty SegmentSelectedCommandParameterProperty = BindableProperty.Create(
            nameof(SegmentSelectedCommandParameter),
            typeof(object),
            typeof(SegmentedControl),
            null
            );

        public object SegmentSelectedCommandParameter
        {
            get => (object)GetValue(SegmentSelectedCommandParameterProperty);
            set => SetValue(SegmentSelectedCommandParameterProperty, value);
        }

        public static readonly BindableProperty SegmentSelectedCommandProperty = BindableProperty.Create(nameof(SegmentSelectedCommand), typeof(ICommand), typeof(SegmentedControl));
        public ICommand SegmentSelectedCommand
        {
            get => (ICommand)GetValue(SegmentSelectedCommandProperty);
            set => SetValue(SegmentSelectedCommandProperty, value);
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
#if ANDROID
            Handler?.Invoke("SizeAllocated", width);
#endif
        }
    }
}

