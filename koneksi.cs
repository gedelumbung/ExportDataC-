/*
 * Created by SharpDevelop.
 * User: Gede Lumbung
 * Date: 20/03/2011
 * Time: 13:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using System.Data;

namespace ExportDataToXML
{
	/// <summary>
	/// Description of koneksi.
	/// </summary>
	public class koneksi
	{
		public OleDbConnection dbase;
		string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=rentalCD.mdb";
		public void bukaKoneksi()
		{
			dbase = new OleDbConnection(connectionString);
			dbase.Open();
		}
		public void tutupKoneksi()
		{
			dbase = new OleDbConnection(connectionString);
			dbase.Close();
		}
	}
}
