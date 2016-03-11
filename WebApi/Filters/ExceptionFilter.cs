using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Kandoe.Web.Filters {
    public class ExceptionFilter : ExceptionFilterAttribute {
        private HttpStatusCode status;
        private string message;

        public override void OnException(HttpActionExecutedContext context) {
            switch (context.Exception.GetType().Name) {
                case nameof(NotSupportedException):
                    this.status = HttpStatusCode.MethodNotAllowed;
                    this.message = "Our platform does not support this functionality.";
                    break;
                case nameof(SqlException):
                    this.status = HttpStatusCode.Conflict;
                    this.message = "Unable to retrieve data from the database.";
                    break;
                default:
                    this.status = HttpStatusCode.InternalServerError;
                    this.message = "Something went wrong with the server.";
                    this.message = String.Format("{0}\n{1}", this.message, context.Exception.Message);
                    break;
            }

            context.Response = new HttpResponseMessage(this.status){
                Content = new StringContent(this.message)
            };
        }
    }
}