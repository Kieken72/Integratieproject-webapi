using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class FileUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Imageid
        {
            get;
            set;
        }
        public string Imagename
        {
            get;
            set;
        }
        public byte[] Imagedata
        {
            get;
            set;
        } 
    }
}