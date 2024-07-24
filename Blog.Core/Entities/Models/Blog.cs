using Blog.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Models
{
    public class Blog:BaseEntity
    {
        [Required(ErrorMessage = "Title required.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Title 3 ile 150 karakter arasında olmalıdır.")]
        public string Title {  get; set; }

        public string Content { get; set; }
    }
}
