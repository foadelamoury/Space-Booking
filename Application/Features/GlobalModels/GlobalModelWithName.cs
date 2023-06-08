namespace Application.Features.GlobalModels
{
    public abstract class GlobalModelWithName
    {

        public string? Name { get; set; }

        public long Id { get; set; }
        public int SortIndex { get; set; }
        public bool Focus { get; set; }
        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

    }
}
