using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloServices
{
    public class PetDatabase
    {
        static PetDatabase _instance;
        static object _lock = new object();
        IList<Pet> _pets = new List<Pet>();

        public Pet this[int index]
        {
            get { return _pets[index]; }
        }

        public IList<Pet> Pets
        {
            get { return _pets; }
        }

        public static PetDatabase Instace
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new PetDatabase();
                        _instance._pets.Add(new Dog() { Name = "Spike", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Dog() { Name = "Bo", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Dog() { Name = "Mike", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Cat() { Name = "Kitty", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Cat() { Name = "Mimi", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Cat() { Name = "FurBall", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Parrot() { Name = "Polly", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Parrot() { Name = "Rico", Id = Guid.NewGuid() });
                        _instance._pets.Add(new Parrot() { Name = "Juca", Id = Guid.NewGuid() });
                    }
                }
                return _instance;
            }
        }
    }
}