using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Infrastructure
{
    public class DogRepositoryFs : IDogRepository
    {
        private static List<Dog> _dogs;
        private static int _nextId = 1;
        private const string PATHNAME = "data";
        private const string FILENAME = "doggieData.json";
        private readonly string _fileFullPath = Path.Combine(PATHNAME, FILENAME);

        public DogRepositoryFs()
        {
            if (_dogs == null)
            {
                _dogs = ReadList();
                _nextId = _dogs.Max(d => d.Id) + 1;
            }
        }
        public void Add(Dog newDog)
        {
            newDog.Id = _nextId++;
            _dogs.Add(newDog);
            SaveList();
        }

        public void Delete(Dog dogToDelete)
        {
            var dog = GetById(dogToDelete.Id);
            _dogs.Remove(dog);
            SaveList();
        }

        public void Edit(Dog updatedDog)
        {
            var dog = GetById(updatedDog.Id);

            dog.Name = updatedDog.Name;
            dog.Breed = updatedDog.Breed;
            SaveList();
        }

        public Dog GetById(int id)
        {
            return _dogs.Find(d => d.Id == id);
        }

        public List<Dog> ListAll()
        {
            return _dogs;
        }

        private void SaveList()
        {
            var listStr = JsonConvert.SerializeObject(_dogs);

            if (!Directory.Exists(PATHNAME))
            {
                Directory.CreateDirectory(PATHNAME);
            }

            File.WriteAllText(_fileFullPath, listStr);
        }

        private List<Dog> ReadList()
        {
            try
            {
                var listStr = File.ReadAllText(_fileFullPath);

                var rawList = JsonConvert.DeserializeObject<List<Dog>>(listStr);

                if (rawList.Count > 0)
                {
                    return rawList;
                }
            }
            catch (Exception)
            {
                // Log the error
            }

            return new List<Dog>();
        }
    }
}
