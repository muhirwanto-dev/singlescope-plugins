using System.Reflection;

namespace SingleScope.Core
{
    public class ImageLoader<T>
    {
        private readonly Assembly _assembly;

        public ImageLoader()
        {
            _assembly = typeof(T).GetTypeInfo().Assembly;
        }

        public byte[]? GetByteArrayFromEmbeddedResource(string filename)
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
