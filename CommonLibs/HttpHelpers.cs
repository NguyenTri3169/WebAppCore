using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommonLibs
{
    public static class HttpHelpers
    {
        public static async Task<string> SendPost(string url, string baseUrl, string jsonData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //POST Method
                    StringContent queryString = new StringContent(jsonData);
                    var response = await client.PostAsync(baseUrl, queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<HttpReturnData> SendPostWithToken(string url, string baserUrl, string token, string jsonData)
        {
            var returnData = new HttpReturnData();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //POST Method

                    StringContent queryString = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(baserUrl, queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        returnData.HttpCode = 200;
                        returnData.HttpContent = await response.Content.ReadAsStringAsync();
                        return returnData;
                    }
                    else
                    {
                        returnData.HttpCode = 401;
                        returnData.HttpContent = "Chưa đăng nhập hoặc không có quyền thực hiện chức năng";
                        return returnData;
                    }


                }

                return returnData;
            }
            catch (Exception ex)
            {

                returnData.HttpCode = -99;
                returnData.HttpContent = ex.Message;
                return returnData;
            }
        }
        public static async Task<string> SendGet(string url, string baseUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method
                    var response = await client.GetAsync(baseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
