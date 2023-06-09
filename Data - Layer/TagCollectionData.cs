using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data___Layer
{
    public class TagCollectionData
    {
        
        private string constr = @"Data Source=.\sqlexpress;Initial Catalog=TagTableFactory;Integrated Security=True;";
        
        public List<TagDTOData> GetAllTags()
        {
            // Create a list of all database items and show them
            List<TagDTOData> tagDTODatas = new List<TagDTOData>();

            string query = "SELECT ID, TagName, TagValue FROM Tags";

            using (SqlConnection con = new(constr))
            {
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tagDTODatas.Add(new TagDTOData(
                                Convert.ToInt32(sdr["ID"]),
                                Convert.ToString(sdr["TagName"]),
                                Convert.ToInt32(sdr["TagValue"])
                                // Convert.ToInt32(sdr["TagValue"])
                            ));

                        }
                    }
                    con.Close();
                }
            }

            if (tagDTODatas.Count == 0)
            {
                tagDTODatas.Add(new TagDTOData(0, "", 0));
            }

            return tagDTODatas;
        }

        public List<TagDTOData> GetAllTagsHMISignals()
        {
            // Create a list of all database items and show them
            List<TagDTOData> tagDTODatas = new List<TagDTOData>();

            string query = "SELECT ID, TagName, TagValue FROM Tags WHERE TagName LIKE '%Clinder_State.STS%'";

            using (SqlConnection con = new(constr))
            {
                using (SqlCommand cmd = new(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tagDTODatas.Add(new TagDTOData(
                                Convert.ToInt32(sdr["ID"]),
                                Convert.ToString(sdr["TagName"]),
                                Convert.ToInt32(sdr["TagValue"])
                            // Convert.ToInt32(sdr["TagValue"])
                            ));

                        }
                    }
                    con.Close();
                }
            }

            if (tagDTODatas.Count == 0)
            {
                tagDTODatas.Add(new TagDTOData(0, "", 0));
            }

            return tagDTODatas;
        }

        public List<TagDTOData> getSingleTag(int ID)
        {
            List<TagDTOData> singleTagList = new List<TagDTOData>();
            string query = "SELECT ID, TagName, TagValue FROM Tags WHERE ID = @ID";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    // Execute reader
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            singleTagList.Add(new TagDTOData(
                            Convert.ToInt32(sdr["ID"]),
                            Convert.ToString(sdr["TagName"]),
                            Convert.ToInt32(sdr["TagValue"])
                            ));
                        }
                    }
                }
            }
            return singleTagList;
        }

        public void EditTag(int id, string Tagname, int Tagvalue)
        {
            string query = "UPDATE Tags SET TagName = @TagName, TagValue = @TagValue WHERE ID = @ID";

            using (SqlConnection con = new SqlConnection(constr))
            {
                // Create a sql command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("ID", id));
                    cmd.Parameters.Add(new SqlParameter("TagName", Tagname));
                    cmd.Parameters.Add(new SqlParameter("TagValue", Tagvalue));
                    // Execute reader
                    SqlDataReader sdr = cmd.ExecuteReader();
                }
            }
        }
    }
}
