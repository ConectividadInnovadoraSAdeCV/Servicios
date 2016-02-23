using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace PJAEstatus
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccessConeccion ac = new AccessConeccion();
            string cmd = "SELECT [ID],[Economico],[Rampa],[EstatusInternet],[EstausGPS] " +
                                ",[E1],[E2],[E3],[E4],[E5],[E6],[E7],[Pasajeros] " +
                         "FROM [gps].[WebStatus] " +
                         "Where ruta='Ruta Piloto'";
            DateTime hoy = DateTime.Today;
            E7.Text = hoy.AddDays(-1).Day.ToString();
            E6.Text = hoy.AddDays(-2).Day.ToString();
            E5.Text = hoy.AddDays(-3).Day.ToString();
            E4.Text = hoy.AddDays(-4).Day.ToString();
            E3.Text = hoy.AddDays(-5).Day.ToString();
            E2.Text = hoy.AddDays(-6).Day.ToString();
            E1.Text = hoy.AddDays(-7).Day.ToString();
            Internet.Text = hoy.Day.ToString();

            //cambio la etiqueta del mes
            string Mes;
            if (hoy.Day > hoy.AddDays(-7).Day)
            {
                Mes = " " + hoy.ToString("MMMM").ToUpper();
            }
            else
            {
                Mes = " " + hoy.AddDays(-7).ToString("MMMM").ToUpper() + "/" + hoy.ToString("MMMM").ToUpper();
            }
            EstLabel.Text += Mes;
            DataTable dt = ac.ObtieneTabla(cmd);
            int i = 1;
            foreach (DataRow dtRow in dt.Rows)
            {
                TableRow r = new TableRow();
                TableCell idCell = new TableCell();
                TableCell EconCell = new TableCell();
                TableCell RampaCell = new TableCell();
                TableCell e1Cell = new TableCell();
                TableCell e2Cell = new TableCell();
                TableCell e3Cell = new TableCell();
                TableCell e4Cell = new TableCell();
                TableCell e5Cell = new TableCell();
                TableCell e6Cell = new TableCell();
                TableCell e7Cell = new TableCell();
                TableCell InternetCell = new TableCell();
                TableCell gpsCell = new TableCell();
                TableCell PasCell = new TableCell();
                //colores de las columnas
                e1Cell.BackColor = System.Drawing.Color.Gainsboro;
                e2Cell.BackColor = System.Drawing.Color.Gainsboro;
                e3Cell.BackColor = System.Drawing.Color.Gainsboro;
                e4Cell.BackColor = System.Drawing.Color.Gainsboro;
                e5Cell.BackColor = System.Drawing.Color.Gainsboro;
                e6Cell.BackColor = System.Drawing.Color.Gainsboro;
                e7Cell.BackColor = System.Drawing.Color.Gainsboro;
                InternetCell.BackColor = System.Drawing.Color.Gainsboro;

                idCell.Text = dtRow["ID"].ToString();
                EconCell.Text = dtRow["Economico"].ToString();
                RampaCell.Text = (bool)dtRow["Rampa"] ? "<img src='Rampa.png' />" : "";
                e1Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E7"] ? "ok.png" : "no.png");
                e2Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E6"] ? "ok.png" : "no.png");
                e3Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E5"] ? "ok.png" : "no.png");
                e4Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E4"] ? "ok.png" : "no.png");
                e5Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E3"] ? "ok.png" : "no.png");
                e6Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E2"] ? "ok.png" : "no.png");
                e7Cell.Text = string.Format("<img src='{0}' />", (bool)dtRow["E1"] ? "ok.png" : "no.png");
                InternetCell.Text = string.Format("<img src='{0}' />", (bool)dtRow["EstatusInternet"] ? "ok.png" : "no.png");
                gpsCell.Text = string.Format("<img src='{0}' />", dtRow["EstausGPS"].ToString() == "1" ? "gps.png" : "nogps.png");
                PasCell.Text = dtRow["Pasajeros"].ToString();

                r.Cells.Add(idCell);
                r.Cells.Add(EconCell);
                r.Cells.Add(RampaCell);
                r.Cells.Add(e1Cell);
                r.Cells.Add(e2Cell);
                r.Cells.Add(e3Cell);
                r.Cells.Add(e4Cell);
                r.Cells.Add(e5Cell);
                r.Cells.Add(e6Cell);
                r.Cells.Add(e7Cell);
                r.Cells.Add(InternetCell);
                r.Cells.Add(gpsCell);
                r.Cells.Add(PasCell);

                Estatus.Rows.Add(r);
                i++;
            }
        }
    }
}