namespace CustomerManagementSystem.Application
{
    public interface ICommand
    {

    }
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
    
    public interface IQuery<TResult>
    {

    }
    public interface IQueryHandler<Tin,TResult>
    {
        List<T> Query<T>(Tin t);
    }
}
