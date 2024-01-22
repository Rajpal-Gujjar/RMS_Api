using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RMSApi.Business.AutoMapper;
using RMSApi.Business.IServices;
using RMSApi.Business.Services;
using RMSApi.Data;
using RMSApi.Data.Context;
using RMSApi.Data.UnitOfWork;

namespace RMSApi.Business.Extension
{
    public static class AddRMSDbContext
    {
        public static IServiceCollection AddRMSContext(this IServiceCollection services, string connection)
        {
            return services.AddDbContext<RMSDbContext>(options => options.UseSqlServer(connection));
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddTransient<IUnitOfWork,UnitOfWork>();
        }

        public static IServiceCollection AddCompanyServices(this IServiceCollection services)
        {
            return services.AddTransient<ICompanyServices, CompanyServices>();
        }

        public static IServiceCollection AddJobAppliedServices(this IServiceCollection services)
        {
            return services.AddTransient<IJobAppliedServices, JobAppliedServices>();
        }

        public static IServiceCollection AddJobPostServices(this IServiceCollection services)
        {
            return services.AddTransient<IJobPostServices, JobPostServices>();
        }

        public static IServiceCollection AddJobSeekerServices(this IServiceCollection services)
        {
            return services.AddTransient<IJobSeekerServices, JobSeekerServices>();
        }

        public static IServiceCollection AddAdminServices(this IServiceCollection services)
        {
            return services.AddTransient<IAdminServices, AdminServices>();
        }

        public static IServiceCollection AddAutoMapperExtention(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(RMSProfile));
        }
    }
}