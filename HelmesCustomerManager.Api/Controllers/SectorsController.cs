using HelmesCustomerManager.Persistence.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HelmesCustomerManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectorsController(ISectorRepository _sectorRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetSectors() => Ok(_sectorRepository.GetSectors());

    [HttpPost]
    public IActionResult AddInvestor() => Ok(_sectorRepository.GetSectors());
}