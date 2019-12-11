using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dreamgames.Classes
{
    public class ApiFetcher
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetApiResponse(string param)
        {
            string url = "https://api.rawg.io/api/games?"+param;
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
