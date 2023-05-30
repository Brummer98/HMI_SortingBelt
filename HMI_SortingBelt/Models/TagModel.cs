namespace HMI_SortingBelt.Models
{
    public class TagModel
    {
        // Properties
        public int ID { get; set; }
        public string TagName { get; set; }
        public int TagValue { get; set; }

        // Constructors
        public TagModel(int id, string tagname, int tagValue)
        {
            this.ID = id;
            this.TagName = tagname;
            this.TagValue = tagValue;
        }

        public TagModel() 
        { 
        
        }
    }
}
