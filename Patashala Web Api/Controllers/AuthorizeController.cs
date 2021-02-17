using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Http;
using Patashala_Web_Api.Models;
using Patashala_Web_Api.DTO;

using Patashala_Web_Api.PatashalaContext;
using Patashala_Web_Api.Filters;
using System.Net;
using Patashala_Web_Api.PatashalaGlobalRepository;

namespace Patashala_Web_Api.Controllers
{
    [RoutePrefix("api/Authorize")]
    public class AuthorizeController : ApiController
    {
        private readonly PatashalaUnitOfWork _db = new PatashalaUnitOfWork();

        private readonly JwtTokenHelper _tokenHelper = new JwtTokenHelper();
        public List<AppDTO> Get()
        {
            return _db.AuthModelRepository.Get()
                    .Select(i => new AppDTO
                    {
                        Name = i.Name,
                        TokenExpiration = i.TokenExpiration
                    }).ToList();
        }


        [Route("SignIn")]
        public IHttpActionResult Post(AuthAppDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var authApp = _db.AuthModelRepository.Get()
                .FirstOrDefault(i => i.AppToken == request.AppToken
                                     && i.AppSecret == request.AppSecret
                                     && DateTime.UtcNow < i.TokenExpiration);

            if (authApp == null) return Unauthorized();

            var token = _tokenHelper.CreateToken(authApp);
            return Ok(token);
        }

        [Route("SignUp")]
        public IHttpActionResult Post(AuthModel request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.AuthModelRepository.Insert(request);

            _db.Save();

            return Ok(HttpStatusCode.Created);
        }


    }
}
