using SegmentedControl.Maui.Handlers;

namespace SegmentedControl.Maui
{
	public static class AppBuilderExtension
	{
        public static MauiAppBuilder UseSegmentedControl(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers((handlers) =>
            {
                handlers.AddHandler(typeof(SegmentedControl), typeof(SegmentedControlHandler));
            });
            return builder;
        }
    }
}

