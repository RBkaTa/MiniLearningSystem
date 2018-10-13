using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels;
using MiniLearningSystem.Models.ViewModels.Course;

namespace MiniLearningSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitializeMapper();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Course, CourseIndexVm>();
                cfg.CreateMap<CreateCourseVm, Course>();

                cfg.CreateMap<Course, CourseDetailsVm>()
                    .ForMember(p => p.StudentsCount, opt => opt.MapFrom(src => src.Students.Count))
                    .ForMember(p => p.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name))
                    .ForMember(p => p.TrainerId, opt => opt.MapFrom(src => src.TrainerId));

                cfg.CreateMap<ApplicationUser, UserListDetailsVm>();
            });
        }
    }
}
