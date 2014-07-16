using UnityEngine;
using System;
using System.Data.SQLite;

namespace Spacecat.Framework.SQLite
{
	static public class SQLiteController
	{
		/// <summary>
		/// Get a SQLite Connection with a specified file.
		/// </summary>
		static public SQLiteConnection GetConnectionFromFile(String path)
		{
			SQLiteConnectionStringBuilder adoConnectionStringBuilder;
			{
				adoConnectionStringBuilder = new SQLiteConnectionStringBuilder();
				adoConnectionStringBuilder.Add ("Provider", "Microsoft.ACE.OLEDB.12.0");
				adoConnectionStringBuilder.Add ("Data Source", path);
				adoConnectionStringBuilder.Add ("Extended Properties", "dBASE IV");
			}

			SQLiteConnection adoConnection;
			{
				adoConnection = new SQLiteConnection(adoConnectionStringBuilder.ConnectionString);
			}
			
			return adoConnection;
		}
	}
}