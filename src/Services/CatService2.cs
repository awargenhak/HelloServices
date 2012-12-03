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
    public class CatService2 : RestServiceBase<Cat2>
    {
        PetDatabase _pets = Global.petsDB;

        public override object OnGet(Cat2 cat)
        {
            if (cat.Id == Guid.Empty)
            {
                return from n in _pets.Pets
                       where n.GetType() == typeof(Cat2)
                       select n;
            }
            return (from n in _pets.Pets
                    where n.Id == cat.Id
                    select n).SingleOrDefault();
        }

        public override object OnDelete(Cat2 cat)
        {
            var status = _pets.Pets.Contains(cat);

            if (!status)
            {
                return new NotFoundResponse();
            }
            _pets.Pets.Remove(cat);
            return cat;
        }

        public override object OnPost(Cat2 cat)
        {
            var status = _pets.Pets.Contains(cat);

            if (!status)
            {
                return new NotFoundResponse();
            }

            _pets.Pets.Add(cat);
            return cat;
        }

        public override object OnPut(Cat2 cat)
        {
            var x = (from n in _pets.Pets
                     where n.Id == cat.Id
                     select n).SingleOrDefault();

            if (x == null)
            {
                return new NotFoundResponse();
            }

            _pets.Pets.Remove(cat);
            _pets.Pets.Add(cat);
            return cat;
        }
    }
}