using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage ="Name is a required field.")]
        [MinLength(2,ErrorMessage ="Name must consist of at least 2 characters.")]
        [MaxLength(50,ErrorMessage ="Name must consist of at maximum 50 characters.")]
        public string Name { get; init; }
        [Required(ErrorMessage ="Price is a required field.")]
        [Range(10,1000)]
        public decimal Price { get; init; }
    }
}
