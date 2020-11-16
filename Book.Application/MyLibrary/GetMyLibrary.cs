using Book.Database;
using Book.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book.Application.MyLibrary
{
    public class GetMyLibrary
    {
        private ISession _session;
        private ApplicationDbContext _ctx;
        public GetMyLibrary(ISession session, ApplicationDbContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }
        public class Response
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
        }
        public IEnumerable<Response> Show()
        {
            var stringObject = _session.GetString("mylibrary");
            if (string.IsNullOrEmpty(stringObject))
            {
                return new List<Response>();
            }
            var MyLibraryList = JsonConvert.DeserializeObject<List<MyLibraryClass>>(stringObject);
            var response = _ctx.Books.AsEnumerable().Where(x =>MyLibraryList.Any(y => y.BookId == x.Id)).Select(x => new Response
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description
            }).ToList();
            return response;
        }
    }
}
