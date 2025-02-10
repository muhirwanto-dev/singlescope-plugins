using System.Security.Cryptography;
using System.Text;

namespace SingleScope.Common
{
    public static class Hasher
    {
        /// <summary>
        /// Return an unique <see cref="Guid"/> based on the arguments.
        /// </summary>
        /// <param name="args">Input given to calculate the guid</param>
        /// <returns></returns>
        /// <example>
        ///     args: a, b, c, d -> guid: ABCD
        ///     args: a, e, c, d -> guid: AECD
        ///     
        /// Different arguments passed will generates different guid.
        /// </example>
        public static Guid ComputeGuid(params string[] args)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] enc = Encoding.UTF8.GetBytes(string.Join("", args));
                byte[] hash = md5.ComputeHash(enc);

                return new Guid(hash);
            }
        }

        public static int ComputeHash(params string[] args)
        {
            return ComputeGuid(args).GetHashCode();
        }
    }
}
