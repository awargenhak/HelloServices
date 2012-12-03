using System;
using ServiceStack.ServiceHost;
using System.ComponentModel;

namespace HelloServices
{
    [Description("GET or DELETE a single dog by Id. Use POST to create a new Dog and PUT to update it")]
    [Route("/dogs", "POST, PUT, PATCH, DELETE")]
    [Route("/dogs/{Id}")]
    public class Dog : Pet
    {
    }
}