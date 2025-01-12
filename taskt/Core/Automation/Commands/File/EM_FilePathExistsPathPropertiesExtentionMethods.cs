using System;
using System.IO;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// for IFilePathExistsPathProperties extension methods
    /// </summary>
    public static class EM_FilePathExistsPathPropertiesExtentionMethods
    {
        /// <summary>
        /// expand value or User variable as Wait Time for File
        /// </summary>
        /// <param name="command"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        public static int ExpandValueOrUserVariableAsWaitTimeForFile(this IFilePathExistsPathProperties command, Engine.AutomationEngineInstance engine)
        {
            return command.ToScriptCommand().ExpandValueOrUserVariableAsInteger(nameof(command.v_WaitTimeForFile), "Wait Time For File", engine);
        }

        /// <summary>
        /// Expand Value or User Variable as File Path and Wait Time for File
        /// </summary>
        /// <param name="command"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        public static (string, int) ExpandValueOrUserVariableAsFilePathAndWaitTimeForFile(this IFilePathExistsPathProperties command, Engine.AutomationEngineInstance engine)
        {
            var f = command.ExpandValueOrUserVariableAsFilePath(engine);
            var w = command.ExpandValueOrUserVariableAsWaitTimeForFile(engine);
            return (f, w);
        }

        /// <summary>
        /// Wait For File
        /// </summary>
        /// <param name="path"></param>
        /// <param name="waitTime"></param>
        /// <param name="engine"></param>
        /// <returns>file path</returns>
        /// <exception cref="Exception"></exception>
        public static string WaitForFile(this IFilePathExistsPathProperties command, Engine.AutomationEngineInstance engine)
        {
            (var path, var waitTime) = command.ExpandValueOrUserVariableAsFilePathAndWaitTimeForFile(engine);

            var ret = WaitControls.WaitProcess(waitTime, "File Path", new Func<(bool, object)>(() =>
            {
                if (EM_CanHandleFilePathExtentionMethods.IsURL(path))
                {
                    // if path is URL, don't check existance
                    return (true, path);
                }
                else
                {
                    if (File.Exists(path))
                    {
                        return (true, path);
                    }
                    else
                    {
                        return (false, null);
                    }
                }
            }), engine);

            if (ret is string returnPath)
            {
                return returnPath;
            }
            else
            {
                throw new Exception($"Strange Value returned in WaitForFile. Type: {ret.GetType().FullName}");
            }
        }
    }
}
