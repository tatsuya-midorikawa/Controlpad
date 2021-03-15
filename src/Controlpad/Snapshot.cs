using System;

namespace Controlpad
{
    public sealed class Snapshot<T, U>
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
        private readonly Action<T, U> updater;

        public UndoableCommand<T, U> CreateCommand(U updateValue)
            => new UndoableCommand<T, U>(this, new Snapshot<T, U>(State, updateValue, updater));

        public void SetMemento(U current)
        {
            updater(State, current);
            Cache = current;
        }
    }
}
