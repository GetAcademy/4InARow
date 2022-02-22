using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _4InARow.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4InARow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private const string ConnStr =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=4InARow;Integrated Security=True";

        [HttpGet("{id}")]
        public async Task<Game> Join(int id)
        {
            // lese fra db
            const string sql = "select * from game where id = @Id";
            var conn = new SqlConnection(ConnStr);
            var games = await conn.QueryAsync<Game>(sql, new {Id = id});
            return games.FirstOrDefault();
        }

        [HttpPost]
        public async Task<Game> Start()
        {
            const string sql = "insert into game (pieces) values ('0000000000000000000000000000000000000000000000000');" +
                               "SELECT @@IDENTITY AS 'Identity';";
            // lage spill + lagre i db + lese tilbake (id fra db)
            var conn= new SqlConnection(ConnStr);
            var id = await conn.ExecuteScalarAsync<int>(sql);
            return new Game {Id = id};
        }

        [HttpPut]
        public async Task<Game> Play(Move move)
        {
            // hente spill fra db 
            const string sql = "select * from game where id = @GameId";
            var conn = new SqlConnection(ConnStr);
            var games = await conn.QueryAsync<Game>(sql, move);
            var game = games.FirstOrDefault();
            
            // gjøre trekk
            game.Move(4);

            // lagre spill i db
            const string updateSql = "update game set pieces = @Pieces where id = @Id";
            var rowsOffected = await conn.ExecuteScalarAsync(updateSql, game);

            return game;
        }
    }
}
