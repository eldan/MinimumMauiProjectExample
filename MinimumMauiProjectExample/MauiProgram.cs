using MinimumMauiProjectExample.Services;
using CommunityToolkit.Maui;

namespace MinimumMauiProjectExample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            AppService.GetInstance().Init();
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            //builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
