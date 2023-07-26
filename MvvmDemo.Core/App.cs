using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmDemo.Core.ViewModels;
using System;

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
