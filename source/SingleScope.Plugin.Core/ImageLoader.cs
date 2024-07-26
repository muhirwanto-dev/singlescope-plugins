using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SingleScope.Plugin.Core
{
    public class ImageLoader<T>
    {
        private readonly Assembly _assembly;

        public ImageLoader() 
        {
            _assembly = typeof(T).GetTypeInfo().Assembly;
        }

        public byte[]? GetByteArrayFromSource(string filename)
        {
            try
            {
                AssemblyName assemblyName = _assembly.GetName();
                string filepath = $"{assemblyName.Name}.Resources.Images.{filename}";

                using (Stream? fs = _assembly.GetManifestResourceStream(filepath))
                {
                    if (fs != null)
                    {
                        return ReadAllBytes(fs);
                    }
                }
            }
            catch
            {
            }

            return null;
        }

        public byte[] ReadAllBytes(Stream stream)
        {
            if (stream is MemoryStream)
            {
                return ((MemoryStream)stream).ToArray();
            }

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
