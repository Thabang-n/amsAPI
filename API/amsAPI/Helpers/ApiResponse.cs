namespace amsAPI.Helpers
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public int StatusCode { get; private set; }



        private ApiResponse() { }

        public class Builder
        {
            private readonly ApiResponse _response = new ApiResponse();

            public Builder setSuccess(bool success)
            { 
               _response.Success = success;
                return this;
            }
            public Builder setMessage(string message)
            {
                _response.Message = message;
                return this;
            }
            public Builder setdata(object data)
            { 
                _response.Data = data;
                return this;
            }
            public Builder setStatusCode(int statusCode)
            {
                _response.StatusCode = statusCode;
                return this;
            }

            public ApiResponse build()
            {
                return _response;
            }
        }
    }
}
