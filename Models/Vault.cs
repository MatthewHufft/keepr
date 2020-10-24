namespace Keepr.Models
{
  public class Vault
  {
    int Id { get; set; }
    string CreatorId { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    bool isPrivate { get; set; }
    Profile Creator { get; set; }
  }
}