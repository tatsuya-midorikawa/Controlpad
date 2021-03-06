using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlpad
{
    internal static class SnapshotExtensions
    {
        public static IUndoableCommand ToCommand<T, U>(this Snapshot<T, U> @this, U parameter) where T : class
            => new UndoableCommand<T, U>(@this, new Snapshot<T, U>(@this.State, parameter, @this.updater));
    }
}
