using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    internal object GetAll(string userId)
    {
      IEnumerable<Vault> vaults = _repo.GetAll();
      return vaults.ToList().FindAll(v => v.CreatorId == userId || v.IsPrivate);
    }
  }
}