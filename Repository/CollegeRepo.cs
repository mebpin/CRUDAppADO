using CRUDAppADO.Models;
using Microsoft.Data.SqlClient;

namespace CRUDAppADO.Repository

{
    public class CollegeRepo
    {
        public void AddRecord(College colz)
        {
            string conStr = @"Server= DELL\SQL2019; database= MyDb; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"INSERT INTO colleges2(college_id,college_name,adddress,phone_number) " +
                    $"VALUES({colz.ID},'{colz.Name}','{colz.Address}',{colz.Phone})";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
        //method for getting all records from table
        public IEnumerable<College> GetAllCollegeRecords()
        {
            string conStr = @"Server= DELL\SQL2019; database= MyDb; integrated security=SSPI;TrustServerCertificate=True";
            List<College> colleges = new List<College>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = "SELECT * FROM colleges2";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    College colz = new College();
                    colz.ID = Convert.ToInt32(rdr["college_id"]);
                    colz.Name = Convert.ToString(rdr["college_name"]);
                    colz.Address = Convert.ToString(rdr["adddress"]);
                    colz.Phone = Convert.ToInt64(rdr["phone_number"]);
                    colleges.Add(colz);
                }
            }
            return colleges;
        }
        //to fetch single record detaial given the id value
        public College GetSingleCollegeRecord(int id)
        {
            string conStr = @"Server= DELL\SQL2019; database= MyDb; integrated security=SSPI;TrustServerCertificate=True";
            College colz = new College();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"SELECT * FROM colleges2 WHERE college_id ={id}";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                colz.ID = Convert.ToInt32(rdr["college_id"]);
                colz.Name = Convert.ToString(rdr["college_name"]);
                colz.Address = Convert.ToString(rdr["adddress"]);
                colz.Phone = Convert.ToInt64(rdr["phone_number"]);
            }
            return colz;
        }
        //to update the given record 

        public void EditRecord(College colz)
        {
            string conStr = @"Server= DELL\SQL2019; database= MyDb; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"UPDATE colleges2 SET college_id ={colz.ID}, college_name = '{colz.Name}'" +
                    $",adddress = '{colz.Address}',phone_number = {colz.Phone} WHERE college_id ={colz.ID} ";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
        //delete

        public void DeleteRecord(College colz)
        {
            string conStr = @"Server= DELL\SQL2019; database= MyDb; integrated security=SSPI;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                string myQuery = $"DELETE FROM colleges2 WHERE college_id = {colz.ID} ";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }




    }

}
