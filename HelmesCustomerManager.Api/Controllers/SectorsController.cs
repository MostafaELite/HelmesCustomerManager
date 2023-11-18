using HelmesCustomerManager.Persistence.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HelmesCustomerManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectorsController : ControllerBase
{
    private readonly ISectorRepository _sectorRepository;

    public SectorsController(ISectorRepository sectorRepository) => _sectorRepository = sectorRepository;

    [HttpGet]
    public IActionResult GetSectors() => Ok(_sectorRepository.GetSectors());

    [HttpPost]
    public IActionResult AddInvestor() => Ok(_sectorRepository.GetSectors());
}