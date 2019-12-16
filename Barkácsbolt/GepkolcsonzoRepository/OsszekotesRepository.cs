using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using GepkolcsonzoModel.Entity;

namespace GepkolcsonzoRepository
{
    public class OsszekotesRepository
    {
        public Osszekotes Create(Osszekotes entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateOsszekotes";

                command.Parameters.Add(new SqlParameter("@UgyfelID", entity.UgyfelID));
                command.Parameters.Add(new SqlParameter("@GepID", entity.GepID));
                command.Parameters.Add(new SqlParameter("@Darab", entity.Darab));
                command.Parameters.Add(new SqlParameter("@Meddig", entity.Meddig));
                command.Parameters.Add(new SqlParameter("@TeljesAr", entity.TeljesAr));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if (result < 1)
                {
                    throw new Exception("Error in CreateOsszekotes stored procedure.");
                }

                entity.ID = (int)result;
                return entity;
            }
        }

        public Osszekotes GetByID(int id)
        {
            Osszekotes result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "OsszekotesByID";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Mapentity(reader);
                    }
                }
            }

            return result;
        }

        private Osszekotes Mapentity(SqlDataReader data)
        {
            Osszekotes result = new Osszekotes();
            result.ID = int.Parse(data["ID"].ToString());
            result.GepID = int.Parse(data["GepID"].ToString());
            result.UgyfelID = int.Parse(data["UgyfelID"].ToString());
            result.Datum = DateTime.Parse(data["Datum"].ToString());
            result.Meddig = DateTime.Parse(data["Meddig"].ToString());
            result.Darab = int.Parse(data["Darab"].ToString());
            result.TeljesAr = int.Parse(data["TeljesAr"].ToString());

            return result;
        }
    }
}
