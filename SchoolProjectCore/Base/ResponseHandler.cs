using Microsoft.Extensions.Localization;
using SchoolProjectCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Base
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

     
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.DeletedDone]

            };

        }
        public Response<T> Created<T>(T entity, object meta)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Data = entity,
                Meta = meta,
                Message = _stringLocalizer[SharedResourcesKeys.AddDone]

            };

        }
        public Response<T> Success<T>(T entity, object meta=null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Data = entity,
                Meta = meta,
                Message = _stringLocalizer[SharedResourcesKeys.Success]

            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,

                Message = _stringLocalizer[SharedResourcesKeys.Unauthorized]

            };

        }
        public Response<T> BadRequest<T>( string message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,

                Message = _stringLocalizer[SharedResourcesKeys.BadRequest]

            };

        }
        public Response<T> NotFound<T>(string message=null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,

                Message = message != null ? message :  _stringLocalizer[SharedResourcesKeys.NotFound]


            };

        }
        public Response<T> SuccessMessage<T>(string message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,

                Message = message != null ? message : _stringLocalizer[SharedResourcesKeys.Success]


            };
        }
    }
}
