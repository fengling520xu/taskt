using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    public static class TextCompareSelectMethodControls
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
        [PropertyUISelectionOption("Not Contains")]
        [PropertyUISelectionOption("Not Starts with")]
        [PropertyUISelectionOption("Not Ends with")]
        [PropertyUISelectionOption("Not Match")]
        [PropertyUISelectionOption("Wildcard")]
        [PropertyUISelectionOption("Not Wildcard")]
        [PropertyUISelectionOption("Not Empty")]
        [PropertyUISelectionOption("Is a Number")]
        [PropertyUISelectionOption("Is a Boolean")]
        [PropertyUISelectionOption("Is a Boolean Loose")]
        [PropertyUISelectionOption("Is Empty")]
        [PropertyUISelectionOption("Is Not a Number")]
        [PropertyUISelectionOption("Is Not a Boolean")]
        [PropertyUISelectionOption("Is Not a Boolean Loose")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyIsOptional(true, "Contains")]
        [PropertyShowSampleUsageInDescription(false)]
        [PropertyDetailSampleUsage("**Contains**", "It's like Comparing whether to Contains **hello**.")]
        [PropertyDetailSampleUsage("**Starts with**", "It's like Comparing whether to Starts With **hello**.")]
        [PropertyDetailSampleUsage("**Ends with**", "It's like Comparing whether to Ends With **hello**.")]
        [PropertyDetailSampleUsage("**Exact match**", "It's like Comparing whether an Exact match to **hello**.")]
        [PropertyDetailSampleUsage("**Not Contains**", "It's like Comparing whether to Not Contains **hello**.")]
        [PropertyDetailSampleUsage("**Not Starts with**", "It's like Comparing whether to Not Starts With **hello**.")]
        [PropertyDetailSampleUsage("**Not Ends with**", "It's like Comparing whether to Not Ends With **hello**.")]
        [PropertyDetailSampleUsage("**Not Match**", "It's like Comparing whether an Not Matche to **hello**.")]
        [PropertyDetailSampleUsage("**Not Empty**", "This determines not empty text.")]
        [PropertyDetailSampleUsage("**Wildcard**", "Check for Wildcard match.")]
        [PropertyDetailSampleUsage("**Not Wildcard**", "Check for Wildcard Not match.")]
        [PropertyDetailSampleUsage("**Is a Number**", "This determines whether a number.")]
        [PropertyDetailSampleUsage("**Is a Boolean**", "This determines whether a boolean, such as **True** or **False**.")]
        [PropertyDetailSampleUsage("**Is a Boolean Loose**", "This determines whether it is a loose boolean, such as **True**, **False**, **Yes**, **No**, **1**, or **0**.")]
        [PropertyDetailSampleUsage("**Is Empty**", "This determines empty text.")]
        [PropertyDetailSampleUsage("**Is Not a Number**", "This determines whether it is **Not** a number.")]
        [PropertyDetailSampleUsage("**Is Not a Boolean**", "This determines whether it is **Not** a boolean, such as **True** or **False**.")]
        [PropertyDetailSampleUsage("**Is Not a Boolean Loose**", "This determines whether it is **Not** a loose boolean, such as **True**, **False**, **Yes**, **No**, **1**, or **0**.")]
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
        /// compare method is case sensitive or not
        /// </summary>
        [PropertyDescription("Case Sensitive")]
        [InputSpecification("", true)]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyUISelectionOption("Yes")]
        [PropertyUISelectionOption("No")]
        [PropertyIsOptional(true, "Yes")]
        [PropertyDetailSampleUsage("**Yes**", "Comparison Method is Case Sensitive")]
        [PropertyDetailSampleUsage("**No**", "Comparison Method is NOT Case Sensitive")]
        [PropertyDisplayText(false, "Case Sensitive")]
        [PropertyParameterOrder(5000)]
        public static string v_CaseSensitiveYes { get; }

        /// <summary>
        /// trim before compare
        /// </summary>
        [PropertyDescription("Trim Before Compare")]
        [InputSpecification("", true)]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyUISelectionOption("Trim")]
        [PropertyUISelectionOption("Trim Start")]
        [PropertyUISelectionOption("Trim End")]
        [PropertyUISelectionOption("No")]
        [PropertyIsOptional(true, "No")]
        [PropertyDetailSampleUsage("**Trim**", "Remove White Space at the Start and End of Text")]
        [PropertyDetailSampleUsage("**Trim Start**", "Remove White Space at the Start of Text")]
        [PropertyDetailSampleUsage("**Trim End**", "Remove White Space at the End of Text")]
        [PropertyDetailSampleUsage("**No**", "Not Trim")]
        [PropertyDisplayText(false, "Case Sensitive")]
        [PropertyParameterOrder(5000)]
        public static string v_TrimBeforeCompare { get; }

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
