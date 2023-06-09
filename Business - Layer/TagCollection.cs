using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data___Layer;

namespace Business___Layer
{
    public class TagCollection
    {
        TagCollectionData dataInstance = new TagCollectionData();
        public List<TagDTO> GetAllTags()
        {
            List<TagDTO> tagDTOs = new List<TagDTO>();
            List<Data___Layer.TagDTOData> tagDataList = dataInstance.GetAllTags();
            // dataInstance.GetAllTagsHMISignals();

            foreach (var model in tagDataList)
            {
                TagDTO tagBusinessInstance = new TagDTO();
                tagBusinessInstance.ID = model.ID;
                tagBusinessInstance.TagName = model.TagName;
                tagBusinessInstance.TagValue = model.TagValue;
                tagDTOs.Add(tagBusinessInstance);
            }

            return tagDTOs;
        }

        public void EditTag(int id, string Tagname, int Tagvalue)
        {
            dataInstance.EditTag(id, Tagname, Tagvalue);
        }

        public List<TagDTO> getSingleTag(int ID)
        {
            List<Data___Layer.TagDTOData> singleDataTag = new List<Data___Layer.TagDTOData>();

            List<TagDTO> BusinessSingleTagList = new List<TagDTO>();

            singleDataTag = dataInstance.getSingleTag(ID);

            foreach (var model in singleDataTag)
            {
                TagDTO BSingleTag = new TagDTO();
                BSingleTag.ID = model.ID;
                BSingleTag.TagName = model.TagName;
                BSingleTag.TagValue = model.TagValue;

                BusinessSingleTagList.Add(BSingleTag);
            }

            return BusinessSingleTagList;
        }
    }
}
