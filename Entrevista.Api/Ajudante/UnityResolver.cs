﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Entrevista.Api.Ajudante
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;
        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new Exception("conatiner");
            }

            this.container = container;

        }
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}