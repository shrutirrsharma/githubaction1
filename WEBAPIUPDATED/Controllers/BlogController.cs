using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class BlogController : ApiController
    {
        public static List<Blog> blogList = new List<Blog>()
            {
                new Blog { Id = 1, Name="C-SharpCorner", Url="http://www.c-sharpcorner.com/"},
                new Blog { Id = 2, Name="CodeProject", Url="http://www.codeproject.com"},
                new Blog { Id = 3, Name="StackOverflow", Url="http://stackoverflow.com/"},
            };

        // GET api/default1
        public List<Blog> Get()
        {
            return blogList;
        }

        // GET api/blog/5
        public Blog Get(int id)
        {
            Blog blogObject = (from blog in blogList
                               where blog.Id == id
                               select blog).SingleOrDefault();
            return blogObject;
        }

        // POST api/blog
        public List<Blog> Post(Blog blogObj)
        {
            blogList.Add(blogObj);

            return blogList;
        }

        // PUT api/blog/5
        public void Put(Blog blogObj)
        {
            Blog blogOrignalObject = (from blog in blogList
                                      where blog.Id == blogObj.Id
                                      select blog).SingleOrDefault();

            blogOrignalObject.Name = blogObj.Name;
            blogOrignalObject.Url = blogObj.Url;
        }

        // DELETE api/blog/5
        public void Delete(int id)
        {
            blogList.RemoveAll(temp => temp.Id == id);
        }
    }
}
