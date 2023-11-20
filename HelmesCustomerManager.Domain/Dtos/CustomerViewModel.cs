using System.ComponentModel.DataAnnotations;

namespace HelmesCustomerManager.Domain.Dtos;

public class CustomerViewModel
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public ICollection<Guid>? SelectedSectors { get; set; }
}