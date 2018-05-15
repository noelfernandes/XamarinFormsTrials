using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XFHttpClientTrials.Services
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
    }
}
