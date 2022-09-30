using Microsoft.AspNetCore.Mvc;

namespace API.Helpers
{
    public class HeadersMap
    {
        [FromHeader]
        public string Authorization { get; set; } = "";
    }
}
