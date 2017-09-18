using System;
using KloudlessMvc.Kloudless;
using System.Collections.Generic;
using System.Configuration;
using RestSharp;

namespace KloudlessMvc.Kloudless
{
	public class Account
	{
		//internal String id { get; set; }
		//internal String name { get; set; }
		//internal String service { get; set; }
		//internal String key { get; set; }

	    private string _id;
	    private string _code;
	    private string _accessToken;
	    private string _callbackUrl;

		public Account(string code, string callbackUrl)
		{
		    _code = code;
		    _callbackUrl = callbackUrl;
		}

	    public string GetAuthCode(string callbackUrl, string scope)
	    {
	        // This initial code is to obtain input from the user so that
	        // we can determine an app to use and service to authenticate.
	        String appId = Util.GetAppId();

	        //return Redirect(authUrl);
	        string authUrl = Util.GetOAuthUrl(appId, callbackUrl, scope);
	        return authUrl;
	    }

	    public bool ObtainAccessToken()
	    {
            // https://api.kloudless.com/v1/oauth/token
	        var request = new RestRequest();
            request.Method = Method.POST;
	        request.Resource = "oauth/token";

	        request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("code", _code);
	        request.AddQueryParameter("redirect_uri", _callbackUrl);
	        request.AddQueryParameter("client_id", ConfigurationManager.AppSettings["appId"]);
	        request.AddQueryParameter("client_secret", ConfigurationManager.AppSettings["apiKey"]);
            
            var client = Util.GetClient();
	        var response = client.Execute<AccessToken>(request);

	        if (response.ErrorException != null)
	        {
	            const string message = "Error retrieving response.  Check inner details for more info.";
	            var kloudlessException = new ApplicationException(message, response.ErrorException);
	            throw kloudlessException;
	        }
	        var token = response.Data;
	        _accessToken = token.access_token;
	        _id = token.account_id;
	        return true;
	    }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = Util.GetClient();
            request.AddHeader("Authorization", "Bearer " + _accessToken);
            request.AddParameter("accountId", _id, ParameterType.UrlSegment);

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var kloudlessException = new ApplicationException(message, response.ErrorException);
                throw kloudlessException;
            }
            return response.Data;
        }

        /// <summary>
        /// An example API request that retrieves folder contents for an account.
        /// </summary>
        /// <returns>
        /// A list of FileSystem objects representing the folder contents.
        /// </returns>
        /// <param name="folderId">ID of the folder to retrieve contents of</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        public FileSystemList RetrieveContents(
            string folderId = "root", string page = "1", int pageSize = 1000)
        {
            var request = new RestRequest();
            request.Resource = "accounts/{accountId}/storage/folders/{folderId}/contents";

            request.AddParameter("folderId", folderId, ParameterType.UrlSegment);
            request.AddQueryParameter("page", page);
            request.AddQueryParameter("page_size", pageSize.ToString());

            return Execute<FileSystemList>(request);
        }
    }

}

