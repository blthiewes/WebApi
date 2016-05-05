using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace RestfulApi.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class CastleWindsorDependencyScope : IDependencyScope
    {
        /// <summary>
        ///     Indicates whether or not the class has previously been disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     The scope of the components being resolved.
        /// </summary>
        /// <remarks>
        ///     This scope variable contains the castle scope object created when 
        ///     resolving the component with castle.
        /// </remarks>
        private IDisposable _scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleWindsorDependencyScope"/> class.
        /// </summary>
        /// <param name="container">The castle container used to resolve components.</param>
        /// <exception cref="System.ArgumentNullException">container</exception>
        public CastleWindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
            _scope = Container.BeginScope();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CastleWindsorDependencyScope"/> class.
        /// </summary>
        ~CastleWindsorDependencyScope()
        {
            Dispose(false);
        }

        /// <summary>
        ///     The Castle container used to resolve components.
        /// </summary>
        public IWindsorContainer Container { get; protected set; }


        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Resolves a component from the Castle container.
        /// </summary>
        /// <param name="serviceType">The type of the component to be resolved.</param>
        /// <returns>
        ///     The resolved component; otherwise <c>null</c> if no component could be resolved.
        /// </returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ComponentNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        ///     Resolves a collection components from the Castle container.
        /// </summary>
        /// <param name="serviceType">The type of the component to be resolved.</param>
        /// <returns>
        ///     A list of the resolved components; otherwise <c>new List()</c> if no components could be resolved.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            // Not expected to trow an exception, rather return an empty IEnumerable.
            return Container.ResolveAll(serviceType).Cast<object>();
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _scope != null)
                {
                    // Cleanup managed resources here, if necessary.
                    _scope.Dispose();
                    _scope = null;

                }
                // Cleanup any unmanaged resources here, if necessary.
                _disposed = true;
            }
        }
    }
}