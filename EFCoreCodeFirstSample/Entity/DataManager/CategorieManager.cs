using EFCoreCodeFirstSample.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity.DataManager
{
   


    public class CategorieManager : IDataRepository<Categorie>
    {

        readonly EmployeeContext _employeeContext;
        public CategorieManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public void Add(Categorie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Categorie entity)
        {
            throw new NotImplementedException();
        }

        public Categorie Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categorie> GetAll()
        {
            return _employeeContext.Categories.ToList();
        }


        public IEnumerable<Post> GetAllProduitByCategorie(long id)
        {
            Categorie ca = _employeeContext.Categories.Include(c => c.Posts).FirstOrDefault(c => c.CategorieId == id);


                return ca.Posts.ToList();
        }


        public void Update(Categorie dbEntity, Categorie entity)
        {
            throw new NotImplementedException();
        }


    }



}
