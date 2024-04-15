namespace Presentation.HelpFunctions
{
    public static class ImageFormat
    {
        public static string Run(string imageString)
        {
            var byteList = new List<byte>();

            var hexPart = imageString[2..];
            for (int i = 0; i < hexPart.Length / 2; i++)
            {
                var hexNumber = hexPart.Substring(i * 2, 2);
                byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
            }
            var original = byteList.ToArray();

            var base64 = Convert.ToBase64String(original);
            return $"data:image/gif;base64,{base64}";
        }
    }
}
