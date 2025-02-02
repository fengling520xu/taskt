using System.IO;

namespace taskt.Core.Automation.Commands
{
    public static class EM_CanHandleFileOrFolderPathExtensionMethods
    {
        /// <summary>
        /// check file/folder path is full-path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFullPath(string path)
        {
            return !string.IsNullOrEmpty(Path.GetPathRoot(path));
        }

        /// <summary>
        /// check file path is URL
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsURL(string path)
        {
            return (path.StartsWith("http:") || path.StartsWith("https:"));
        }

        /// <summary>
        /// check string is valid path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsValidPathString(string path)
        {
            var invs = Path.GetInvalidPathChars();
            return (path.IndexOfAny(invs) < 0);
        }

        /// <summary>
        /// check path is same
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool IsSamePath(string path1, string path2, bool ignoreCase = false) 
        {
            // remove last back-slash
            string RemoveLastSlash(string path) 
            {
                if (path.EndsWith("/") || path.EndsWith("\\"))
                {
                    return path.Substring(0, path.Length - 1);
                }
                else
                {
                    return path;
                }
            }

            var p1 = RemoveLastSlash(path1);
            var p2 = RemoveLastSlash(path2);

            return p1.Equals(p2, (ignoreCase) ? System.StringComparison.Ordinal : System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
