using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos.Interfeces
{
    public abstract class StructutreBase<T>

    {
        protected abstract void Insert(T value);
        protected abstract void Delete(T value);
        protected abstract T Get(T value);
    }
}
