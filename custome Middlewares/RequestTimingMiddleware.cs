using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace MVC01.custome_Middlewares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate next;

        public RequestTimingMiddleware(RequestDelegate next) {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {

        

            var watch = Stopwatch.StartNew();

            //1_ do what this middleware is made for EX:Say hello in Console
            //Console.WriteLine("Hello Noor");
            //2_ go to the next middleWare to this middlware 
            await next(context); // هنا بنخليه يكمل للMiddleware اللي بعد الMiddleware دي ف هيطلع منه واي كود بعد الاوردر دا هيحصل وقت رجول الريكويست للMiddleware تاني 
            //Console.WriteLine("Bye Bye ya Noor");
            watch.Stop();
            Console.WriteLine($"context :{context.Request.Path}:: time:{watch.ElapsedMilliseconds}" );
        }
    }
}
