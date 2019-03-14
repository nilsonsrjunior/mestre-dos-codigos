using System;

namespace Exercicio.Nove
{
    public static class ImageExtension
    {
        public static byte[] ToBytes(this string base64) => Convert.FromBase64String(base64);
    }
}
