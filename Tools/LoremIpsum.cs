using NLipsum.Core;
using static EasyToEnter.ASP.Tools.StringConverting;

namespace EasyToEnter.ASP.Tools
{
    public static class LoremIpsum
    {
        private static LipsumGenerator CreateLipsumGenerator() => new(Lipsums.LoremIpsum, false);

        private static int RandomInt(int min, int max) => new Random().Next(min, max);

        public static string GenerateWords(int count) => StringArrayToString(CreateLipsumGenerator().GenerateWords(count), " ");

        public static string GenerateWords(int min, int max) => StringArrayToString(CreateLipsumGenerator().GenerateWords(RandomInt(min, max)), " ");

        public static string GenerateParagraphs(int count) => StringArrayToString(CreateLipsumGenerator().GenerateParagraphs(count), " ");

        public static string GenerateParagraphs(int min, int max) => StringArrayToString(CreateLipsumGenerator().GenerateParagraphs(RandomInt(min, max)), " ");
    }
}