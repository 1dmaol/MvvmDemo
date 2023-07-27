using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmDemo.Core.ViewModels;

namespace MvvmDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
