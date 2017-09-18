using System;
using KloudlessMvc.Kloudless;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Drawing;

namespace KloudlessMvc.Kloudless
{
	public class Authentication
	{
		public static Dictionary<String, Account> accounts = 
			new Dictionary<string, Account>();

		///// <summary>
		///// Opens a web browser for authentication and returns the thread it is in.
		///// </summary>
		///// <param name="appId">Kloudless App ID.</param>
		///// <param name="services">List of services to display for auth.</param> 
		//public static WebBrowser open(String appId, List<String> services = null)
		//{
		//	String url = Util.GetAuthPath(appId, services: services);
  //          var wb = new WebBrowser();
  //          wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(FetchKeys);
  //          wb.Navigate(url);

  //          wb.Dock = DockStyle.Fill;
  //          wb.Size = new System.Drawing.Size(800, 600);
  //          wb.ScriptErrorsSuppressed = true;
  //          wb.MinimumSize = new System.Drawing.Size(100, 100);

  //          var form = new Form();
  //          form.Controls.Add(wb);
  //          form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
  //          form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
  //          form.ClientSize = new System.Drawing.Size(800, 600);
  //          form.Text = "Connect an Account";
  //          form.Name = "Kloudless Authentication";
  //          form.Show();

  //          return wb;
		//}

		//private static void FetchKeys(object sender, WebBrowserDocumentCompletedEventArgs e)
		//{
		//	WebBrowser wb = (WebBrowser)sender;
		//	if (e.Url.Host == new Uri (Util.BASE_URL).Host &&
		//	    ((new Regex ("/callback/?$")).IsMatch (wb.Url.AbsolutePath))) {

		//		Account account = new Account ();

		//		HtmlElementCollection dataItems = wb.Document.GetElementsByTagName ("data");
		//		foreach (HtmlElement dataItem in dataItems) {
		//			switch (dataItem.Id) {
		//			case "account":
		//				account.id = dataItem.GetAttribute ("title");
		//				break;
		//			case "account_name":
		//				account.name = dataItem.GetAttribute ("title");
		//				break;
		//			case "service":
		//				account.service = dataItem.GetAttribute ("title");
		//				break;
		//			case "account_key": 
		//				account.key = dataItem.GetAttribute ("title");
		//				break;
		//			}
		//		}

  //              if (account.id != null)
  //              {
  //                  accounts.Add(account.id, account);
  //                  Console.WriteLine("Added " + account.service + " account " +
  //                      account.name + " (" + account.id + ").");
  //              }

		//		wb.Dispose ();
		//		Application.ExitThread ();
		//	}
		//}
	}
}

