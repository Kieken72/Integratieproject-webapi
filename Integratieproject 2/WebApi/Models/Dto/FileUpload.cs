using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Dto
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