using PT_InfraestructuraWCF.Repository.RegisterUser;
using PT_SumitempWCF.Services;

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

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            

            var app = builder.Build();

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
