using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _service;
    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateAsync([FromBody] VaultKeep newVK)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVK.CreatorId = userInfo.Id;
        VaultKeep createdVK = _service.Create(newVK);
        return Ok(createdVK);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteAsync(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.Delete(id, userInfo.Id);
        return Ok("Successfully Deleted vaultKeep");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}