using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlpad.Internals
{
    internal class SnapshotStorage<T, U>
            where T : class
    {
        private static ConcurrentDictionary<T, U> _cache = new ConcurrentDictionary<T, U>();

        public static bool TryGetValue(T key, out U value)
            => _cache.TryGetValue(key, out value);

        public static bool TryAdd(T key, U value)
            => _cache.TryAdd(key, value);

        public static U GetOrAdd(T key, U value)
            => _cache.GetOrAdd(key, value);
    }
}
