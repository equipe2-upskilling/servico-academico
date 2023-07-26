using Academic.Web.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academic.Domain
{


    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyContext context = new MyContext();
        private const string TABLE_NAME = "teachers";
        public TeacherRepository()
        {
        }

        public void CreateTableIfNotExists()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                var sql = $"CREATE TABLE if not exists {TABLE_NAME}" +
                     $"(" +
                     $"id serial PRIMARY KEY, " +
                     $"name VARCHAR (200) NOT NULL, " +
                     $")";

                connection.Execute(sql);
            }
        }


        public List<TeacherDto> GetAll()
        {
            string commandText = $"SELECT * FROM {TABLE_NAME}";



            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var teachers = connection.Query<TeacherDto>(commandText).ToList();
                connection.Close();
                return teachers;
            }


        }

        public TeacherDto Get(int id)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE ID = @id";

            var queryArgs = new { Id = id };
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                var teacher = connection.QueryFirst<TeacherDto>(commandText, queryArgs);
                return teacher;
            }
        }

        public void Add(TeacherDto dto)
        {
            string commandText = $"INSERT INTO {TABLE_NAME} (id, name) VALUES (@id, @name)";

            var queryArguments = new
            {
                id = dto.Id,
                name = dto.Name,

            };
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Execute(commandText, queryArguments);
            }
        }

        public void Delete(int id)
        {
            string commandText = $"DELETE FROM {TABLE_NAME} WHERE ID=(@Id)";

            var queryArguments = new
            {
                Id = id
            };
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Execute(commandText, queryArguments);
            }
        }

        public void Update(TeacherDto dto, int id)
        {
            var commandText = $@"UPDATE {TABLE_NAME}
                        SET Name = @name
                        WHERE id = @id";

            var queryArgs = new
            {
                id = dto.Id,
                name = dto.Name,

            };
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Execute(commandText, queryArgs);
            }
        }

    
    }
}
