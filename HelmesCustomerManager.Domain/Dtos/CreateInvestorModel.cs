using System.ComponentModel.DataAnnotations;

namespace HelmesCustomerManager.Domain.Dtos;

public class CreateCustomerModel
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required ISet<Guid> SelectedSectors { get; set; }
}