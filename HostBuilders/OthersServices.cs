using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class OthersServices
    {
        public static IHostBuilder AddOthersServices(this IHostBuilder host) 
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddControllersWithViews();
                services.AddServerSideBlazor();

                // Problem: https://stackoverflow.com/questions/60311852/error-connection-disconnected-with-error-error-server-returned-an-error-on-cl
                services.AddSignalR(e => {
                    e.MaximumReceiveMessageSize = 102400000;
                });

                //Чтобы кирилические символы не переводились в соответствующий Unicode Hex Character Code
                services.Configure<WebEncoderOptions>(options =>
                {
                    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
                });
            });
        }
    }
}