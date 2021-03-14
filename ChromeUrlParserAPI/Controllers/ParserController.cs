using ChromeUrlParserAPI.Models;
using ChromUrlParserAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChromeUrlParserAPI.Controllers
{
    public class ParserController : BaseController
    {
        private readonly IParserService _parserService;

        public ParserController(IParserService parserService) {
            _parserService = parserService;
        }

        [HttpPost]
        public async Task<string> Parse([FromBody]UrlModel request)
        {
            var result = await _parserService.ParseContent(request.UrlToParse);
            return result.ToString();
        }
    }
}
