using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using WeListen.Data;

namespace WeListen.Web.API_Controllers
{
    public class UsersController : ApiController
    {

        private readonly Service _dataService = new Service();

        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("{username}")]
        public bool GetAuthenticatedUser(string username, string password)
        {
            return (_dataService.AuthenticateUser(username, password));
        }



        // GET api/users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
