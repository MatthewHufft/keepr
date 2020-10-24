
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Vault>>> GetById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.GetById(userInfo?.Id, id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.CreatorId = userInfo.Id;
        Vault created = _service.Create(newVault);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault update)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        update.CreatorId = userInfo.Id;
        update.Creator = userInfo;
        update.Id = id;

        return Ok(_service.Edit(update, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);

      }
    }


  }
}