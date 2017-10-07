using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab03Models.Models;
using System.Data.SqlClient;

namespace Lab03Models.Services
{
    public class SQLConnectionRecommendationData : IRecommendationData , IDisposable
    {
        private SqlConnection _conn;
        public SQLConnectionRecommendationData()
        {
            _conn = new SqlConnection("Data Source=cscidbw.etsu.edu;Integrated Security=False;User ID=csci3110User;Password=Csci3110;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _conn.Open();
        }
        public Recommendation Create(Recommendation recommendation)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _conn.Close();
        }

        public Recommendation Read(int id)
        {
            Recommendation recommendation = null;
            SqlCommand command = new SqlCommand("select * from Recommendation where Id = @id", _conn);
            command.Parameters.Add(new SqlParameter("id", id));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int rating = (int)reader["Rating"];
                string narrative = reader["Narrative"].ToString();
                string recommenderName = reader["RecommenderName"].ToString();
                recommendation = new Recommendation
                {
                    Id = id,
                    Rating = rating,
                    Narrative = narrative,
                    RecommenderName = recommenderName
                };
            }
            return recommendation;
        }

        public ICollection<Recommendation> ReadAll()
        {
            var recommendations = new List<Recommendation>();
            SqlCommand command = new SqlCommand("select * from Recommendation", _conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                int rating = (int)reader["Rating"];
                string narrative = reader["Narrative"].ToString();
                string recommenderName = reader["recommenderName"].ToString();
                var recommendation = new Recommendation
                {
                    Id = id,
                    Rating = rating,
                    Narrative = narrative,
                    RecommenderName = recommenderName
                };
                recommendations.Add(recommendation);
            }
            return recommendations;
        }

        public void Update(int id, Recommendation recommendation)
        {
            throw new NotImplementedException();
        }
    }
}
