using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Infrastructure
{
    public class Disposable:IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);

        }

        private void Dispose(bool disposing)
        {
            if(!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {

        }

    }
}
