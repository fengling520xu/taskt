using System;
using System.IO;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// Handle FilePath Extension methods
    /// </summary>
    public static class EM_CanHandleFilePathExtensionMethods
    {
        /// <summary>
        /// expand value or User Variable As File name
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameterName"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ExpandValueOrUserVariableAsFilePath(this ICanHandleFilePath command, string parameterName, Engine.AutomationEngineInstance engine)
        {
            var prop = command.ToScriptCommand().GetProperty(parameterName);
            string parameterValue = prop.GetValue(command)?.ToString() ?? "";

            var fn = parameterValue.ExpandValueOrUserVariable(engine);
            var invs = Path.GetInvalidFileNameChars();
            if (fn.IndexOfAny(invs) < 0)
            {
                return fn;
            }
            else
            {
                throw new Exception($"File Name contains invalid chars. File Name: '{fn}'");
            }
        }
    }
}
