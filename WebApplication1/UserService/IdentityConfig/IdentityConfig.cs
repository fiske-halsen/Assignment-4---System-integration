using IdentityServer4.Models;

namespace UserService.IdentityConfig
{
    public static class IdentityConfig
    {
        #region Identity Config


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("FeedbackService", "FeedbackService Scope"),
                new ApiScope("UserService", "UserService Scope"),
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration)
        {
            var feedbackServiceKey = configuration["FeedbackService:Key"];
            var userServiceKey = configuration["UserService:Key"];


            return new List<Client>
            {


            };


        }

        #endregion
    }
}
