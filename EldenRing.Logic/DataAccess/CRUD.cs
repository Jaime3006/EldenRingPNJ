using EldenRing.Model.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EldenRing.Logic.DataAccess
{
    public  class CRUD
    {

        public static NpgsqlConnection hazConexion() {

            NpgsqlConnection conn = new NpgsqlConnection("User ID=postgres;Password=1234;Server=129.151.227.234;Port=5432;Database=eldenringdatabase;Integrated Security=true;Pooling=true;SearchPath=eldenringdates;");
            conn.Open();
         
            return conn;


        }
        public static List<Classes>Get(NpgsqlConnection conn) {
            List<Classes> list = new List<Classes>();
            NpgsqlTransaction tran = conn.BeginTransaction();
            var sql = new NpgsqlCommand("Select * from classes", conn);
                   NpgsqlDataReader dr = sql.ExecuteReader();
            int fieldCount = dr.FieldCount;
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive=true;
            while (dr.Read())
            {  var stats = JsonSerializer.Deserialize<Stats>(dr.GetString(5),options);
                list.Add(new Classes(dr.GetInt32(0),dr.GetString(1), dr.GetString(2),dr.GetString(3),dr.GetString(4), stats));
            }
            dr.Close();
            tran.Commit();
            conn.Close();
            return list;
        }
        public static List<Weapons> GetWeapons(NpgsqlConnection conn)
        {
            List<Weapons> list = new List<Weapons>();
            NpgsqlTransaction tran = conn.BeginTransaction();
            var sql = new NpgsqlCommand("Select * from weapons", conn);
            NpgsqlDataReader dr = sql.ExecuteReader();
            int fieldCount = dr.FieldCount;
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            while (dr.Read())
            {
                var attack = JsonSerializer.Deserialize<List<Attack>>(dr.GetString(7), options).ToArray();
                var defence = JsonSerializer.Deserialize<List<Defence>>(dr.GetString(8), options).ToArray();
                var RequiredAttributes= JsonSerializer.Deserialize<List<RequiredAttributes>>(dr.GetString(9), options).ToArray();
                var ScalesWith = JsonSerializer.Deserialize<List<ScalesWith>>(dr.GetString(10), options).ToArray();

                list.Add(new Weapons(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4) ,dr.GetString(5), dr.GetString(6), attack, defence, RequiredAttributes, ScalesWith));
            }
            dr.Close();
            tran.Commit();
            conn.Close();
            return list;
        }
        public static List<Shields> GetShields(NpgsqlConnection conn)
        {
            List<Shields> list = new List<Shields>();
            NpgsqlTransaction tran = conn.BeginTransaction();
            var sql = new NpgsqlCommand("Select * from shields", conn);
            NpgsqlDataReader dr = sql.ExecuteReader();
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            while (dr.Read())
            {
                var attack = JsonSerializer.Deserialize<List<Attack>>(dr.GetString(7), options).ToArray();
                var defence = JsonSerializer.Deserialize<List<Defence>>(dr.GetString(8), options).ToArray();
                var RequiredAttributes = JsonSerializer.Deserialize<List<RequiredAttributes>>(dr.GetString(9), options).ToArray();
                var ScalesWith = JsonSerializer.Deserialize<List<ScalesWith>>(dr.GetString(10), options).ToArray();

                list.Add(new Shields(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), attack, defence, RequiredAttributes, ScalesWith));
            }
            dr.Close();
            tran.Commit();
            conn.Close();
            return list;
        }
    }
}
