using System;
using System.Collections.Generic;
using System.Configuration;
using RestSharp;

namespace KloudlessMvc.Kloudless
{
	public class Util
	{
		public static string BASE_URL = "https://api.kloudless.com";
		public static string VERSION = "v1";
        public static List<String> SERVICES = new List<String> {
			"skydrive", "box", "gdrive", "sharepoint", "onedrivebiz", "dropbox"
		};

		public static string GetPath(String path="")
		{
			return BASE_URL + '/' + VERSION + '/' + path.Trim();
		}

		public static string GetAuthPath(String appId,
			List<String> services = null)
		{
			String url = BASE_URL + "/services/?";
			url += "retrieve_account_key=true&admin=";

			url += "&app_id=" + appId;

			if (services != null && services.Count > 0) {
				url += "&services=" + String.Join (",", services);
			}

			return url;
		}

	    public static string GetOAuthUrl(string appId, string callback, string scope)
	    {
	        return
	            $"https://api.kloudless.com/v1/oauth/?client_id={appId}&response_type=code&redirect_uri={callback}&scope={scope}&state=CSRF_PREVENTION_TOKEN";

	    }

		public static RestClient GetClient()
		{
			var client = new RestClient ();
			client.BaseUrl = new Uri(Util.GetPath());
			return client;
        }

        #region User Input

        // This region does not have to do with API requests and just handles user input.

        /// <summary>
        /// Prompts the user to enter the location of the API server
        /// </summary>
        /// <returns>true if a custom base URL was entered, false if the default was used.</returns>
        public static bool SetBaseUrl()
        {
            //Console.Write("Please enter the URL of the Kloudless API server, " +
            //    "or press Enter to use https://api.kloudless.com: ");
            //String baseUrl = Console.ReadLine().Trim();
            //if (baseUrl.Length > 0)
            //{
            //    Util.BASE_URL = baseUrl;
            //    return true;
            //}
            //return false;
            return true;
        }

        public static string GetAppId()
        {
            return ConfigurationManager.AppSettings["appId"];
        }

        public static string GetService()
        {
            return "gdrive";
        }
        #endregion
    }
}

