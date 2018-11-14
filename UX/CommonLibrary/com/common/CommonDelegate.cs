using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CommonLibrary.com.univaa.uscan.common.util
{
    public class CommonDelegate<T, E> where T : class where E : class
    {

        //private readonly object resource;
        //private readonly string serviceBaseUrl;
        private const String JsonContentType = "application/json; charset=utf-8";
        private const String EnterpriseID = "";
        //private readonly corewebapi18072016.FacadeUrl _config;
        // private static FacadeUrl fdu = new FacadeUrl();

        // empty Constructor, dnt delete please
        //* - * Pavan - Copy Paste Below item - Pavan * - *
        string URLFORFACADESERVICEHUB = "http://localhost:54552/";
        public CommonDelegate(string FacadeServiceHub = "")
        {

        }


        // Get data by Object
        public E GETData(T ctry, string facadeurl)
        {
            E objdto = null;
            string product;
            HttpClient client = new HttpClient();
            string objdto4 = "";
            List<BsonDocument> temp = null;

            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {


                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(ctry);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);


                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.GetAsync("api/" + facadeurl).Result;
                Console.WriteLine("test", response);
                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("", product);
                    // JObject json = JObject.Parse(product);
                    //objdto = json;
                    // var settings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                    // objdto4 = BsonSerializer.Deserialize<E>(new System.IO.StringReader(product)).ToJson(settings);

                    //BsonDocument temp = BsonDocument.Parse(product);

                    //  temp = BsonSerializer.Deserialize<BsonArray>(product).Select(p => p.AsBsonDocument).ToList();

                    //  var myObj = BsonSerializer.Deserialize<E>(product);
                    //Console.WriteLine("", myObj);
                    // BsonDocument pipeline = BsonSerializer.Deserialize<BsonArray>(product);
                    //  objdto = myObj;

                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<E>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });


                }

                //objdto = BsonSerializer.Deserialize<E>(product, new JsonSerializerSettings
                //    {
                //        TypeNameHandling = TypeNameHandling.Arrays
                //    });
                //}

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }

        // Get data by Object
        public E GETDataWithEnterprseID(T ctry, string facadeurl)
        {
            E objdto = null;
            string product;
            HttpClient client = new HttpClient();
            string objdto4 = "";
            List<BsonDocument> temp = null;

            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {


                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(ctry);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);


                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.GetAsync("api/" + facadeurl).Result;
                Console.WriteLine("test", response);
                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("", product);
                    // JObject json = JObject.Parse(product);
                    //objdto = json;
                    // var settings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                    // objdto4 = BsonSerializer.Deserialize<E>(new System.IO.StringReader(product)).ToJson(settings);

                    //BsonDocument temp = BsonDocument.Parse(product);

                    //  temp = BsonSerializer.Deserialize<BsonArray>(product).Select(p => p.AsBsonDocument).ToList();

                    //  var myObj = BsonSerializer.Deserialize<E>(product);
                    //Console.WriteLine("", myObj);
                    // BsonDocument pipeline = BsonSerializer.Deserialize<BsonArray>(product);
                    //  objdto = myObj;

                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<E>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });


                }

                //objdto = BsonSerializer.Deserialize<E>(product, new JsonSerializerSettings
                //    {
                //        TypeNameHandling = TypeNameHandling.Arrays
                //    });
                //}

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }

        //

        // Get Data by single Id
        public T GetDataById(int id, string facadeurl)
        {
            T objdto = null;
            string product;
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {


                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(id);//IVRMM_Id
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);


                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                // var response = client.PostAsync("api/registrationFacade/", byteContent).Result;

                var response = client.GetAsync("api/" + facadeurl + id).Result;

                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("", product);

                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }


        //
        public T GetDataByIdNo(int id, T dto, string facadeurl)
        {
            T objdto = null;
            string product;
            Array[] dropDownArray = new Array[2];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {
                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(id);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);

                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.GetAsync("api/" + facadeurl).Result;

                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;

                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(product, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                        DateFormatHandling = DateFormatHandling.IsoDateFormat
                    });

                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            // return output;
            return objdto;
        }




        public T DeleteDataById(string id, string facadeurl)
        {
            T objdto = null;
            string product;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            try
            {

                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(id);//document id or primary key
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);


                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var response = client.DeleteAsync("api/" + facadeurl + "?id=" + id).Result;

                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    Console.WriteLine("", product);
                }
            }
            catch
            {

            }


            return objdto;
        }

        //


        public async Task<T> POSTData(T ctry, string facadeurl)
        {
            T objdto = default(T);
            string product;
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {


                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(ctry);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);


                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var response = client.PostAsync("api/" + facadeurl, byteContent).Result;

                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                    Console.WriteLine("", product);


                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }

        public async Task<E> POSTDataWithReturnType(T ctry, string facadeurl)
        {
            E objdto = null;
            string product;
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {


                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(ctry);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);


                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var response = client.PostAsync("api/" + facadeurl, byteContent).Result;

                // HttpResponseMessage response = client.PostAsync("api/PreadmissionFacade/", lo);
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<E>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                    Console.WriteLine("", product);


                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }

        public async Task<T> POSTDataWithString(string str, string facadeurl)
        {
            T objdto = default(T);
            string product;
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {
                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(str);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync("api/" + facadeurl, byteContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    Console.WriteLine("", product);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }

        public async Task<T> POSTDataWithList(List<String> str, string facadeurl)
        {
            T objdto = default(T);
            string product;
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri(this.URLFORFACADESERVICEHUB);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //HTTP POST
            try
            {
                var myContent = Newtonsoft.Json.JsonConvert.SerializeObject(str);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync("api/" + facadeurl, byteContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    product = response.Content.ReadAsStringAsync().Result;
                    objdto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(product, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    Console.WriteLine("", product);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return objdto;
        }

    }
}
