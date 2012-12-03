using System;
using ServiceStack.ServiceHost;
using System.ComponentModel;

namespace HelloServices
{
    [Description("GET or DELETE a single Cat by Id. Use POST to create a new Cat and PUT to update it")]
    [Route("/1.0.1/cats", "POST, PUT, PATCH, DELETE")]
    [Route("/1.0.2/cats", "POST, PUT, PATCH, DELETE")]
    [Route("/1.0.1/cats/{Id}")]
    [Route("/1.0.2/cats/{Id}")]
    public class Cat1 : Pet
    {
    }
}