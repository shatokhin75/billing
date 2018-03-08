namespace Service.Test.Controllers
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Xml.Serialization;

    using Microsoft.Owin.Hosting;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using NUnit.Framework;

    using Service.Web;

    public class BaseApiControllerTest
    {
        protected static readonly string BaseUri = ConfigurationManager.AppSettings["BaseRestAPIUri"];
        private static readonly TestInitializer Initializer = new TestInitializer();

        [TestFixtureSetUp]
        public void SetUp()
        {
            try
            {
                Initializer.SetUp();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Initializer.TearDown();
        }

        protected T TestGetAction<T>(
            string uri,
            string format = "application/json",
            HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            using (var client = new HttpClient())
            {
                T result;

                var request = new HttpRequestMessage(HttpMethod.Get, BaseUri + uri);
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(format));
                var response = client.SendAsync(request).Result;

                var content = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException(content);
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidOperationException(content);
                }

                if (format == "application/json")
                {
                    result = JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    throw new Exception(string.Format("Unexpected format {0}.", format));
                }

                Assert.AreEqual(expectedStatus, response.StatusCode);

                return result;
            }
        }

        protected T TestPostAction<T>(
            string uri,
            string content,
            string format = "application/json")
        {
            using (var client = new HttpClient())
            {

                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    BaseUri + uri);
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(format));
                request.Content = new StringContent(content, Encoding.UTF8, format);

                var response = client.SendAsync(request).Result;

                var responseContent = response.Content.ReadAsStringAsync().Result;
                try
                {
                    this.WriteJson(responseContent);
                }
                catch
                {
                    Console.WriteLine(responseContent);
                }

                T result;
                if (format == "application/json")
                {
                    result = JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                {
                    throw new Exception(string.Format("Unexpected format {0}.", format));
                }

                Assert.IsTrue(response.IsSuccessStatusCode);

                return result;
            }
        }

        public void TestPutAction(
            string uri,
            string content,
            string format = "application/json")
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(
                    HttpMethod.Put,
                    BaseUri + uri);
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(format));
                if (content != null)
                {
                    request.Content = new StringContent(content, Encoding.UTF8, format);
                }

                var response = client.SendAsync(request).Result;

                var responseContent = response.Content.ReadAsStringAsync().Result;
                try
                {
                    this.WriteJson(responseContent);
                }
                catch
                {
                    Console.WriteLine(responseContent);
                }

                Assert.IsTrue(response.IsSuccessStatusCode);
            }
        }

        protected void WriteJson(string content)
        {
            using (var stringReader = new StringReader(content))
            {
                using (var stringWriter = new StringWriter())
                {
                    using (var jsonReader = new JsonTextReader(stringReader))
                    {
                        using (var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented })
                        {
                            jsonWriter.WriteToken(jsonReader);

                            Console.WriteLine(stringWriter.ToString());
                        }
                    }
                }
            }
        }

        private class TestInitializer
        {
            #region Fields

            private int count;

            private IDisposable disposable;

            #endregion

            #region Public Methods and Operators

            public void SetUp()
            {
                lock (this)
                {
                    this.count++;

                    if (this.count > 1)
                    {
                        return;
                    }

                    this.disposable = WebApp.Start<Startup>(BaseUri);
                }
            }

            public void TearDown()
            {
                lock (this)
                {
                    this.count--;

                    if (this.count < 1)
                    {
                        this.disposable.Dispose();
                    }
                }
            }

            #endregion
        }
    }
}
