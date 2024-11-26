using System;

namespace taskt.Core.Automation.Commands
{
    public static class EM_TextComparePropertiesExtensionMethods
    {
        /// <summary>
        /// Get Pre Function for Text Compare
        /// </summary>
        /// <param name="command"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static Func<string, string> GetPreFunction(ITextCompareProperties command, Engine.AutomationEngineInstance engine)
        {
            var caseSensitive = ((ScriptCommand)command).ExpandValueOrUserVariableAsYesNo(nameof(command.v_CaseSensitive), engine);
            Func<string, string> caseFunc;
            if (caseSensitive)
            {
                caseFunc = new Func<string, string>(str => str);
            }
            else
            {
                caseFunc = new Func<string, string>(str => str.ToLower());
            }

            var trim = ((ScriptCommand)command).ExpandValueOrUserVariableAsSelectionItem(nameof(command.v_TrimBeforeCompare), engine);
            Func<string, string> preFunc;
            switch (trim)
            {
                case "trim":
                    preFunc = new Func<string, string>(str =>
                    {
                        return caseFunc(str).Trim();
                    });
                    break;
                case "trim start":
                    preFunc = new Func<string, string>(str =>
                    {
                        return caseFunc(str).TrimStart();
                    });
                    break;
                case "trim end":
                    preFunc = new Func<string, string>(str =>
                    {
                        return caseFunc(str).TrimEnd();
                    });
                    break;
                case "no":
                    preFunc = new Func<string, string>(str =>
                    {
                        return caseFunc(str);
                    });
                    break;
                default:
                    throw new Exception($"Strange Trim Method. Value: '{command.v_TrimBeforeCompare}', Expand: '{trim}'");
            }

            return preFunc;
        }

        /// <summary>
        /// create compare function
        /// </summary>
        /// <param name="command"></param>
        /// <param name="engine"></param>
        /// <returns>Func(targetString, conditionString, bool)</returns>
        /// <exception cref="Exception"></exception>
        public static Func<string, string, bool> GetCompareFunction(this ITextCompareProperties command, Engine.AutomationEngineInstance engine)
        {
            var preFunc = GetPreFunction(command, engine);

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
                case "not contains":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return !preFunc(trgStr).Contains(preFunc(condition));
                    });
                    break;
                case "not starts with":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return !preFunc(trgStr).StartsWith(preFunc(condition));
                    });
                    break;
                case "not ends with":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return !preFunc(trgStr).EndsWith(preFunc(condition));
                    });
                    break;
                case "not match":
                    ret = new Func<string, string, bool>((trgStr, condition) =>
                    {
                        return !preFunc(trgStr).Equals(preFunc(condition));
                    });
                    break;
                default:
                    throw new Exception($"Strange Compare Method. Value: '{command.v_CompareMethod}', Expand: '{compareMethod}'");
            }
            return ret;
        }
    }
}
