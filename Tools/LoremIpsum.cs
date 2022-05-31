using NLipsum.Core;

namespace EasyToEnter.ASP.Tools
{
    public static class LoremIpsum
    {
        private static LipsumGenerator CreateLipsumGenerator() => new(Lipsums.LoremIpsum, false);

        private static int RandomInt(int min, int max) => new Random().Next(min, max);

        private static string StringArrayToString(string[] stringArray) => string.Join(" ", stringArray);

        public static string GenerateWords(int count) => StringArrayToString(CreateLipsumGenerator().GenerateWords(count));

        public static string GenerateWords(int min, int max) => StringArrayToString(CreateLipsumGenerator().GenerateWords(RandomInt(min, max)));

        public static string GenerateParagraphs(int count) => StringArrayToString(CreateLipsumGenerator().GenerateParagraphs(count));

        public static string GenerateParagraphs(int min, int max) => StringArrayToString(CreateLipsumGenerator().GenerateParagraphs(RandomInt(min, max)));
    }
}