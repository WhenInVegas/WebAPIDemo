using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoAPI.Models;

namespace DemoAPI.Controllers
{
    /// <summary>
    /// This is where I give you all the information about my peeps
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> People = new List<Person>();

        public PeopleController()
        {
            People.Add(new Person {FirstName = "Tim", LastName = "Corey", Id = 1});
            People.Add(new Person { FirstName = "Sue", LastName = "Storm", Id = 2 });
            People.Add(new Person { FirstName = "Bilbo", LastName = "Baggins", Id = 3 });
        }

        /// <summary>
        /// Get a list of the first name of all users.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="age">We want to know how old they are.</param>
        /// <returns>A list of first names..duh</returns>
        [Route("api/People/GetFirstNames/{userId:int}/{age:int}")]
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();
            foreach (Person person in People)
            {
                output.Add(person.FirstName);
            }

            return output;
        }

        // GET: api/People
        public List<Person> Get()
        {
            return People;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/People
        public void Post(Person val)
        {
            People.Add(val);
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            Person removeMe = People.Single(p => p.Id == 2);
            People.Remove(removeMe);
        }
    }
}
