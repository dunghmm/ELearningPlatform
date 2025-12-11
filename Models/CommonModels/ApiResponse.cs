using Newtonsoft.Json;
using static ELearningPlatform.Models.CommonModels.DefineResponse;

namespace ELearningPlatform.Models.CommonModels
{
    public class ApiResponse
    {
        public int status { get; set; }
        public ResponseItem? response_item { get; set; } = null;
        public object? data { get; set; }

        public ApiResponse()
        {
            status = 200;
            data = null;
        }

        public static ApiResponse Response(object? data = null)
        {
            return new ApiResponse()
            {
                status = 200,
                data = data
            };
        }

        public static ApiResponse Response(EnumCodes responseCode, string? field = null, string? value = null, object? data = null)
        {
            var responseItem = GetResponse(responseCode, field, value);
            var resCode = responseCode.ToString().Split('_')[2];

            return new ApiResponse()
            {
                status = Convert.ToInt32(resCode),
                response_item = responseItem,
                data = data
            };
        }

        public static ResponseItem? GetErrorFromStringCode(string errorCode, string? field = null, string? value = null)
        {
            var errCode = errorCode.ToString().Split('_')[2];
            throw new Exception(JsonConvert.SerializeObject(new DataResponse
            {
                Status = Convert.ToInt32(errCode),
                Code = errorCode.ToString(),
                field = field,
                value = value
            }));
        }

        public static ResponseItem? GetResponse(EnumCodes responseCode, string? field = null, string? value = null)
        {
            var responseItem = ResponseItems.FirstOrDefault(x => x.Code == responseCode.ToString());

            if (responseItem == null) return null;

            var responseItemClone = JsonConvert.SerializeObject(responseItem);
            var responseItemNew = JsonConvert.DeserializeObject<ResponseItem>(responseItemClone);

            if (responseItemNew == null) return null;

            responseItemNew.Message = responseItemNew.Message
                .Replace("{field}", field)
                .Replace("{value}", value);
            return responseItemNew;
        }
    }

    public class ResponseItem
    {
        public required string Code { get; set; }
        public required string Message { get; set; }
    }
}
