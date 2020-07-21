using MiniDMartApp.Application.Interfaces;
using MiniDMartApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniDMart.WebAPI.Controllers
{
    [RoutePrefix("api/v1/StateAPI")]
    public class StateAPIController : ApiController
    {
        private readonly IStateDataService _stateDataService;
        public StateAPIController(IStateDataService stateDataService)
        {
            this._stateDataService = stateDataService;
        }
        // GET: api/StateAPI
        public IEnumerable<StateDataModel> Get()
        {
            var lstModel = _stateDataService.GetAll();
            return lstModel;
        }

        // GET: api/StateAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StateAPI
        public void Post([FromBody]StateDataModel value)
        {
            _stateDataService.Add(value);
        }

        // PUT: api/StateAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StateAPI/5
        public void Delete(int id)
        {
        }
    }
}
