using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    public static class CompareSelectMethodControls
    {
        /// <summary>
        /// compare method
        /// </summary>
        [PropertyDescription("Compare Method")]
        [InputSpecification("", true)]
        [PropertyUISelectionOption("Contains")]
        [PropertyUISelectionOption("Starts with")]
        [PropertyUISelectionOption("Ends with")]
        [PropertyUISelectionOption("Exact match")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyIsOptional(true, "Contains")]
        [PropertyShowSampleUsageInDescription(false)]
        [PropertyDetailSampleUsage("**Contains**", "It's like Comparing whether to Contains **hello**.")]
        [PropertyDetailSampleUsage("**Starts with**", "It's like Comparing whether to Starts With **hello**.")]
        [PropertyDetailSampleUsage("**Ends with**", "It's like Comparing whether to Ends With **hello**.")]
        [PropertyDetailSampleUsage("**Exact match**", "It's like Comparing whether an Exact matche to **hello**.")]
        [PropertyDisplayText(true, "Compare Method")]
        [PropertyParameterOrder(5000)]
        public static string v_CompareMethod { get; }

        /// <summary>
        /// compare method is case sensitive or not
        /// </summary>
        [PropertyDescription("Case Sensitive")]
        [InputSpecification("", true)]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyUISelectionOption("Yes")]
        [PropertyUISelectionOption("No")]
        [PropertyIsOptional(true, "No")]
        [PropertyDetailSampleUsage("**Yes**", "Comparison Method is Case Sensitive")]
        [PropertyDetailSampleUsage("**No**", "Comparison Method is NOT Case Sensitive")]
        [PropertyDisplayText(false, "Case Sensitive")]
        [PropertyParameterOrder(5000)]
        public static string v_CaseSensitive { get; }

        /// <summary>
        /// select method, select one item
        /// </summary>
        [PropertyDescription("Select Method")]
        [InputSpecification("", true)]
        [PropertyUISelectionOption("First")]
        [PropertyUISelectionOption("Last")]
        [PropertyUISelectionOption("Index")]
        [PropertyDetailSampleUsage("**First**", "Specify the First Item")]
        [PropertyDetailSampleUsage("**Last**", "Specify the Last Item")]
        [PropertyDetailSampleUsage("**Index**", "the Item specifed by Index. **0** means First Item")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyIsOptional(true, "First")]
        [PropertyParameterOrder(5000)]
        public static string v_SelectMethod { get; }

        /// <summary>
        /// select item index
        /// </summary>
        [PropertyDescription("Selection Item Index")]
        [InputSpecification("Selection Item Index", true)]
        [Remarks("")]
        [PropertyDetailSampleUsage("**0**", "Specify the First Item")]
        [PropertyDetailSampleUsage("**{{{vIndex}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "Item Index")]
        [PropertyShowSampleUsageInDescription(true)]
        [PropertyTextBoxSetting(1, false)]
        [PropertyIsOptional(true, "0")]
        [PropertyFirstValue("0")]
        [PropertyParameterOrder(5000)]
        public static string v_SelectItemIndex { get; }
    }
}
