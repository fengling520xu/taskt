using System;

namespace taskt.Core.Automation.Commands
{
    public class EM_ComparePropertiesExtensionMethods
    {
        /// <summary>
        /// create compare function
        /// </summary>
        /// <param name="command"></param>
        /// <param name="engine"></param>
        /// <returns>Func(targetString, conditionString, bool)</returns>
        /// <exception cref="Exception"></exception>
        public static Func<string, string, bool> GetCompareFunction(ICompareProperties command, Engine.AutomationEngineInstance engine)
        {
            var caseSensitive = ((ScriptCommand)command).ExpandValueOrUserVariableAsYesNo(nameof(command.v_CaseSensitive), engine);

            Func<string, string> preFunc;
            if (caseSensitive)
            {
                preFunc = new Func<string, string>(str => str);
            }
            else
            {
                preFunc = new Func<string, string>(str => str.ToLower());
            }

            Func<string, string, bool> ret;
            var compareMethod = ((ScriptCommand)command).ExpandValueOrUserVariableAsSelectionItem(nameof(command.v_CompareMethod), engine);
            switch (compareMethod)
            {
                case "contains":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return preFunc(trgStr).Contains(preFunc(condition));
                    });
                    break;
                case "starts with":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return preFunc(trgStr).StartsWith(preFunc(condition));
                    });
                    break;
                case "ends with":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return preFunc(trgStr).EndsWith(preFunc(condition));
                    });
                    break;
                case "exact math":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return preFunc(trgStr).Equals(preFunc(condition));
                    });
                    break;
                default:
                    throw new Exception($"Strange Compare Method. Value: '{command.v_CompareMethod}', Expand: '{compareMethod}'");
            }
            return ret;
        }
    }
}
