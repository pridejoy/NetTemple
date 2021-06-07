using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Common
{
    /// <summary>
    /// 简单的缓存接口，只有查询和添加，以后会进行扩展
    /// </summary>
    public interface IMemoryCache
    {
        object Get(string cacheKey);

        void Set(string cacheKey, object cacheValue, int timeSpan);
    }
}
