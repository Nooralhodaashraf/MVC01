using MVC01.custome_Middlewares;

namespace MVC01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); // MVC projects


            //builder.Services.AddControllers(); //API projects 

            //builder.Services.AddRazorPages(); //Razor projects

            var app = builder.Build();


            #region custom middlewares 
            //app.Use( async (contextHeader, nextMiddleware) =>
            //{
            //    //1_ do what this middleware is made for EX:Say hello in Console
            //    Console.WriteLine("Hello Noor");

            //    //2_ go to the next middleWare to this middlware 
            //    await nextMiddleware(contextHeader); // هنا بنخليه يكمل للMiddleware اللي بعد الMiddleware دي ف هيطلع منه واي كود بعد الاوردر دا هيحصل وقت رجول الريكويست للMiddleware تاني 
            //    Console.WriteLine("Bye Bye ya Noor");

            //});

            app.UseMiddleware<RequestTimingMiddleware>();
            #endregion


            #region middlewares
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run(); //last middleware and any middleware after it won't run or executed in the program 
            #endregion
        }
    }
}
