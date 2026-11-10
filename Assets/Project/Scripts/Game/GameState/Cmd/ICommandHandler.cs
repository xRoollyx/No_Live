namespace Project.Scripts.Game.GameState.Cmd{
    public interface ICommandHandler<TCommand> where TCommand : ICommand{
        bool Handle(TCommand command);
    }
}