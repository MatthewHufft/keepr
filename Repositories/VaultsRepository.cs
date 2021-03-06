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
    JOIN profiles p ON v.creatorId = p.id ";

    internal IEnumerable<Vault> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<Vault, Profile, Vault>(sql, (Vault, Profile) => { Vault.Creator = Profile; return Vault; }, splitOn: "id");
    }

    internal Vault GetById(int id)
    {
      string sql = populateCreator + "WHERE v.id = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Vault newVault)
    {
      // insert newVault into vaults table and return it's Id
      string sql = @"
        INSERT INTO vaults
        (creatorId, name, description, isPrivate) 
        VALUES
        (@CreatorId, @Name, @Description, @IsPrivate);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    internal Vault Edit(Vault update)
    {
      string sql = @"
        UPDATE vaults
        SET
        name = @Name,
        description = @Description,
        isPrivate = @IsPrivate
        WHERE id = @Id;";
      _db.Execute(sql, update);
      return update;
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Vault> GetVaultsByCreatorId(string id)
    {
      string sql = populateCreator + " WHERE creatorId = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { id }, splitOn: "id");
    }
  }
}