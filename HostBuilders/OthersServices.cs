﻿namespace EasyToEnter.ASP.HostBuilders
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
            });
        }
    }
}