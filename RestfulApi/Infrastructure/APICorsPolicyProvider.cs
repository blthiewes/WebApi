using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Cors;

namespace RestfulApi.Infrastructure
{
    /// <summary>
    /// APICorsPolicyProvider
    /// </summary>
    public class APICorsPolicyProvider : ICorsPolicyProvider
    {
        public Task<CorsPolicy> GetCorsPolicyAsync(IOwinRequest request)
        {
            var policy = new CorsPolicy();
            policy.AllowAnyHeader = true;
            policy.AllowAnyMethod = true;
            policy.Origins.Add("http://localhost:3000");
            return Task.FromResult(policy);
        }
    }
}