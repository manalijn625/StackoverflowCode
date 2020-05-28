using StackOverFlow.Models.IRepository;
using StackOverFlow.Models.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StackOverFlow
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IQuestionInfo, QuestionInfoRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}