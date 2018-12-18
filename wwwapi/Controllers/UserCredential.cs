using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wwwapi.Controllers
{
	public class UserCredential
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public UserCredential(int userId, string username, string password)
		{
			UserId = userId;
			Username = username;
			Password = password;
		}
	}
}