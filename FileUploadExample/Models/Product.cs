using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [NotMapped] // Does not get stored in DB
        public IFormFile ProductPhoto { get; set; }

        /// <summary>
        /// URL where the product photo is stored
        /// </summary>
        public string PhotoUrl { get; set; }
    }
}
