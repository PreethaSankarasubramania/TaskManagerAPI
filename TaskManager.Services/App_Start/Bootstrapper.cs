using TaskManager.Repositories;

namespace TaskManager.Services.App_Start
{
    public class Bootstrapper
    {
        public static void Configure()
        {
            ObjectFactory.Container.Configure(x =>
            {
                x.AddRegistry<ServicesRegistry>();                
            });

            var log = ObjectFactory.Container.WhatDoIHave();
        }
    }
    public class ServicesRegistry : StructureMap.Registry
    {
        public ServicesRegistry()
        {
            Scan(x =>
            {
                x.Assembly("TaskManager.Business");
                x.Assembly("TaskManager.Repositories");
                x.Assembly("TaskManager.Services");                
                x.WithDefaultConventions();
            });

            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}