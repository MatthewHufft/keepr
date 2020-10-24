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

    internal object GetById(string userId, int vaultId)
    {
      Vault vault = _repo.GetById(vaultId);
      if (vault == null) { throw new Exception("Invalid Id"); }
      if (vault.CreatorId != userId && vault.IsPrivate == false) { throw new Exception("Access Denied. You are forbidden from accessing that which is not yours."); }
      return vault;

    }
  }
}