using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;
using Wonderbox.Exam.Data.Repositories.Implementations;
using Wonderbox.Exam.Data.Repositories.Interfaces;
using Wonderbox.Exam.Data.SqlServer;
using Wonderbox.Exam.Mappers;

namespace Wonderbox.Exam
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => RegisterDependencies(() => new PerRequestLifetimeManager()));

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        public static IUnityContainer RegisterDependencies(Func<LifetimeManager> getLifetimeManager)
            => new UnityContainer()
                .RegisterType<DbContext>(getLifetimeManager(),
                    new InjectionFactory(c => SchoolDbContextFactory.FromConnectionString(ConfigurationManager.ConnectionStrings["Wonderbox"]?.ConnectionString)))
                .RegisterType<IMapper>(getLifetimeManager(), new InjectionFactory(c => AutoMapperConfig.Configure().CreateMapper()))
                .RegisterType<IStudentRepository, StudentDbRepository>(getLifetimeManager());
    }
}