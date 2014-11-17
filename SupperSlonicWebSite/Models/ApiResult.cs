using Newtonsoft.Json;

namespace SupperSlonicWebSite.Models
{
    [JsonObject("result")]
    public class ApiResult
    {
        public const string StatusOk = "ok";
        public const string StatusError = "error";

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusmessage")]
        public string StatusMessage { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get { return Status == StatusOk; }
        }
    }

    public class SuccessResult : ApiResult
    {
        public SuccessResult() :
            base()
        {
            Status = ApiResult.StatusOk;
        }
    }

    public class FailureApiResult : ApiResult
    {
        public FailureApiResult(string error)
        {
            Status = StatusError;
            StatusMessage = error;
        }
    }

    public class NotificationResult : SuccessResult
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        public NotificationResult(string email)
        {
            this.Email = email;
        }
    }
}