using System.Threading.Tasks;

namespace Code.Data.Ports
{
    public interface IPersistance
    {
        bool Save<T>(T objectToSave) where  T : class;
        Task<T> Load<T>() where  T : class;
    }
}