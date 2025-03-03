using ControleContatos.Data;
using ControleContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ControleContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BancoContext>(o =>
            {
                o.UseSqlServer("Server=PC-JOAO\\SQLEXPRESS;Database=DB_SistemaContatos;User Id=sa;Password=123456;Trusted_Connection=true;TrustServerCertificate=true");
            });
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
