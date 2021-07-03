using EFCoreCodeFirstSample.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity.DataManager
{
    public class PostManager : IDataRepository<Post>
    {

        readonly EmployeeContext _employeeContext;
        public PostManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<Post> GetAll()
        {       //
            return _employeeContext.Posts.Include(b => b.Categorie).ToList();
        }
        public Post Get(long id)
        { //
            return _employeeContext.Posts.Include(b => b.Categorie)
                  .FirstOrDefault(e => e.PostId == id);
        }
        public void Add(Post entity)
        {
            _employeeContext.Posts.Add(entity);
            _employeeContext.SaveChanges();
        }
        public void Update(Post post, Post entity)
        {
            post.Title = entity.Title;
           

            _employeeContext.SaveChanges();
        }
        public void Delete(Post post)
        {
            _employeeContext.Posts.Remove(post);
            _employeeContext.SaveChanges();
        }


    }
}
