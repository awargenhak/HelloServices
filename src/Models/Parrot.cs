using System;
using ServiceStack.ServiceHost;
using System.ComponentModel;

namespace HelloServices
{
    [Description("GET or DELETE a single Parrot by Id. Use POST to create a new Parrot and PUT to update it")]
    [Route("/1.0.1/parrots", "POST, PUT, PATCH, DELETE")]
    [Route("/1.0.1/parrots/{Id}")]
    public class Parrot : Pet
    {
    }
}