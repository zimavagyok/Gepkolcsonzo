using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using GepkolcsonzoModel.Entity;

namespace GepkolcsonzoRepository
{
    public class GepRepository
    {
        public Gep Create(Gep entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateGep";

                command.Parameters.Add(new SqlParameter("@Marka", entity.Marka));
                command.Parameters.Add(new SqlParameter("@Modell", entity.Modell));
                command.Parameters.Add(new SqlParameter("@Teljesitmeny", entity.Teljesitmeny));
                command.Parameters.Add(new SqlParameter("@Suly", entity.Suly));
                command.Parameters.Add(new SqlParameter("@Mennyiseg", entity.Mennyiseg));
                command.Parameters.Add(new SqlParameter("@Ar", entity.Ar));
                command.Parameters.Add(new SqlParameter("@Kep", entity.Kep));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if (result < 1)
                {
                    throw new Exception("Error in GepCreate stored procedure.");
                }

                entity.Id = (int)result;
                return entity;
            }
        }

        public Gep Update(Gep entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GepUpdate";

                command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                command.Parameters.Add(new SqlParameter("@Marka", entity.Marka));
                command.Parameters.Add(new SqlParameter("@Modell", entity.Modell));
                command.Parameters.Add(new SqlParameter("@Teljesitmeny", entity.Teljesitmeny));
                command.Parameters.Add(new SqlParameter("@Suly", entity.Suly));
                command.Parameters.Add(new SqlParameter("@Mennyiseg", entity.Mennyiseg));
                command.Parameters.Add(new SqlParameter("@Ar", entity.Ar));
                command.Parameters.Add(new SqlParameter("@Kep", entity.Kep));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                if (result < 1)
                {
                    throw new Exception("Error in UpdateGep stored procedure.");
                }

                return entity;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GepUpdate";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        private Gep Mapentity(SqlDataReader data)
        {
            Gep result = new Gep();

            result.Id = int.Parse(data["Id"].ToString());
            result.Marka = data["Marka"].ToString();
            result.Modell = data["Modell"].ToString();
            result.Teljesitmeny =int.Parse(data["Teljesitmeny"].ToString());
            result.Suly = float.Parse(data["Suly"].ToString());
            result.Mennyiseg = int.Parse(data["Mennyiseg"].ToString());
            result.Ar = int.Parse(data["Ar"].ToString());
            result.Kep = data["Kep"].ToString();

            return result;
        }

        public int Elerheto(int id)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GepAvailable";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = int.Parse(reader["Mennyiseg"].ToString());
                    }
                }
            }

            return result;
        }
        public Gep GetByID(int id)
        {
            Gep result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GepGetByID";

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

        public List<Gep> GetAll()
        {
            List<Gep> result = new List<Gep>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GepGetAll";

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(Mapentity(reader));
                    }
                }
            }

            return result;
        }

        public Gep GetByName(string name)
        {
            Gep result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GepGetByName";

                command.Parameters.Add(new SqlParameter("@Modell", name));

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
    }
}
