using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ShopRenterAPI.Models;
using System.Collections.Generic;

namespace ShopRenterAPI
{
    public interface ICore
	{
		T RunRequest<T>(string resource, string requestMethod, object body = null);
		RequestResult RunRequest(string resource, string requestMethod, object body = null);
    }

	public class Core : ICore
	{
        internal IWebProxy Proxy;

        public bool IsJson(object value)
        {
            if (value != null && value.ToString().Length > 2 && (value.ToString()[0] == '{' || value.ToString()[0] == '['))
                return true;
            else
                return false;
        }

        public bool IsNumber(object value)
        {
            double Number;
            return double.TryParse(value.ToString(), out Number);
        }

        public T ConvertObject<T>(object obj)
        {
            Type t = typeof(T);
            Type u = Nullable.GetUnderlyingType(t);
            if (u == null)
                return (T)Convert.ChangeType(obj, t);
            else
                if (obj == null)
                    return default(T);
            return (T)Convert.ChangeType(obj, u);
        }

        public T RunRequest<T>(string resource, string requestMethod, object body = null)
        {
            Type Type = typeof(T);
            var response = RunRequest(resource, requestMethod, body);
            Log("Response", response.Content);
            var obj = (object)response.Content;
            if (IsJson(obj))
                obj = JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            else
                if (Type != typeof(string))
                    if (Type.IsClass)
                        obj = null;
                    else
                        if (IsNumber(obj))
                            obj = Convert.ToDouble(obj);
                        else
                            if (Nullable.GetUnderlyingType(Type) != null)
                                obj = null;
                            else
                                obj = 0;
            Log("Result", obj == null ? "null" : obj.ToString());
            return ConvertObject<T>(obj);
        }

        protected void Log(string Title, string Message)
        {
            if (Settings.LogFile != null)
                try
                {
                    System.IO.StreamWriter File = new System.IO.StreamWriter(Settings.LogFile, true);
                    File.WriteLine(string.Format("{0} | {1}: {2}", DateTime.Now, Title, Message));
                    File.Close();
                }
                catch
                { }
        }

    /*    private static readonly Encoding encoding = Encoding.UTF8;

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;

                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }*/

        public RequestResult RunRequest(string resource, string requestMethod, object body = null)
        {
			string json = null;
			try
            {
                var requestUrl = Settings.APIURL;

                if (resource.IndexOf("http") == 0)
                    requestUrl = resource;
                else
                {
                    if (!requestUrl.EndsWith("/"))
                        requestUrl += "/";
                    requestUrl += resource;
                }

                Log("requestUrl",requestUrl);

                HttpWebRequest req = WebRequest.Create(requestUrl) as HttpWebRequest;
                req.ContentType = "application/json";

                if (this.Proxy != null)
                    req.Proxy = this.Proxy;

                req.Headers["Authorization"] = GetAuthHeader(Settings.UserName, Settings.Password);
                req.PreAuthenticate = true;

                req.Method = requestMethod; //GET POST PUT DELETE
                req.Accept = "application/json";//, application/xml, text/json, text/x-json, text/javascript, text/xml";

                Log("requestMethod", requestMethod);

                req.ContentLength = 0;
                req.ContentType = "multipart/form-data";//"multiform/post-data";
                req.Expect = string.Empty;
                
                if (body != null)
                {
                    //json = JsonConvert.SerializeObject(body, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                    //object[] data = new object[1] { body };
                    //json = HttpBuildQueryHelper.Format(HttpBuildQueryHelper.Convert(data), string.Empty);*/
                    Log("body", json);

                    byte[] formData = Encoding.UTF8.GetBytes("data%5Bcode%5D=TESZT&data%5Bstatus%5D=1");
                    /*Dictionary<string, object> Data = new Dictionary<string, object>();
                    Data.Add("data[code]","TESZT");
                    Data.Add("data[status]","1");
                    string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
                    string contentType = "multipart/form-data; boundary=" + formDataBoundary;
                    byte[] formData = GetMultipartFormData(Data, formDataBoundary);*/
                    
                    req.ContentLength = formData.Length;

                    var dataStream = req.GetRequestStream();
                    dataStream.Write(formData, 0, formData.Length);
                    dataStream.Close();
                }
                var res = req.GetResponse();
                HttpWebResponse response = res as HttpWebResponse;
                var responseStream = response.GetResponseStream();
                var reader = new StreamReader(responseStream);
                string responseFromServer = reader.ReadToEnd();

                Log("responseFromServer", responseFromServer);
                return new RequestResult()
                {
                    Content = responseFromServer,
                    HttpStatusCode = response.StatusCode
                };
            }
            catch (WebException ex)
            {
				throw new WebException(ex.Message + " " + ex.Response.Headers.ToString() + Environment.NewLine + json, ex);
            }
        }

        protected T GenericGet<T>(string resource)
        {

            return RunRequest<T>(resource, "GET");
        }

        protected bool GenericDelete(string resource)
        {
            var res = RunRequest(resource, "DELETE");
            return res.HttpStatusCode == HttpStatusCode.OK && res.Content == "1";  //|| res.HttpStatusCode == HttpStatusCode.NoContent;
        }

        protected T GenericPost<T>(string resource, object body = null)
        {
            var res = RunRequest<T>(resource, "POST", body);
            return res;
        }

        protected bool GenericBoolPost(string resource, object body = null)
        {
            var res = RunRequest(resource, "POST", body);
            return res.HttpStatusCode == HttpStatusCode.OK;
        }

        protected T GenericPut<T>(string resource, object body = null)
        {
            var res = RunRequest<T>(resource, "PUT", body);
            return res;
        }

        protected bool GenericBoolPut(string resource, object body = null)
        {
            var res = RunRequest(resource, "PUT", body);
            return res.HttpStatusCode == HttpStatusCode.OK;
        }

        protected string GetAuthHeader(string userName, string password)
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", userName, password)));
            return string.Format("Basic {0}", auth);
        }
    }

    public class FileParameter
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public FileParameter(byte[] file) : this(file, null) { }
        public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
        public FileParameter(byte[] file, string filename, string contenttype)
        {
            File = file;
            FileName = filename;
            ContentType = contenttype;
        }
    }
}
