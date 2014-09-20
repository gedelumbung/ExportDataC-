/*
 * Created by SharpDevelop.
 * User: Gede Lumbung
 * Date: 20/03/2011
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;  //memanggil library database
using System.Data;
using System.Xml;

namespace ExportDataToXML
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public DataTable tabel;
		public MainForm()
		{
			InitializeComponent();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			bacaData bc = new bacaData();
			tabel = bc.bacaDataSemua();
			TampilSemua(tabel);
		}
		public void TampilSemua(DataTable tabel)
		{
			tampil.DataSource = null;
			tampil.Columns.Clear();
			tampil.DataSource = tabel;
			tampil.AllowUserToAddRows = false;
			tampil.ReadOnly = true;
            tampil.Columns[0].HeaderText = "Judul Katalog CD";
            tampil.Columns[0].Width = 150; //nama cd
            tampil.Columns[1].HeaderText = "Tipe CD";
            tampil.Columns[1].Width = 120; //tipe cd
            tampil.Columns[2].HeaderText = "Judul Katalog CD";
            tampil.Columns[2].Width = 150; //nama cd
            tampil.Columns[3].HeaderText = "Tipe CD";
            tampil.Columns[3].Width = 120; //tipe cd
            tampil.Columns[4].HeaderText = "Tipe CD";
            tampil.Columns[4].Width = 120; //tipe cd
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			XmlWriterSettings setting = new XmlWriterSettings();
			setting.Indent = true;
				
			XmlWriter writter =  XmlWriter.Create("D://Data Export.html",setting);
			writter.WriteStartDocument();
			writter.WriteStartElement("table");
			for (int i=0;i<tampil.Rows.Count ;i++ ) {
				writter.WriteStartElement("tr");
				for (int j=0;j<tampil.Columns.Count ;j++ ) {
					//(tampilNilai[0,j].Value.ToString(),tampilNilai[i,j].Value.ToString());
					writter.WriteElementString("td",tampil[j,i].Value.ToString());
				}
				writter.WriteEndElement();
			}
			writter.WriteEndElement();
			writter.WriteEndDocument();
			writter.Flush();
			writter.Close();
			MessageBox.Show("Data berhasil di export ke D://Data Export.html");
		}
	}
}
