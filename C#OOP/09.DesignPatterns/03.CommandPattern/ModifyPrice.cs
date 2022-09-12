using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPatternDemo
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Invoke()
        {
            commands.Add(command);
            command.ExecuteAction();
        }
        public void Undo()
        {
            var command = commands.Last();
            command.UndoAction();
            command.ExecuteAction();
            commands.Remove(command);
        }
    }
}
