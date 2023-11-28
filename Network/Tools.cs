namespace Wavestorm.Utilities;

public abstract partial class Utilities
{
    public partial class Network
    {
        /// <summary>
        /// Provides methods for working with network data.
        /// </summary>
        public static class Tools
        {
            /// <summary>
            /// Retrieves a base domain name from a full domain name. 
            /// </summary>
            /// <param name="domainName">Dns Domain name as a string</param>
            /// <returns>Base domain name</returns>
            public static string GetBaseDomain(string domainName)
            {
                var vars = domainName.Split('.');
                if (vars == null || vars.Length != 3)
                {
                    return domainName;
                }

                var dom = new List<string>(vars);
                var remove = vars.Length - 2;
                dom.RemoveRange(0, remove);
                return dom[0] + "." + dom[1];
                ;
            }
        }
    }
}