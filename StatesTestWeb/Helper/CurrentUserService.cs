using System.Dynamic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace StatesTestWeb.Helper
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private bool _init;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private int _userId;

        public int UserId
        {
            get
            {
                var stringId = "";
                if (_init) return _userId;
                stringId = _httpContextAccessor.HttpContext?.User?.FindFirst(x => x.Type == "UserId").Value;
                int.TryParse(stringId, out _userId);
                _init = true;

                return _userId;
            }
        }
    }

    public interface ICurrentUserService
    {
        int UserId { get; }
    }
}