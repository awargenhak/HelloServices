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
            return from n in _pets.Pets
                   where n.GetType().Name.ToLower() == pets.PetType.ToLower()
                   select n;
        }
    }
}