using System.Collections.Generic;
using DotNetAssesmentApi.Services;
using DotNetAssesmentApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAssesmentApi.Controllers
{
    [Route("contacts")]
    [Produces("application/json")]
    [ApiController]
    //Normally I would have the api routes return response models inherited from a base response model
    //Also I would have set up a custom middleware in the startup for exception handling.
    public class ContactController : ControllerBase
    {
        readonly IContactService _service;

        public ContactController(
            IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ContactViewModel> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        public ContactViewModel Create([FromBody]ContactViewModel viewModel)
        {
            return _service.Create(viewModel);
        }

        [HttpPut("{id:int}")]
        public ContactViewModel Update(int id, [FromBody] ContactViewModel viewModel)
        {
            viewModel.Id = id;
            return _service.Update(viewModel);
        }

        [HttpGet("{id:int}")]
        public ContactViewModel Get(int id)
        {
            return _service.Get(id);
        }

        [HttpDelete("{id:int}")]
        public string Delete(int id)
        {
            _service.Delete(id);
            return "Contact sucessfully deleted!";
        }

        [HttpGet("call-list")]
        public IEnumerable<CallListViewModel> GetCallList()
        {
            return _service.GetCallList();
        }

    }
}
