using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;
using System.Text;
using System.IO;
using System.Net.Mail;

namespace LogicUniversityWebLogic
{
    public partial class Disbursement : System.Web.UI.Page
    {
        DisbursementLogic dl = new DisbursementLogic();
        PendingLogic pl = new PendingLogic();
	TheMail mm = new TheMail();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            deptgridview.DataSource = dl.getDisburseView(DropDownList1.SelectedValue.ToString());
            deptgridview.DataBind();

        }
	
	protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["loginUser"]);
            string department = DropDownList1.SelectedItem.ToString();

            mailservice(mm.getFromEmail(userid), mm.getToEmail(department));

	}

	private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sb.ToString();
        }

	 public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

	public void mailservice(string from,string to)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to); //text = to mail address
            mailMessage.From = new MailAddress(from); //from mail address
            mailMessage.Subject = DateTime.Now.ToShortDateString() + " " + "Disburment Voucher";
            mailMessage.Body = GridViewToHtml(deptgridview);
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg"); //no need to change
            smtpClient.Send(mailMessage);
        }
	
	

    }
}