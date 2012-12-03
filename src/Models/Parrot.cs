using System;
using ServiceStack.ServiceHost;
using System.ComponentModel;

namespace HelloServices
{
    [Description("GET or DELETE a single Parrot by Id. Use POST to create a new Parrot and PUT to update it")]
    [Route("/parrots", "POST, PUT, PATCH, DELETE")]
    [Route("/parrots/{Id}")]
    public class Parrot : Pet
    {
    }
}