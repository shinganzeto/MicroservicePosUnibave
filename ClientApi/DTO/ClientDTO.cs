using System.ComponentModel.DataAnnotations;

namespace ClientApi.DTO;

public class ClientDTO
{   
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome precisa ser preenchido")]
    [MinLength(3)]
    [MaxLength(255)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "O endereco precisa ser preenchido")]
    public string? Address { get; set; }

    public string? Fone { get; set; }

}
