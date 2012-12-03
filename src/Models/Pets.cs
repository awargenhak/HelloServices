using System;
using ServiceStack.ServiceHost;

namespace HelloServices
{
    /// <summary>
    /// Define your ServiceStack web service request (i.e. the Request DTO).
    /// </summary>
    [Route("/pets/type/{PetType}")]
    public class Pets
    {
        public string PetType { get; set; }
    }
}