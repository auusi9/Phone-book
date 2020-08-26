using System;
using System.Threading.Tasks;
using Code.Data.Ports;

namespace Code.Data
{
    public class Persistance : IPersistance
    {
        public bool Save<T>(T objectToSave) where  T : class
        {
            IPersistenceAdapter<T> adapter = new PersistenceAdapter<T>();

            try
            {
                adapter.SaveData(objectToSave, objectToSave.GetType().Name + ".data");
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Task<T> Load<T>() where  T : class
        {            
            IPersistenceAdapter<T> adapter = new PersistenceAdapter<T>();

            return adapter.LoadData(typeof(T).Name + ".data");
        }
    }
}