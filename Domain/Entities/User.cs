namespace Domain.Entities;


public class User : ObjectBase
{
    public string Name { get; set; }
 
    public int? Age { get; set; }

    public string Email { get; set; }
    public long StreetId { get; set; }

    public Country Country;




    //public string? PhotoName { get; set; }


}