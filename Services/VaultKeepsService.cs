using System;
using Keepr.Models;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal VaultKeep Create(VaultKeep newVK)
    {
      newVK.Id = _repo.Create(newVK);
      return newVK;
    }

    internal void Delete(int id, string userId)
    {
      VaultKeep original = _repo.GetById(id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      if (original.CreatorId != userId)
      {
        throw new Exception("You cannot delete that which is not yours.");
      }
      _repo.Delete(id);
    }
  }
}