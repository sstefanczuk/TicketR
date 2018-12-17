using System;
using System.Collections.Generic;
using System.Text;

namespace TicketR.Services.Account.Infrastructure.Helpers
{
    //class JwtHelper
    //{
    //    public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string email, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
    //    {
    //        var response = new
    //        {
    //            id = identity.Claims.Single(c => c.Type == "id").Value,
    //            auth_token = await jwtFactory.GenerateEncodedToken(email, identity),
    //            expires_in = (int)jwtOptions.ValidFor.TotalSeconds
    //        };

    //        return JsonConvert.SerializeObject(response, serializerSettings);
    //    }
    //}
}
