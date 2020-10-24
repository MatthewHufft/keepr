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
    internal IEnumerable<Keep> GetAll()
    {
      return _repo.GetAll();
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
      if (original.CreatorId != userId) { throw new Exception("You cannot delete a post that is not yours"); }
      _repo.Remove(id);
      return "Successfully deleted the thing";

    }
  }
}