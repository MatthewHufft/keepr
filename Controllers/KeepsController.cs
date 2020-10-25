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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _service;
    public KeepsController(KeepsService ks)
    {
      _service = ks;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Keep>>> GetAll()
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
    public ActionResult<IEnumerable<Keep>> GetById(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        //gets the logged in users info and assigns as a Profile obj. 
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeep.CreatorId = userInfo.Id;
        //Create the Keep
        Keep createdKeep = _service.Create(newKeep);
        //Set the creator for new Keep to userInfo before returning.
        createdKeep.Creator = userInfo;
        return Ok(createdKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> Edit(int id, [FromBody] Keep update)
    {
      try
      {
        //gets the logged in users info and assigns as a Profile obj. 
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
    public async Task<ActionResult<Keep>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}