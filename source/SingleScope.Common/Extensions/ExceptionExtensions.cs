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
            string? line;

            if (exception is HttpRequestException httpException)
            {
                line = httpException.Message;

                if (writeNewLine)
                {
                    sb.AppendLine(line);
                }
                else
                {
                    sb.Append(line);
                }
            }
            else if (exception is TaskCanceledException cte)
            {
                sb.Append(cte.Message);

                return sb.ToString();
            }
            else
            {
                if (writeNewLine)
                {
                    sb.AppendLine(exception.Message);
                }
                else
                {
                    sb.Append(exception.Message);
                }
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
