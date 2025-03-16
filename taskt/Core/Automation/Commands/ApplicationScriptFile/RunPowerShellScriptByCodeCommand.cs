using System;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Application/Script")]
    [Attributes.ClassAttributes.SubGruop("Windows Script File")]
    [Attributes.ClassAttributes.CommandSettings("Run PowerShell Script By Code")]
    [Attributes.ClassAttributes.Description("This command allows you to run a PowerShell Script by code.")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to run a PowerShell Script by code.")]
    [Attributes.ClassAttributes.ImplementationDescription("")]
    [Attributes.ClassAttributes.CommandIcon(nameof(Properties.Resources.command_script))]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public sealed class RunPowerShellScriptByCodeCommand : ARunScriptByCodeCommands
    {
        [XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_MultiLinesTextBox))]
        //[PropertyDescription("JavaScript Code")]
        [PropertyDetailSampleUsage("**New-Item -Type File sample.txt**", PropertyDetailSampleUsage.ValueType.Value, "PowerShell Script")]
        [PropertyDetailSampleUsage("**{{{vCode}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "PowerShell Script")]
        //[PropertyParameterOrder(5000)]
        public override string v_ScriptCode { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_DisallowNewLine_OneLineTextBox))]
        //[PropertyDescription("Arguments")]
        //[InputSpecification("Arguments", true)]
        //[PropertyDetailSampleUsage("**1**", PropertyDetailSampleUsage.ValueType.Value, "Arguments")]
        //[PropertyDetailSampleUsage("**Hello**", PropertyDetailSampleUsage.ValueType.Value, "Arguments")]
        //[PropertyDetailSampleUsage("**1 2 3**", PropertyDetailSampleUsage.ValueType.Value, "Arguments")]
        //[PropertyDetailSampleUsage("**{{{vArgs}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "Arguments")]
        //[PropertyIsOptional(true)]
        //[PropertyValidationRule("Arguments", PropertyValidationRule.ValidationRuleFlags.None)]
        //[PropertyDisplayText(false, "")]
        //[PropertyParameterOrder(6000)]
        [Remarks("Arguments are sent to the Script")]
        public override string v_Arguments { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_Result))]
        //[PropertyDescription("Variable Name to Receive the Output")]
        //[PropertyIsOptional(true)]
        //[PropertyValidationRule("Result", PropertyValidationRule.ValidationRuleFlags.None)]
        //[PropertyDisplayText(false, "")]
        //[PropertyParameterOrder(7000)]
        //public string v_Result { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(SelectionItemsControls), nameof(SelectionItemsControls.v_YesNoComboBox))]
        //[PropertyDescription("Delete Script File After Execute")]
        //[PropertyIsOptional(true, "Yes")]
        //[PropertyFirstValue("Yes")]
        //[PropertyValidationRule("Delete Script File", PropertyValidationRule.ValidationRuleFlags.None)]
        //[PropertyDisplayText(false, "")]
        //[PropertyParameterOrder(9000)]
        //public string v_DeleteScriptFile { get; set; }

        public RunPowerShellScriptByCodeCommand()
        {
        }

        public override void RunCommand(Engine.AutomationEngineInstance engine)
        {
            this.RunScriptAction(
                new Func<string>(() => { return "ps1"; }), 
                new RunPowerShellScriptFileCommand()
                {
                    v_Arguments = this.v_Arguments,
                    v_Result = this.v_Result,
                    v_ExecutionMethod = "ExecutionPolicy Bypass",
                },
                engine);
        }
    }
}
