using EmployeeBenefits.Helpers.BenefitCalculator;
using EmployeeBenefits.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EmployeeBenefits
{
    public static class UnityConfig
    {

        private static IUnityContainer _container;        
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }


                public static void RegisterComponents()
        {
            Container = new UnityContainer();
            
            Container.RegisterType<IBenefitCalculatorHelper, BenefitCalculatorHelper>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }
}