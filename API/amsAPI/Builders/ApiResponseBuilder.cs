namespace amsAPI.Helpers
{
    public class ApiResponseBuilder
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public int StatusCode { get; private set; }



        private ApiResponseBuilder() { }

        public class responseBuilder
        {
            private readonly ApiResponseBuilder _response = new ApiResponseBuilder();

            public responseBuilder setSuccess(bool success)
            { 
               _response.Success = success;
                return this;
            }
            public responseBuilder setMessage(string message)
            {
                _response.Message = message;
                return this;
            }
            public responseBuilder setdata(object data)
            { 
                _response.Data = data;
                return this;
            }
            public responseBuilder setStatusCode(int statusCode)
            {
                _response.StatusCode = statusCode;
                return this;
            }

            public ApiResponseBuilder build()
            {
                return _response;
            }
        }
    }
}
