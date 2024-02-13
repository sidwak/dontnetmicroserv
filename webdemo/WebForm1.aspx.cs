using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;

namespace webdemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Define the API URL
                string apiUrl = "http://localhost:33523/api/product"; // Replace with your actual API URL

                // Initialize an empty list to store JSON objects
                List<Dictionary<string, object>> jsonArray = new List<Dictionary<string, object>>();

                // Fetch data from the API
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON data into a list of dictionaries
                        jsonArray = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);
                    }
                    else
                    {
                        // Handle error (e.g., log or display an error message)
                        // You can modify this part based on your application's requirements
                        Response.Write($"Error fetching data. Status code: {response.StatusCode}");
                    }
                }

                String gridOutput = "";
                // Now you can work with the jsonArray as an array of JSON objects
                foreach (var jsonObject in jsonArray)
                {
                    // Access individual properties within each JSON object
                    if (jsonObject.ContainsKey("id"))
                    {
                        int id = Convert.ToInt32(jsonObject["id"]);
                        // You can process the ID or other properties here
                        // For example, add them to a list or display them on the page
                        //Response.Write($"ID: {id}<br />");
                    }
                    gridOutput += 
                        String.Format("\n<div class=\"col\">\r\n" +
                        "          <div class=\"card shadow-sm\" style=\"height: 100%;\">\r\n" +
                        "            <img src=\"\\Images\\iphone.jpg\">\r\n" +
                        "            <div class=\"card-body d-flex flex-column\" >\r\n" +
                        "              <p class=\"card-text\">{0}</p>\r\n" +
                        "              <div class=\"d-flex justify-content-between align-items-center mt-auto\">\r\n" +
                        "                <button type=\"button\" class=\"btn btn-success\">Add to cart</button>\r\n" +
                        "                <h4 class=\"fw-light\">${1}</h4>\r\n" +
                        "              </div>\r\n" +
                        "            </div>\r\n          </div>\r\n" +
                        "        </div>"
                        , jsonObject["name"].ToString()+jsonObject["description"].ToString(), jsonObject["price"].ToString());
                }
                maingrid.InnerHtml = gridOutput;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or display an error message)
                // You can modify this part based on your application's requirements
                Response.Write($"An error occurred: {ex.Message}");
            }
        }
    }
}