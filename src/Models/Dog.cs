using System;
using ServiceStack.ServiceHost;
using System.ComponentModel;

namespace HelloServices
{
    [Description("GET or DELETE a single dog by Id. Use POST to create a new Dog and PUT to update it")]
    [Route("/1.0.1/dogs", "POST, PUT, PATCH, DELETE")]
    [Route("/1.0.1/dogs/{Id}")]
    public class Dog : Pet
    {
    }
}