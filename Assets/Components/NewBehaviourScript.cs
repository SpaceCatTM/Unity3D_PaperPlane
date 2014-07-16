using UnityEngine;
using System.Collections;
using System.Data.SQLite;
using Spacecat.Framework.SQLite;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		SQLiteConnection adoConn = SQLiteController.GetConnectionFromFile("Assets/Resources/ControlDB.sqlite");

		adoConn.Open ();

		using (SQLiteCommand adoCmd = adoConn.CreateCommand())
		{
			adoCmd.CommandText = "select * from AIRPLANE";
			adoCmd.CommandTimeout = 1000;

			using (SQLiteDataReader adoReader = adoCmd.ExecuteReader ())
			{
				while (adoReader.Read() == true)
				{
					Debug.Log (adoReader[0]);
					Debug.Log (adoReader[1]);
					Debug.Log (adoReader[2]);
				}
			}
		}

		if (adoConn == null)
		{
			Debug.Log ("ERROR");
		}
		else
		{
			Debug.Log ("LOADED");
		}

		adoConn.Close ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
