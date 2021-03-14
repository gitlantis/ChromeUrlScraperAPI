using ChromUrlParserAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using JackWFinlay.Jsonize.Parser.AngleSharp;
using JackWFinlay.Jsonize.Serializer.NewtonsoftJson;
using JackWFinlay.Jsonize;

namespace ChromUrlParserAPI.Service
{
    public class ParserService : IParserService
    {
        public async Task<dynamic> ParseContent(string url)
        {
            //WebClient client = new WebClient();
            //var result = client.DownloadString(url);

            //return result;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                string html = await response.Content.ReadAsStringAsync();

                // The use of the parameterless constructors will use default settings.
                //AngleSharpJsonizeParser parser = new AngleSharpJsonizeParser();
                //NewtonsoftJsonJsonizeSerializer serializer = new NewtonsoftJsonJsonizeSerializer();

                Jsonize jsonizer = new Jsonize(html);

                return jsonizer.ParseHtmlAsJson();
            }
        }
    }
}
