using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Server : IObservable<T>
    {
        public IDisposable Subscribe(IObserver<T> observer)
        {
            
        }
    }
}
