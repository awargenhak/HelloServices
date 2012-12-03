using System;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;
using Nancy;
using System.Collections;

namespace HelloServices
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    /// 
    public class DogService : RestServiceBase<Dog>
    {
        PetDatabase _pets = Global.petsDB;

        public override object OnGet(Dog dog)
        {
            if (dog.Id == Guid.Empty)
            {
                return from n in _pets.Pets
                       where n.GetType() == typeof(Dog)
                       select n;
            }
            return (from n in _pets.Pets
                    where n.Id == dog.Id
                    select n).SingleOrDefault();
        }

        public override object OnDelete(Dog dog)
        {
            var status = _pets.Pets.Contains(dog);

            if (!status) {
                return new  NotFoundResponse();
            }
            _pets.Pets.Remove(dog);
            return dog;
        }

        public override object OnPost(Dog dog)
        {
            var status = _pets.Pets.Contains(dog);

            if (!status)
            {
                return new NotFoundResponse();
            }

            _pets.Pets.Add(dog);
            return dog;
        }

        public override object OnPut(Dog dog)
        {
            var x = (from n in _pets.Pets
                     where n.Id == dog.Id
                     select n).SingleOrDefault();

            if (x == null)
            {
                return new  NotFoundResponse();
            }

            _pets.Pets.Remove(dog);
            _pets.Pets.Add(dog);
            return dog;
        }
    }
}