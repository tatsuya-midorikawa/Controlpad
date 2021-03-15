using System;
using System.Collections.Generic;
using System.Linq;
using Controlpad.Internals;

namespace Controlpad
{
    public sealed class Runbook
    {
        private readonly int capacity;
        private readonly Stack<IUndoableCommand> undoCommands;
        private readonly Stack<IUndoableCommand> redoCommands;

        public Runbook() : this(capacity: 30) { }
        public Runbook(int capacity)
        {
            this.capacity = capacity;
            undoCommands = new Stack<IUndoableCommand>(capacity);
            redoCommands = new Stack<IUndoableCommand>(capacity);
        }

        public bool CanUndo => undoCommands.Any();
        public bool CanRedo => redoCommands.Any();

        public bool Invoke<T, U>(T state, U newValue)
            where T : class
        {
            if (capacity <= undoCommands.Count)
                return false;

            if (!SnapshotStorage<T, Snapshot<T, U>>.TryGetValue(state, out Snapshot<T, U> snapshot))
                return false;

            var command = snapshot.ToCommand(newValue);

            command.Invoke();
            redoCommands.Clear();
            undoCommands.Push(command);
            return true;
        }

        public void Undo()
        {
            if (!CanUndo)
                return;
            var command = undoCommands.Pop();
            command.Undo();
            redoCommands.Push(command);
        }

        public void Redo()
        {
            if (!CanRedo)
                return;
            var command = redoCommands.Pop();
            command.Redo();
            undoCommands.Push(command);
        }

        public void Refresh()
        {
            undoCommands.Clear();
            redoCommands.Clear();
        }

        public bool TryAdd<T, U>(T state, U value, Action<T, U> updater)
            where T : class
        {
            var snapshot = new Snapshot<T, U>(state, value, updater);
            return SnapshotStorage<T, Snapshot<T, U>>.TryAdd(state, snapshot);
        }
    }
}
