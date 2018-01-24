using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DogRepositoryFs : IDogRepository
    {
        private static List<Dog> _dogs;
        private static int _nextId = 1;

        public DogRepositoryFs()
        {
            if(_dogs == null)
            {
                _dogs = new List<Dog>();
            }
        }
        public void Add(Dog newDog)
        {
            newDog.Id = _nextId++;
            _dogs.Add(newDog);
        }

        public void Delete(Dog dogToDelete)
        {
            var dog = GetById(dogToDelete.Id); 
            _dogs.Remove(dog);
        }

        public void Edit(Dog updatedDog)
        {
            var dog = GetById(updatedDog.Id);

            dog.Name = updatedDog.Name;
            dog.Breed = updatedDog.Breed;
        }

        public Dog GetById(int id)
        {
            return _dogs.Find(d => d.Id == id);
        }

        public List<Dog> ListAll()
        {
            return _dogs;
        }
    }
}
