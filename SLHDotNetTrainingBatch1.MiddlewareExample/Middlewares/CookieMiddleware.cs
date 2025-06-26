namespace SLHDotNetTrainingBatch1.MiddlewareExample.Middlewares
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next=next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string username = context.Request.Cookies["Username"]!;
            if (!allowedUrls.Any(x => x == context.Request.Path))
            {
                if (string.IsNullOrEmpty(username))
                {
                    context.Response.Redirect("/Login");
                }
            }

            await _next(context);
        }

        private string[] allowedUrls = { "/", "/login", "/login/index" };
    }
}
