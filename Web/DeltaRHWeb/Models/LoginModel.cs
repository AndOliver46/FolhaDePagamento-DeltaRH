using System.ComponentModel.DataAnnotations;

namespace DeltaRHWeb.Models
{
    public class LoginModel
    {
        public string cnpj { get; set; }
        public string senha { get; set; }
        public string? status { get; set; }
    }
}

