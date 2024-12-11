using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //aşağıdaki this genişletmek istediğiniz sınıfın önüne yazılır.C# yapısal özelliğidir.
        //IService collection apilerimizin servis bağımlılıklarını ya da araya girmesini istediğimiz servisleri eklediğimiz yerdir
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) 
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
