using CoreWCF;
using CoreWCF.Configuration;
using PT_InfraestructuraWCF.Repository.RegisterUser;
using PT_SumitempWCF.Services;
using RegisterUserWCF;
using SoapCore;

namespace PT_SumitempWCF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<RegisterUserService>();
            builder.Services.AddScoped<RegisterUserRepository>();

            builder.Services.AddScoped<DataBaseRegisterUser>(provider =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                return new DataBaseRegisterUser(connectionString);
            });


            // Configurar servicios WCF
            builder.Services.AddServiceModelServices();
            //builder.Services.AddServiceModelMetadata(); // Configuración de metadata

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            

            var app = builder.Build();

            // Usar SoapCore y mapear el servicio
            app.UseRouting();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=RegisterUser}/{action=Dashboard}");

            app.Run();
        }
    }
}
