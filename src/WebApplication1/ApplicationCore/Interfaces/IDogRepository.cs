using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IDogRepository
    {
        List<Dog> ListAll();
        Dog GetById(int id);
        void Add(Dog newDog);
        void Edit(Dog updatedDog);
        void Delete(Dog dogToDelete);
    }
}
