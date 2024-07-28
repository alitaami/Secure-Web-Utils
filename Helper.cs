using Microsoft.VisualBasic;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace SecureWebUtils
{
    public static class Helper
    {
        // Extension method to sanitize and validate URLs
        public static string SanitizeUrl(this string inputUrl)
        {
            if (Uri.TryCreate(inputUrl, UriKind.Absolute, out Uri result))
            {
                if (IsTrustedDomain(result.Host) && !ContainsDangerousPatterns(result.AbsoluteUri))
                {
                    return result.AbsoluteUri;
                }
                else
                {
                    throw new ArgumentException("URL is not from a trusted domain or contains dangerous patterns.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid URL");
            }
        }

        // Extension method to escape output to prevent XSS
        public static string EscapeOutput(this string input)
        {
            if (ContainsDangerousPatterns(input))
            {
                throw new ArgumentException("Input contains dangerous patterns.");
            }
            return WebUtility.HtmlEncode(input);
        }

        // Extension method to URL encode a string
        public static string EscapeOutput2(this string input)
        {
            if (ContainsDangerousPatterns(input))
            {
                throw new ArgumentException("Input contains dangerous patterns.");
            }
            return WebUtility.UrlEncode(input);
        }

        // Check if the URL is from a trusted domain
        private static bool IsTrustedDomain(string host)
        {
            foreach (var domain in Consts.TrustedDomains)
            {
                if (host.EndsWith(domain, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // Check if the input contains dangerous patterns
        private static bool ContainsDangerousPatterns(string input)
        {
            foreach (var pattern in Consts.DangerousPatterns)
            {
                if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
