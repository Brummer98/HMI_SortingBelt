using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data___Layer
{
    public class TagDTOData
    {
        // Properties
        public int ID { get; set; }
        public string TagName { get; set; }
        public int TagValue { get; set; }

        // Constructors
        public TagDTOData(int id, string tagname, int tagValue)
        {
            this.ID = id;
            this.TagName = tagname;
            this.TagValue = tagValue;
        }

        public TagDTOData()
        {

        }
    }
}
