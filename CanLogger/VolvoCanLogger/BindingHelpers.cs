using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingHelpers
{
    public static class BindingListExtension
    {
        private class BindingListUpdateSuppressor<T> : IDisposable
        {
            private BindingList<T> _list;

            public BindingListUpdateSuppressor(BindingList<T> list)
            {
                _list = list;
                _list.RaiseListChangedEvents = false;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_list != null)
                {
                    if (disposing)
                    {
                        _list.RaiseListChangedEvents = true;
                        _list.ResetBindings();
                    }
                    _list = null;
                }
            }

            public void Dispose()
            {
                Dispose(true);
            }
        }

        public static IDisposable CreateUpdateSuppressor<T>(this BindingList<T> list)
        {
            return new BindingListUpdateSuppressor<T>(list);
        }
    }
}
