namespace Controlpad
{
    public sealed class UndoableCommand<T, U> : IUndoableCommand
         where T : class
    {
        private readonly Snapshot<T, U> _current;
        private readonly U _next;
        private U _prev;

        public UndoableCommand(Snapshot<T, U> prev, Snapshot<T, U> next)
        {
            _current = prev;
            _prev = prev.Cache;
            _next = next.Cache;
        }

        void IUndoableCommand.Invoke()
        {
            _prev = _current.Cache;
            _current.SetMemento(_next);
        }

        void IUndoableCommand.Undo()
        {
            _current.SetMemento(_prev);
        }

        void IUndoableCommand.Redo()
        {
            _current.SetMemento(_next);
        }
    }
}
