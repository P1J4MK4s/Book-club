using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Book.Domain.Models;
using System.Collections.Generic;

namespace Book.Application.MyLibrary
{
    public class AddToMyLibrary
    {
        private ISession _session;

        public AddToMyLibrary(ISession session)
        {
            _session = session;
        }
        public class Request
        {
            public int BookId { get; set; }
        }
        public void Add(Request request)
        {
            var MyLibraryList = new List<MyLibraryClass>();
            var stringObject = _session.GetString("mylibrary");
            
            if (!string.IsNullOrEmpty(stringObject))
            {
                MyLibraryList =  JsonConvert.DeserializeObject<List<MyLibraryClass>>(stringObject);
            }

            MyLibraryList.Add( new MyLibraryClass
            {
                BookId = request.BookId
            });
            stringObject = JsonConvert.SerializeObject(MyLibraryList);

            _session.SetString("mylibrary", stringObject);
        }
    }
}
