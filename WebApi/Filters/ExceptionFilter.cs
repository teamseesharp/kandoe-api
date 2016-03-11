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
                case nameof(NotImplementedException):
                    this.status = HttpStatusCode.NotImplemented;
                    this.message = "This functionality has not been implemented.";
                    break;
                case nameof(SqlException):
                    this.status = HttpStatusCode.Conflict;
                    this.message = "Unable to retrieve data from the database.";
                    break;
                default:
                    this.status = HttpStatusCode.InternalServerError;
                    this.message = "Something went wrong with the server.";
                    break;
            }

            context.Response = new HttpResponseMessage(this.status){
                Content = new StringContent(this.message)
            };
        }
    }
}