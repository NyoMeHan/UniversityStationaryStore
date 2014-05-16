using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Web.UI.HtmlControls;
using System.IO;


namespace MobilePresentationLogic
{
    public partial class ItemRetrieved : System.Web.UI.Page
    {
        ItemRetrieve ir = new ItemRetrieve();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = ir.viewRequests();
            GridView1.DataBind();

//            HtmlForm form = new HtmlForm();
//            form.Controls.Add(GridView1);
//            StringWriter sw = new StringWriter();
//            HtmlTextWriter hTextWriter = new HtmlTextWriter(sw);
//            form.Controls[0].RenderControl(hTextWriter);
//            string html = sw.ToString();
//            Document Doc = new Document();
//            PdfWriter.GetInstance
//(Doc, new FileStream(Environment.GetFolderPath
//(Environment.SpecialFolder.Desktop)
//+ "\\AmitJain.pdf", FileMode.Create));
//            Doc.Open();
//            Chunk c = new Chunk
//            ("Export GridView to PDF Using iTextSharp \n",
//            FontFactory.GetFont("Verdana", 15));
//            Paragraph p = new Paragraph();
//            p.Alignment = Element.ALIGN_CENTER;
//            p.Add(c);
//            Chunk chunk1 = new Chunk
//            ("By Amit Jain, amit_jain_online@yahoo.com \n",
//            FontFactory.GetFont("Verdana", 8));
//            Paragraph p1 = new Paragraph();
//            p1.Alignment = Element.ALIGN_RIGHT;
//            p1.Add(chunk1);
//            Doc.Add(p);
//            Doc.Add(p1);
//            Doc.Close();
//            string Path = Environment.GetFolderPath
//            (Environment.SpecialFolder.Desktop)
//            + "\\AmitJain.pdf";
//            ShowPdf(Path);
        }
        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader
            ("Content-Disposition", "attachment; filename=" + strS);
            Response.TransmitFile(strS);
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();

        }
    }
}