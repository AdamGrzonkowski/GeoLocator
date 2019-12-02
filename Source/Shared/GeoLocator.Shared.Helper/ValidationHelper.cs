using System;
using System.Linq;
using System.Net;

namespace GeoLocator.Shared.Helper
{
    public static class ValidationHelper
    {
        public static bool ValidateIp(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            return ValidateIpV4(ipString) || ValidateIpV6(ipString);
        }

        private static bool ValidateIpV4(string ipString)
        {
            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return splitValues.All(x => byte.TryParse(x, out byte tempForParsing));
        }

        private static bool ValidateIpV6(string ipString)
        {
            if (IPAddress.TryParse(ipString, out IPAddress address))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ValidateUrl(string uriName)
        {
            return Uri.TryCreate(uriName, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp
                    || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
