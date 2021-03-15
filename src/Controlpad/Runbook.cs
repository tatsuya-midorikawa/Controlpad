using System.Collections.Generic;
using System.Linq;

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

        public bool Invoke(IUndoableCommand command)
        {
            if (capacity <= undoCommands.Count)
                return false;
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
    }
}
