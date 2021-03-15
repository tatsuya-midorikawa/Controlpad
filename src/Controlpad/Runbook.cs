using System;
using System.Collections.Generic;
using System.Linq;
using Controlpad.Internals;

namespace Controlpad
{
    internal static class LinkedListExtensions
    {
        public static T Pop<T>(this LinkedList<T> list)
        {
            var cache = list.Last.Value;
            list.RemoveLast();
            return cache;
        }

        public static void Push<T>(this LinkedList<T> list, T value)
        {
            list.AddLast(value);
        }
    }

    public sealed class Runbook
    {
        private readonly int capacity;
        private readonly LinkedList<IUndoableCommand> undoCommands;
        private readonly LinkedList<IUndoableCommand> redoCommands;

        public Runbook() : this(int.MaxValue) { }
        public Runbook(int capacity)
        {
            this.capacity = capacity;
            undoCommands = new LinkedList<IUndoableCommand>();
            redoCommands = new LinkedList<IUndoableCommand>();
        }

        public bool CanUndo => undoCommands.Any();
        public bool CanRedo => redoCommands.Any();

        public void Invoke<T, U>(T state, U newValue)
            where T : class
        {
            if (capacity <= undoCommands.Count)
            {
                // capacityを超えている場合, 最初に登録した値を削除して容量を空ける
                undoCommands.RemoveFirst();
            }

            if (!SnapshotStorage<T, Snapshot<T, U>>.TryGetValue(state, out Snapshot<T, U> snapshot))
                throw new InvalidOperationException("対応するSnapshotが登録されていません。");

            var command = snapshot.ToCommand(newValue);

            command.Invoke();
            redoCommands.Clear();
            undoCommands.Push(command);
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
