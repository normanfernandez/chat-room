using Chat_Room.Domain.Broker;
using Chat_Room.Domain.Chat;
using Chat_Room.Infraestructure.Broker;
using Chat_Room.Infraestructure.Chat;
using Chat_Room.Infraestructure.EF;
using Chat_Room.Infraestructure.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chat_Room
{
    public class Startup
    {

        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ChatRoomDbContext>(r => 
            {
                r.UseInMemoryDatabase("MemoryDb"); 
            });
            services.AddControllers();
            services.AddScoped<IChatMessageRepository, EFChatMessageRepository>();
            services.AddScoped<IChatRoomRepository, EFChatRoomRepository>();
            services.AddSingleton<ChatHub>();
            services.AddSingleton<IChatMessageHandler, ChatMessageHandler>();
            services.AddSingleton<IMessagePublisher, MessagePublisher>();
            services.AddHostedService<RabbitMQConsumerBackgroundService>();
            services.AddRazorPages();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSignalR(r =>
            {
                r.MapHub<ChatHub>("/hubs");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
