using AccountAtAGlance.Repository;
using Microsoft.Practices.Unity;
using AccountAtAGlance.Repository;

namespace AccountAtAGlance.Model
{
    //This is a simplified version of the code shown in the videos
    //The instance of UnityContainer is created in the constructor 
    //rather than checking in the Instance property and performing a lock if needed
    public static class ModelContainer
    {
        private static readonly object lockObject = new object();
        private static IUnityContainer _Instance;

        
        public static IUnityContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lockObject)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new UnityContainer();
                            _Instance.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
                            _Instance.RegisterType<ISecurityRepository, SecurityRepository>(new HierarchicalLifetimeManager());
                            _Instance.RegisterType<IMarketsAndNewsRepository, MarketsAndNewsRepository>(new HierarchicalLifetimeManager());
                        }
                    }
                }
                return _Instance;
            }
        }
    }
}
