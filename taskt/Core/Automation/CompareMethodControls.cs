using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation
{
    public static class CompareMethodControls
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
        /// case sensitive
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
    }
}
