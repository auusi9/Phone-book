namespace Code.Presentation.Controllers
{
    public interface IController
    {
        void Execute();
    }

    public interface IController<in T>
    {
        void Execute(T contact);
    }
}