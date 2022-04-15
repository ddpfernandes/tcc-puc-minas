using System;
using System.Linq;
using System.Collections.Generic;

namespace Seedwork.CommandHandler
{
    /// <summary>
    /// Abstract response for response commands.
    /// </summary>
    public class BaseResponse
    {
        public BaseResponse()
        {
            Errors  = new List<string>();
        }

        public List<string> Errors { get; set; }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddError(Exception error)
        {
            Errors.Add($"{error.Message} {error?.InnerException?.Message}");
        }

        public bool HasErrors() => Errors.Any();
    }
}