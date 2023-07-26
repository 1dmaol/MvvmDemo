using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmDemo.Core.Models;

namespace MvvmDemo.Core.Services
{
	public interface IComicService
	{
		Task<List<Comic>> GetComics();
	}
}

