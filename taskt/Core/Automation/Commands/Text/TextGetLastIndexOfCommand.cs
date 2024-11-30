using System;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Text")]
    [Attributes.ClassAttributes.SubGruop("Action")]
    [Attributes.ClassAttributes.CommandSettings("Get Last Index Of")]
    [Attributes.ClassAttributes.Description("This command allows you to the Last Position of the Specified Text")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to the Last Position of the Specified Text")]
    [Attributes.ClassAttributes.ImplementationDescription("")]
    [Attributes.ClassAttributes.CommandIcon(nameof(Properties.Resources.command_function))]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public class TextGetLastIndexOfCommand : ScriptCommand
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(TextControls), nameof(TextControls.v_Text_MultiLine))]
        public string v_Text { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_DisallowNewLine_OneLineTextBox))]
        [PropertyDescription("Search Text")]
        [InputSpecification("Search Text", true)]
        [PropertyDetailSampleUsage("**Hello**", PropertyDetailSampleUsage.ValueType.Value, "Search Text")]
        [PropertyDetailSampleUsage("**{{{vSearch}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "Search Text")]
        [PropertyValidationRule("Search Text", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "Search Text")]
        public string v_SearchText { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_Result))]
        public string v_Result { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(TextCompareSelectMethodControls), nameof(TextCompareSelectMethodControls.v_CaseSensitiveYes))]
        public string v_CaseSensitive { get; set; }

        public TextGetLastIndexOfCommand()
        {
        }

        public override void RunCommand(Engine.AutomationEngineInstance engine) 
        {
            var targetText = this.ExpandValueOrUserVariable(nameof(v_Text), "Text", engine);

            var searchText = this.ExpandValueOrUserVariable(nameof(v_SearchText), "Search Text", engine);

            if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_CaseSensitive), engine))
            {
                (targetText.LastIndexOf(searchText)).StoreInUserVariable(engine, v_Result);
            }
            else
            {
                targetText.ToLower().LastIndexOf(searchText.ToLower()).StoreInUserVariable(engine, v_Result);
            }
        }
    }
}
