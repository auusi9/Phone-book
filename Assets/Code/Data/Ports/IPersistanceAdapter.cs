using System.Threading.Tasks;

namespace Code.Data.Ports
{
    public interface IPersistenceAdapter<T> where T : class
    {
        void SaveData(T dataToSave, string path);
        Task<T> LoadData(string path);
    }
}