using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChromUrlParserAPI.Service.Interface
{
    public interface IParserService
    {
        Task<dynamic> ParseContent(string url);
    }
}
