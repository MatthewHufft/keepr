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
      return vaults.ToList().FindAll(v => v.CreatorId == userId || v.IsPrivate == false);
    }

    internal object GetById(string userId, int vaultId)
    {
      Vault vault = _repo.GetById(vaultId);
      if (vault == null) { throw new Exception("Invalid Id"); }
      if (vault.CreatorId != userId && vault.IsPrivate == true) { throw new Exception("Access Denied. You are forbidden from accessing that which is not yours."); }
      return vault;

    }

    internal Vault Create(Vault newVault)
    {
      //create a new vault and then reassign it's Id value to the one generated and passed back from the _repo
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    internal object Edit(Vault update, string userId)
    {
      //get the original vault and validate user access. Then check for null values in submission
      Vault original = _repo.GetById(update.Id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied... This is not yours"); }
      update.Name = update.Name == null ? original.Name : update.Name;
      update.Description = update.Description == null ? original.Description : update.Description;

      return _repo.Edit(update);

    }

    internal object Delete(int id, string userId)
    {
      Vault original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied... This is not yours"); }
      _repo.Remove(id);
      return "Successfully deleted the vault";
    }

    internal IEnumerable<Vault> GetVaultsByCreatorId(string id)
    {
      return _repo.GetVaultsByCreatorId(id);
    }
  }
}