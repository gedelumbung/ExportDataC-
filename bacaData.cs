/*
 * Created by SharpDevelop.
 * User: Gede Lumbung
 * Date: 20/03/2011
 * Time: 13:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace ExportDataToXML
{
	/// <summary>
	/// Description of bacaData.
	/// </summary>
	public class bacaData
	{
		OleDbDataAdapter adapter;
		OleDbCommand komand;
		koneksi classKoneksi;
		DataTable tabel;
		string sql="";
		public DataTable bacaDataSemua()
		{
			classKoneksi = new koneksi();
			sql = "select id_katalog,tipe_katalog,nama_katalog,tahun_terbit,harga_sewa from tbl_katalog left join tbl_tipe_katalog on tbl_katalog.id_tipe_katalog=tbl_tipe_katalog.id_tipe_katalog";
			tabel = new DataTable();
			try {
				classKoneksi.bukaKoneksi();
				komand = new OleDbCommand(sql);
				adapter = new OleDbDataAdapter(sql,classKoneksi.dbase);
				adapter.Fill(tabel);
			} catch (Exception) {
				MessageBox.Show("error");
			}
			return tabel;
		}
	}
}
