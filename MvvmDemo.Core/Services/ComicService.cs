using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmDemo.Core.Helpers;
using MvvmDemo.Core.Models;
using Newtonsoft.Json;

namespace MvvmDemo.Core.Services
{
	public class ComicService : IComicService
	{
        public const string TAG = "ComicService ";

        public async Task<List<Comic>> GetComics()
        {
            try
            {
                HttpHelper httpHelper = new HttpHelper();
                var res = await httpHelper.callAPI("/v1/public/comics");
                if (res.result)
                {
                    return (List<Comic>) res.response;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

