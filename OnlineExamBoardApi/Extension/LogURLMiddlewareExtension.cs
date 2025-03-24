namespace OnlineExamBoardApi.Extension
{
    public static class LogURLMiddlewareExtension
    {
        public static IApplicationBuilder UseLogMiddelware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogURLMiddleware>();
        }
    }
}
