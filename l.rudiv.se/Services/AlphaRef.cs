using System;

namespace l.rudiv.se.Services
{
    public static class AlphaRef
    {
        /// <summary>
        /// Static character map, a reference will only be produced with the following characters
        /// </summary>
        public const string CharacterMap = "bBCDdFGHjJKLmMnNPQRSTVWXYZ";

        /// <summary>
        /// Converts an integer into an Alphabetic string that can be reversed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static string Convert(int id, int padding = 1)
        {
            int modulus = CharacterMap.Length;
            string reference = "";

            while (id >= modulus)
            {
                int a = (int)Math.Floor((decimal)id % (decimal)modulus);
                reference = CharacterMap.Substring((int)a, 1) + reference;
                id = (int)Math.Floor((decimal)id / (decimal)modulus);
            }

            reference = CharacterMap.Substring((int)Math.Floor((decimal)id % (decimal)modulus), 1) + reference;
            reference = reference.PadLeft(padding, CharacterMap[0]);
            return reference;
        }

        /// <summary>
        /// Accepts a string and reverses any string produced from the <see cref="Convert(int, int)"/> method back into the original integer
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public static int Reverse(string reference)
        {
            char[] charMap = CharacterMap.ToCharArray();
            char[] refCharArray = reference.ToCharArray();
            Array.Reverse(refCharArray);
            reference = new string(refCharArray);

            int multiply = 1;
            int modulus = CharacterMap.Length;
            int id = 0;

            for (var i = 0; i < reference.Length; i++)
            {
                char letter = reference[i];
                int index = Array.IndexOf(charMap, letter);
                id += (index * multiply);
                multiply = multiply * modulus;
            }

            return id;
        }
    }
}