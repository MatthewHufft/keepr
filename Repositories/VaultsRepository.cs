using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Services
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    private readonly string populateCreator = @"SELECT
    v.*,
    p.*
    FROM vaults v 
    JOIN profiles p ON v.creatorId = profile.id ";

    internal IEnumerable<Vault> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<Vault, Profile, Vault>(sql, (Vault, Profile) => { Vault.Creator = Profile; return Vault; }, splitOn: "id");
    }

    internal Vault GetById(int vaultId)
    {
      string sql = populateCreator + "WHERE v.id = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { vaultId }, splitOn: "id").FirstOrDefault();
    }
  }
}