namespace Controlpad
{
    public interface IUndoableCommand
    {
        void Invoke();
        void Undo();
        void Redo();
    }
}
