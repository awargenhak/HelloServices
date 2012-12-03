using System;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.ServiceInterface;

namespace HelloServices
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class PetsService : RestServiceBase<Pets>
    {
        PetDatabase _pets = Global.petsDB;

        public override object OnGet(Pets pets)
        {
            //            if (string.IsNullOrEmpty (pets.PetType)) {
            //                return from n in PetDatabase.Instace.Pets 
            //                    select n;
            //            }

            switch (pets.GetType().ToString().ToLower())
            {
                case "DOGS":
                case "CATS":
                case "PARROT":
                    return from n in _pets.Pets
                           where n.GetType().Name == pets.PetType
                           select n;
                case "NAME":
                    return from n in _pets.Pets
                           orderby n.Name
                           select n;
            }
            return null;
        }
    }
}