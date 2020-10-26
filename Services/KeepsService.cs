using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Keep> GetAll(string userId)
    {
      IEnumerable<Keep> keeps = _repo.GetAll();
      return keeps;
    }

    internal Keep GetById(int id)
    {
      Keep keepData = _repo.GetById(id);
      if (keepData == null)
      {
        throw new Exception("Invalid Id");
      }
      return keepData;
    }

    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    internal object Delete(int id, string userId)
    {
      Keep original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("You cannot delete that which is not yours"); }
      _repo.Remove(id);
      return original;

    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    internal IEnumerable<Keep> GetKeepsByCreatorId(string profileId)
    {
      return _repo.GetByCreatorId(profileId);
    }

    internal object Edit(Keep update, string userId)
    {
      Keep original = _repo.GetById(update.Id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("You cannot edit that which is not yours"); }
      update.Name = update.Name == null ? original.Name : update.Name;
      update.Description = update.Description == null ? original.Description : update.Description;
      update.Img = original.Img;

      return _repo.Edit(update);
    }
  }
}