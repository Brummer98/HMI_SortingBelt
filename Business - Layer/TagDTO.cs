using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data___Layer;

namespace Business___Layer
{
    public class TagDTO
    {
        // Properties
        public int ID { get; set; }
        public string TagName { get; set; }
        public int TagValue { get; set; }

        // Constructors
        public TagDTO(int id, string tagname, int tagValue)
        {
            this.ID = id;
            this.TagName = tagname;
            this.TagValue = tagValue;
        }

        public TagDTO()
        {

        }
    }
}
