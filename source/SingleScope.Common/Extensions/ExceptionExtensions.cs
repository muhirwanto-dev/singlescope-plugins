using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SingleScope.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetDeepMessage(this Exception exception, bool writeNewLine = true)
        {
            var sb = new StringBuilder();

            if (exception is TaskCanceledException cte)
            {
                sb.Append(cte.Message);

                return sb.ToString();
            }

            string? line;

            if (exception is HttpRequestException httpException)
            {
                line = httpException.Message;
            }
            else
            {
                line = exception.Message;
            }

            if (writeNewLine)
            {
                sb.AppendLine(line);
            }
            else
            {
                sb.Append(line);
            }

            if (exception.InnerException != null)
            {
                line = exception.InnerException.GetDeepMessage(writeNewLine);

                if (writeNewLine)
                {
                    sb.AppendLine("Inner Exception:");
                    sb.AppendLine(line);
                }
                else
                {
                    sb.Append(" --> ");
                    sb.Append(line);
                }
            }

            return sb.ToString().Trim();
        }
    }
}
