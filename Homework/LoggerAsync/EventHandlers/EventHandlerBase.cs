namespace LoggerAsync.EventHandlers;

public abstract class EventHandlerBase<TEventArgs>
{
    public abstract void Handle(object? sender, TEventArgs eventArgs);
}