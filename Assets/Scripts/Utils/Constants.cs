using System;
using System.Text;

namespace Outscal.UnityFundamentals.Mat2.Utils
{
    public static class Constants {

        private static StringBuilder levelPrefix = new StringBuilder();

        public static string LevelStatusKey(int level) {
            levelPrefix.Clear();

            levelPrefix.Append("Level");
            levelPrefix.Append("Status");
            levelPrefix.Append(level);

            return levelPrefix.ToString();
        }
    }
}