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
    public class ParrotService : RestServiceBase<Parrot>
    {
        PetDatabase _pets = Global.petsDB;

        public override object OnGet(Parrot parrot)
        {
            if (parrot.Id == Guid.Empty)
            {
                return from n in _pets.Pets
                       where n.GetType() == typeof(Parrot)
                       select n;
            }
            return (from n in _pets.Pets
                    where n.Id == parrot.Id
                    select n).SingleOrDefault();
        }

        public override object OnDelete(Parrot parrot)
        {
            var status = _pets.Pets.Contains(parrot);

            if (!status)
            {
                return new NotFoundResponse();
            }
            _pets.Pets.Remove(parrot);
            return parrot;
        }

        public override object OnPost(Parrot parrot)
        {
            var status = _pets.Pets.Contains(parrot);

            if (!status)
            {
                return new NotFoundResponse();
            }

            _pets.Pets.Add(parrot);
            return parrot;
        }

        public override object OnPut(Parrot parrot)
        {
            var x = (from n in PetDatabase.Instace.Pets
                     where n.Id == parrot.Id
                     select n).SingleOrDefault();

            if (x == null)
            {
                return new NotFoundResponse();
            }

            PetDatabase.Instace.Pets.Remove(parrot);
            PetDatabase.Instace.Pets.Add(parrot);
            return parrot;
        }
    }
}