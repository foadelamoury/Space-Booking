namespace Domain.Entities;



public class Country : ObjectBase

{

    public string? Name { get; set; }
    //public string? NameE { get; set; }


    public long? ParentId { get; set; }

    public Country Parent { get; set; }


}