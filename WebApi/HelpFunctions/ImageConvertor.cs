namespace WebApi.HelpFunctions
{
    public static class ImageConvertor
    {
        public static string Run(string image)
        {
            string stringFromSQL = image;
            List<byte> byteList = new List<byte>();

            string hexPart = stringFromSQL.Substring(2);
            for (int i = 0; i < hexPart.Length / 2; i++)
            {
                string hexNumber = hexPart.Substring(i * 2, 2);
                byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
            }
            byte[] original = byteList.ToArray();

            var base64 = Convert.ToBase64String(original);
            return string.Format("data:image/gif;base64,{0}", base64);
        }
    }
}
