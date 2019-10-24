using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kpsUowRmqTest.Data.Interfaces;
using kpsUowRmqTest.Data.Models;
using kpsUowRmqTest.Kps;
using kpsUowRmqTest.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

namespace kpsUowRmqTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
           IEnumerable<User> Users=_unitOfWork.UserRepository.Get();
            return new JsonResult(Users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_unitOfWork.UserRepository.Find(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            //kps sorgula
            KpsServiceAdapter kpsServiceAdapter = new KpsServiceAdapter();
            bool result=await kpsServiceAdapter.Validate(user);
            if (result)
            {               
                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Complete();

                new PublisherHelper("userLog", user.TCKN.ToString());

            }
            
            return new JsonResult(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User User)
        {
            if (id != User.Id) return BadRequest();
            _unitOfWork.UserRepository.Update(User);
            _unitOfWork.Complete();

            return new JsonResult(User);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _unitOfWork.UserRepository.Delete(id);
            if (result == false) return NotFound();

            return Ok();
        }
    }
}
