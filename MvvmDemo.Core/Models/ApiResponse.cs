using System;
namespace MvvmDemo.Core.Models
{
    public class APIResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public object response { get; set; }
    }
}

