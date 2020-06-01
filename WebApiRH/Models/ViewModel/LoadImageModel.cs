using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRH.Models.ViewModel
{
    public class LoadImageModel
    {
        public String Url { get; set; }
        public String UrlDelete { get; set; }

        public static explicit operator Images(LoadImageModel m)
        {
            return new Images()
            {
                Uid = Guid.NewGuid(),
                Url = m.Url,
                UrlRemove = m.UrlDelete,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
