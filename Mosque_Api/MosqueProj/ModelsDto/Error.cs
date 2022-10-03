using Newtonsoft.Json;

namespace MosqueProj.Model
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => JsonConvert.ToString(this);

    }
}
