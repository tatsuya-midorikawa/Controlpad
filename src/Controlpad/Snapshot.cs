using System;

namespace Controlpad
{
    internal sealed class Snapshot<T, U>
            where T : class
    {
        public Snapshot(T state, U cache, Action<T, U> updater)
        {
            State = state;
            Cache = cache;
            this.updater = updater;
        }

        public T State { get; }
        public U Cache { get; private set; }
        internal readonly Action<T, U> updater;

        public void Update(U current)
        {
            updater(State, current);
            Cache = current;
        }
    }
}
