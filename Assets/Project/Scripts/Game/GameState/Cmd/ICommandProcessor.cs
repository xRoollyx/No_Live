namespace Project.Scripts.Game.GameState.Cmd{
    public interface ICommandProcessor{
        void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        bool Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}