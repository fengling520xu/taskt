using System;
using System.IO;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// Handle File Name Extension methods
    /// </summary>
    public static class EM_CanHandleFileNameExtensionMethods
    {
        /// <summary>
        /// expand value or User Variable As File name
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameterName"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ExpandValueOrUserVariableAsFileName(this ICanHandleFileName command, string parameterName, Engine.AutomationEngineInstance engine)
        {
            var prop = command.ToScriptCommand().GetProperty(parameterName);
            string parameterValue = prop.GetValue(command)?.ToString() ?? "";

            var fn = parameterValue.ExpandValueOrUserVariable(engine);
            //var invs = Path.GetInvalidFileNameChars();
            //if (fn.IndexOfAny(invs) < 0)
            if (IsValidFileName(fn))
            {
                return fn;
            }
            else
            {
                throw new Exception($"File Name contains invalid chars. File Name: '{fn}'");
            }
        }

        /// <summary>
        /// check valid filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsValidFileName(string fileName)
        {
            var invs = Path.GetInvalidFileNameChars();
            return (fileName.IndexOfAny(invs) < 0);
        }
    }
}
