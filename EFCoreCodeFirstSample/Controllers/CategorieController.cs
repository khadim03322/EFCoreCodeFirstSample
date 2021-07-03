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
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {

        private readonly IDataRepository<Categorie> _dataRepository;

        private readonly EmployeeContext _employeeContext;
        public CategorieController(IDataRepository<Categorie> dataRepository, EmployeeContext context)
        {
            _dataRepository = dataRepository;
            _employeeContext = context;
        }


        // GET: api/Post
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Categorie> categories = _dataRepository.GetAll();
            return Ok(categories);
        }



        [HttpGet("produitsbyIdCategorie/{id}")]
        public IActionResult GetAllProduitsByIdCategorie(long id)
        {
            // IEnumerable<Post> produits = _dataRepository.GetAllProduitByCategorie();

            Categorie ca = _employeeContext.Categories.Include(c => c.Posts).FirstOrDefault(c => c.CategorieId == id);


            return Ok(ca.Posts.ToList());
        }


    }
}
