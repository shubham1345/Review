using DAL.Inerface;
using DAL.Repository;

namespace OnlineExamBoardApi.IOC
{
    public static class DependencyResolver
    {
        public static void AddCores(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthRepo>();
            service.AddScoped<ICommonService, CommonRepo>();
            service.AddScoped<IDapper, DapperRepo>();

            service.AddScoped<ICollegeService, CollegeRepo>();
            service.AddScoped<IBranchService, BranchRepo>();
            service.AddScoped<IStudentService, StudentRepo>();
        }
    }
}
