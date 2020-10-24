
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _service;
    public VaultsController(VaultsService service)
    {
      _service = service;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vault>>> GetAll()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.GetAll(userInfo?.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpGet("{id}")]
    // [HttpPost]
    // [HttpPut("{id}")]
    // [HttpDelete("{id}")]



  }
}