using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key); //bu da generic döndürmek istemediğimizde kullandığımız metot. Ama burda casting yapmak gerekli
        void Add(string key, object value,int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);


    }
}
