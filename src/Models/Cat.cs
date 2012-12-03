using System;
using ServiceStack.ServiceHost;
using System.ComponentModel;

namespace HelloServices
{
    [Description("GET or DELETE a single Cat by Id. Use POST to create a new Cat and PUT to update it")]
    [Route("/cats", "POST, PUT, PATCH, DELETE")]
    [Route("/cats/{Id}")]
    public class Cat : Pet
    {
    }
}