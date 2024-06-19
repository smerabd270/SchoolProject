using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectCore.Base
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Done"

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
                Message = "Add Done"

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
                Message = "Success"

            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
               
                Message = "Unauthorized"

            };

        }
        public Response<T> BadRequest<T>( string message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,

                Message = message!=null?message: "Bad Request"

            };

        }
        public Response<T> NotFound<T>(string message=null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,

                Message = message != null ? message : "Not Found"

            };

        }
        public Response<T> SuccessMessage<T>(string message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,

                Message = message != null ? message : "Success"

            };
        }
    }
}
