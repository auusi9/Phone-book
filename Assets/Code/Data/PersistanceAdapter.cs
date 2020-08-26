using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Code.Data.Ports;
using UnityEngine;

namespace Code.Data
{
    public class PersistenceAdapter<T> : IPersistenceAdapter<T> where T : class
    {
        public async void SaveData(T dataToSave, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string completePath = Application.persistentDataPath + path;
            
            await Task.Run(() =>
            {
                using (FileStream stream = File.Open(completePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    bf.Serialize(stream, dataToSave);
                    stream.Close();
                }
            });
        }

        public async Task<T> LoadData(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string completePath = Application.persistentDataPath + path;
            T dataLoaded = null;
            
            await Task.Run(() =>
            {
                using (FileStream stream = File.Open(completePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    if (stream.Length > 0)
                    {
                        try
                        {
                            dataLoaded = (T)bf.Deserialize(stream);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError("Error deserealizing stream");
                        }
                    }
                    stream.Close();
                }
            });;

            return dataLoaded;
        }
    }
}