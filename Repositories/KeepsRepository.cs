using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Services
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    private readonly string populateCreator = @"
    SELECT
    keep.*,
    profile.*
    FROM keeps keep
    JOIN profiles profile ON keep.creatorId = profile.id";

    internal IEnumerable<Keep> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<Keep, Profile, Keep>(sql, (Keep, Profile) => { Keep.Creator = Profile; return Keep; }, splitOn: "id");
    }
    internal Keep GetById(int id)
    {
      string sql = populateCreator + " WHERE keep.id = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (Keep, Profile) => { Keep.Creator = Profile; return Keep; }, new { id }, splitOn: "id").FirstOrDefault();
    }


    internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (creatorId, name, description, img)
      VALUES
      (@CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT k.*, vk.id AS VaultKeepId
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      WHERE vaultId = @id";
      return _db.Query<VaultKeepViewModel>(sql, new { id });
    }

    internal IEnumerable<Keep> GetByCreatorId(string profileId)
    {
      // @"
      // SELECT
      // keep.*,
      // profile.*
      // FROM keeps keep
      // JOIN profiles profile ON keep.creatorId = profile.id"

      string sql = populateCreator + " WHERE creatorId = @profileId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { profileId }, splitOn: "id");
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal object Edit(Keep update)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description
      WHERE id = @Id;
      ";
      _db.Execute(sql, update);
      return update;
    }
  }
}