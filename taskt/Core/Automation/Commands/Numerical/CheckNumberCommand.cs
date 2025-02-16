using System;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Numerical")]
    [Attributes.ClassAttributes.CommandSettings("Check Number")]
    [Attributes.ClassAttributes.Description("This command allows you to Check Number Value.")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to Check Number Value.")]
    [Attributes.ClassAttributes.ImplementationDescription("")]
    [Attributes.ClassAttributes.CommandIcon(nameof(Properties.Resources.command_function))]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public sealed class CheckNumberCommand : ScriptCommand
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(NumberControls), nameof(NumberControls.v_Value))]
        public string v_TargetValue { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(NumberControls), nameof(NumberControls.v_CheckMethod))]
        public string v_CheckMethod { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(NumberControls), nameof(NumberControls.v_OutputNumericalVariableName))]
        public string v_Result { get; set; }

        public CheckNumberCommand()
        {
        }

        public override void RunCommand(Engine.AutomationEngineInstance engine)
        {
            var method = this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_CheckMethod), engine);

            var vStr = this.ExpandValueOrUserVariable(nameof(v_TargetValue), "Target Value", engine);
            bool res = false;
            switch (method)
            {
                case "is number":
                    res = decimal.TryParse(vStr, out _);
                    break;
                case "is not number":
                    res = !decimal.TryParse(vStr, out _);
                    break;
                default:
                    var v = this.ExpandValueOrUserVariableAsDecimal(nameof(v_TargetValue), engine);
                    var decimalPoint = v % 1;
                    switch (method)
                    {
                        case "is odd number":
                            if (decimalPoint == 0)
                            {
                                res = ((v % 2) == 1);
                            }
                            break;
                        case "is even number":
                            if (decimalPoint == 0)
                            {
                                res = ((v % 2) == 0);
                            }
                            break;
                        case "is zero":
                            res = (v == 0);
                            break;
                        case "is not zero":
                            res = (v != 0);
                            break;
                        case "is positive value":
                            res = (v > 0);
                            break;
                        case "is negative value":
                            res = (v < 0);
                            break;
                        case "is integer":
                            res = (decimalPoint == 0);
                            break;
                        case "is not integer":
                            res = (decimalPoint != 0);
                            break;
                    }
                    break;
            }

            res.StoreInUserVariable(engine, v_Result);
        }
    }
}
