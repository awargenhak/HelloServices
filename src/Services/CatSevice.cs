using System;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;
using Nancy;

namespace HelloServices
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class CatService : RestServiceBase<Cat>
    {
        PetDatabase _pets = Global.petsDB;

        public override object OnGet(Cat cat)
        {
            if (cat.Id == Guid.Empty)
            {
                return from n in _pets.Pets
                       where n.GetType() == typeof(Cat)
                       select n;
            }
            return (from n in _pets.Pets
                    where n.Id == cat.Id
                    select n).SingleOrDefault();
        }

        public override object OnDelete(Cat cat)
        {
            var status = _pets.Pets.Contains(cat);

            if (!status)
            {
                return new NotFoundResponse();
            }
            _pets.Pets.Remove(cat);
            return cat;
        }

        public override object OnPost(Cat cat)
        {
            var status = _pets.Pets.Contains(cat);

            if (!status)
            {
                return new NotFoundResponse();
            }

            _pets.Pets.Add(cat);
            return cat;
        }

        public override object OnPut(Cat cat)
        {
            var x = (from n in PetDatabase.Instace.Pets
                     where n.Id == cat.Id
                     select n).SingleOrDefault();

            if (x == null)
            {
                return new NotFoundResponse();
            }

            PetDatabase.Instace.Pets.Remove(cat);
            PetDatabase.Instace.Pets.Add(cat);
            return cat;
        }
    }
}