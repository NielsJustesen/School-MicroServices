﻿namespace Memory_MicroService
{
    using System;
    using System.IO;
    using Autofac;
    using log4net.Config;
    using log4net.Repository.Hierarchy;
    using MicroServiceEcoSystem.Memory_MicroService;
    using Topshelf;

    using Topshelf.Autofac;
    using Topshelf.Diagnostics;


    /// <summary>   A program. </summary>
    class Program 
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Main entry-point for this application. </summary>
        ///
        /// <param name="args"> An array of command-line argument strings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // Service itself
            builder.RegisterType<MemoryMicroService>()
                 .AsImplementedInterfaces()
                 .AsSelf()
                 ?.InstancePerLifetimeScope();

            builder.RegisterType<Logger>().SingleInstance();

            var container = builder.Build();

            XmlConfigurator.ConfigureAndWatch(new FileInfo(@".\log4net.config"));

            HostFactory.Run(c =>
            {
                c?.UseAutofacContainer(container);
                c?.UseLog4Net();
                c?.ApplyCommandLineWithDebuggerSupport();
                c?.EnablePauseAndContinue();
                c?.EnableShutdown();
                c?.OnException(ex => { Console.WriteLine(ex.Message); });
                
                c?.Service<MemoryMicroService>(s =>
                {
                    s.ConstructUsingAutofacContainer<MemoryMicroService>();

                    s?.ConstructUsing(settings =>
                    {
                        var service = AutofacHostBuilderConfigurator.LifetimeScope.Resolve<MemoryMicroService>();
                        return service;
                    });
                    s?.ConstructUsing(name => new MemoryMicroService());

                    s?.WhenStarted((MemoryMicroService server, HostControl host) => server.OnStart(host));
                    s?.WhenPaused(server => server.OnPause());
                    s?.WhenContinued(server => server.OnResume());
                    s?.WhenStopped(server => server.OnStop());
                    s?.WhenShutdown(server => server.OnShutdown());
                });
                
                c?.RunAsNetworkService();
                c?.StartAutomaticallyDelayed();
                c?.SetDescription(string.Intern("Memory Microservice Sample"));
                c?.SetDisplayName(string.Intern("MemoryMicroservice"));
                c?.SetServiceName(string.Intern("MemoryMicroService"));

                c?.EnableServiceRecovery(r =>
                {
                    r?.OnCrashOnly();
                    r?.RestartService(1); //first
                    r?.RestartService(1); //second
                    r?.RestartService(1); //subsequents
                    r?.SetResetPeriod(0);
                });
            });
        }
    }
}