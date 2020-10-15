using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.ViewModels
{
    public class AddReaderViewModel
    {
        [Required(ErrorMessage ="Reader name is required.")]
        public string ReaderName { get; set; }
    }
}
