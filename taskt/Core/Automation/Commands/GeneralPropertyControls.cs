using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// general virtual properties
    /// </summary>
    internal static class GeneralPropertyControls
    {
        #region Virtual Property

        #region Basics
        /// <summary>
        /// One line textbox property, new line not allow
        /// </summary>
        [PropertyDescription("Value")]
        [InputSpecification("")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.TextBox)]
        [PropertyShowSampleUsageInDescription(true)]
        [PropertyTextBoxSetting(1, false)]
        [PropertyDisplayText(true, "Value")]
        [PropertyParameterDirection(PropertyParameterDirection.ParameterDirection.Input)]
        [PropertyParameterOrder(5000)]
        public static string v_DisallowNewLine_OneLineTextBox { get; }

        /// <summary>
        /// One line textbox property, new line allow
        /// </summary>
        [PropertyDescription("Value")]
        [InputSpecification("")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.TextBox)]
        [PropertyShowSampleUsageInDescription(true)]
        [PropertyDisplayText(true, "Value")]
        [PropertyParameterDirection(PropertyParameterDirection.ParameterDirection.Input)]
        [PropertyParameterOrder(5000)]
        public static string v_OneLineTextBox { get; }

        /// <summary>
        /// Multi lines textbox property, new line allow
        /// </summary>
        [PropertyDescription("Value")]
        [InputSpecification("")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.MultiLineTextBox)]
        [PropertyShowSampleUsageInDescription(true)]
        [PropertyDisplayText(true, "Value")]
        [PropertyParameterDirection(PropertyParameterDirection.ParameterDirection.Input)]
        [PropertyParameterOrder(5000)]
        public static string v_MultiLinesTextBox { get; }

        /// <summary>
        /// combobox (dropdown)
        /// </summary>
        [PropertyDescription("Value")]
        [InputSpecification("", true)]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyDisplayText(true, "Value")]
        [PropertyParameterDirection(PropertyParameterDirection.ParameterDirection.Input)]
        [PropertyParameterOrder(5000)]
        public static string v_ComboBox { get; }

        #endregion

        /// <summary>
        /// specify variable name to store result property
        /// </summary>
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("Variable Name to Store Result")]
        [InputSpecification("Variable Name")]
        [PropertyDetailSampleUsage("**vResult**", PropertyDetailSampleUsage.ValueType.VariableName)]
        [PropertyDetailSampleUsage("**{{{vResult}}}**", PropertyDetailSampleUsage.ValueType.VariableName)]
        [PropertyShowSampleUsageInDescription(true)]
        [PropertyIsVariablesList(true)]
        [PropertyParameterDirection(PropertyParameterDirection.ParameterDirection.Output)]
        [PropertyValidationRule("Result", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "Result")]
        //[InputSpecification("")]
        //[Remarks("")]
        //[PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        //[PropertyParameterOrder(5000)]
        public static string v_Result { get; }

        #endregion
    }
}
