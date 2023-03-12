using System.ComponentModel.DataAnnotations;

namespace NLPWebApi.Models
{
    public class Input
    {
        [Key]
        public string UserText { get; set; }
    }
}
