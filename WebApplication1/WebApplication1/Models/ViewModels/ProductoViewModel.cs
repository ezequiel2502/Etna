using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "descripcion")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "precio")]
        public double precio { get; set; }
    }
}