using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;

namespace wwwapi.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class ValuesController : ControllerBase
	{
		[Route("api/GetAllUsers/")]
		public string GetAllUsers()
		{
			List<UserCredential> data = new List<UserCredential>();
			try
			{
				string host = "emisim.cltgabhpvgji.eu-west-2.rds.amazonaws.com";
				string port = "5432";
				string username = "emisim";
				string password = "emisim1234";
				string database = "emisim";

				string connstring = String.Format("Server={0};Port={1};" +
					"User Id={2};Password={3};Database={4};",
					host,
					port,
					username,
					password,
					database);

				NpgsqlConnection conn = new NpgsqlConnection(connstring);
				conn.Open();

				DataSet ds = new DataSet();

				string sql = "SELECT * FROM public.\"UserCredential\"";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
				ds.Reset();
				da.Fill(ds);

				foreach (DataRow dataRow in ds.Tables[0].Rows)
					data.Add(new UserCredential(Convert.ToInt32(dataRow[0]), dataRow[1].ToString(), dataRow[2].ToString()));

				conn.Close();
			}
			catch (Exception) { }

			return JsonConvert.SerializeObject(data);
		}

		[Route("api/GetUsers/")]
		public string GetUsers([FromBody] Value buildRequest)
		{
			List<UserCredential> data = new List<UserCredential>();

			try
			{
				// PostgeSQL-style connection string
				string host = "patientim.cyhzxi7igwch.eu-west-2.rds.amazonaws.com";
				string port = "5432";
				string username = "patientim";
				string password = "patientim";
				string database = "patientim";

				string connstring = String.Format("Server={0};Port={1};" +
					"User Id={2};Password={3};Database={4};",
					host,
					port,
					username,
					password,
					database);

				NpgsqlConnection conn = new NpgsqlConnection(connstring);
				conn.Open();

				DataSet ds = new DataSet();

				string sql = "SELECT * FROM public.\"Message\"";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
				ds.Reset();
				da.Fill(ds);

				foreach (DataRow dataRow in ds.Tables[0].Rows)
				{
					data.Add(new UserCredential(Convert.ToInt32(dataRow[0]), dataRow[1].ToString(), dataRow[2].ToString()));
				}

				conn.Close();
			}
			catch (Exception ex)
			{
				throw;
			}

			return JsonConvert.SerializeObject(data);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] Value value)
		{
			//file all of the details.
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}

	public class Value
	{
		public string username { get; set; }
		public string password { get; set; }
	}
}