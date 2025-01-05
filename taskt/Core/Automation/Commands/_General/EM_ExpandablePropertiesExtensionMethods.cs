using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace taskt.Core.Automation.Commands._General
{
    /// <summary>
    /// extension methods for ILExpandableProperties
    /// </summary>
    public static class EM_ExpandablePropertiesExtensionMethods
    {
        /// <summary>
        /// convert to ScriptCommand
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ScriptCommand ToScriptCommand(this ILExpandableProperties command)
        {
            // TODO: It will eventually go out of use.
            return (ScriptCommand)command;
        }
    }
}
