using EFCoreCodeFirstSample.Entity;
using EFCoreCodeFirstSample.Entity.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IDataRepository<Post> _dataRepository;

        private readonly EmployeeContext _employeeContext;
        public PostController(IDataRepository<Post> dataRepository, EmployeeContext context)
        {
            _dataRepository = dataRepository;
            _employeeContext = context;
        }


        // GET: api/Post
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Post> posts = _dataRepository.GetAll();
            return Ok(posts);
        }
        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Post post = _dataRepository.Get(id);
            if (post == null)
            {
                return NotFound("The post record couldn't be found.");
            }
            return Ok(post);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post is null.");
            }
            _dataRepository.Add(post);
            return CreatedAtRoute(
                  "Get",
                  new { Id = post.PostId },
                  post);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post is null.");
            }
            Post postToUpdate = _dataRepository.Get(id);
            if (postToUpdate == null)
            {
                return NotFound("The Post record couldn't be found.");
            }
            _dataRepository.Update(postToUpdate, post);
            return NoContent();
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Post post = _dataRepository.Get(id);
            if (post == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _dataRepository.Delete(post);
            return NoContent();
        }



        // GET: api/Post
        [HttpGet("search")]
        public IActionResult Search(string kw)
        {

            IEnumerable<Post> posts = _employeeContext
                .Posts.
                Include(b => b.Categorie)
                .Where(p=>p.Title.Contains(kw))
                .ToList();

           
            return Ok(posts);
        }


        [HttpGet("paginate")]
        public IActionResult Pagination(int page=1 ,int size=1)
        {
            int skipValue = (page - 1) * size;

            IEnumerable<Post> posts = _employeeContext
                .Posts.
                Include(b => b.Categorie)
                .Skip(skipValue)
                .Take(size)
            
                .ToList();


            return Ok(posts);
        }



    }
}
