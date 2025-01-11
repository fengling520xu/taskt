using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("File Operation")]
    [Attributes.ClassAttributes.CommandSettings("Get Files Path As List")]
    [Attributes.ClassAttributes.Description("This command returns a list of file paths from a specified location")]
    [Attributes.ClassAttributes.UsesDescription("Use this command to return a list of file paths from a specific location.")]
    [Attributes.ClassAttributes.ImplementationDescription("")]
    [Attributes.ClassAttributes.CommandIcon(nameof(Properties.Resources.command_files))]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public sealed class GetFilesPathAsListCommand : ScriptCommand, ITextCompareProperties, IListResultProperties
    {
        [XmlAttribute]
        //[PropertyDescription("Path to the Source Folder")]
        //[PropertyUIHelper(PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        //[PropertyUIHelper(PropertyUIHelper.UIAdditionalHelperType.ShowFolderSelectionHelper)]
        //[InputSpecification("Enter or Select the path to the folder.")]
        //[SampleUsage("**C:\\temp\\myfolder** or **{{{vTextFolderPath}}}**")]
        //[Remarks("")]
        //[PropertyShowSampleUsageInDescription(true)]
        //[PropertyTextBoxSetting(1, false)]
        //[PropertyValidationRule("Folder", PropertyValidationRule.ValidationRuleFlags.Empty)]
        //[PropertyDisplayText(true, "Folder")]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        public string v_TargetFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_DisallowNewLine_OneLineTextBox))]
        [PropertyDescription("File Name Filter")]
        [InputSpecification("File Name Filter", true)]
        [PropertyDetailSampleUsage("**hello**", PropertyDetailSampleUsage.ValueType.Value, "File Name Filter")]
        [PropertyDetailSampleUsage("**{{{vName}}}**", PropertyDetailSampleUsage.ValueType.VariableName, "File Name Filter")]
        [PropertyIsOptional(true, "Empty and Search All Files")]
        [PropertyValidationRule("", PropertyValidationRule.ValidationRuleFlags.None)]
        [PropertyDisplayText(true, "Name")]
        public string v_SearchFileName { get; set; }

        [XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        //[PropertyDescription("File Name Search Method")]
        //[PropertyUISelectionOption("Contains")]
        //[PropertyUISelectionOption("Starts with")]
        //[PropertyUISelectionOption("Ends with")]
        //[PropertyUISelectionOption("Exact match")]
        //[PropertyIsOptional(true, "Contains")]
        //[PropertyDisplayText(true, "Search Method")]
        [PropertyVirtualProperty(nameof(TextCompareSelectMethodControls), nameof(TextCompareSelectMethodControls.v_CompareMethod))]
        [PropertyDescription("File Name Compare Method")]
        public string v_CompareMethod { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(TextCompareSelectMethodControls), nameof(TextCompareSelectMethodControls.v_CaseSensitive))]
        public string v_CaseSensitive { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(TextCompareSelectMethodControls), nameof(TextCompareSelectMethodControls.v_TrimBeforeCompare))]
        public string v_TrimBeforeCompare { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_DisallowNewLine_OneLineTextBox))]
        [PropertyDescription("Extension")]
        [InputSpecification("Extention", true)]
        [PropertyDetailSampleUsage("**txt**", "Specify text file for Extension")]
        [PropertyDetailSampleUsage("**{{{vExtension}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "Extension")]
        [PropertyIsOptional(true, "Empty and Search All Files")]
        [PropertyValidationRule("", PropertyValidationRule.ValidationRuleFlags.None)]
        [PropertyDisplayText(false, "")]
        public string v_SearchExtension { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(ListControls), nameof(ListControls.v_OutputListName))]
        [PropertyDescription("List Variable Name to Store Result")]
        public string v_Result { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_WaitTime))]
        public string v_WaitTimeForFolder { get; set; }

        public GetFilesPathAsListCommand()
        {
            //this.CommandName = "GetFilesCommand";
            //this.SelectionName = "Get Files";
            //this.CommandEnabled = true;
            //this.CustomRendering = true;
        }

        public override void RunCommand(Engine.AutomationEngineInstance engine)
        {
            //apply variable logic
            var sourceFolder = FolderPathControls.WaitForFolder(this, nameof(v_TargetFolderPath), nameof(v_WaitTimeForFolder), engine);

            //var searchFile = v_SearchFileName.ExpandValueOrUserVariableAsFileName(engine);
            var searchFile = v_SearchFileName.ExpandValueOrUserVariable(engine);

            // get all files
            List<string> fullFilesList;
            fullFilesList = Directory.GetFiles(sourceFolder).ToList();

            //if (!string.IsNullOrEmpty(searchFile))
            //{
            //    var searchMethod = this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_CompareMethod), engine);
            //    switch (searchMethod)
            //    {
            //        case "contains":
            //            filesList = filesList.Where(t => System.IO.Path.GetFileNameWithoutExtension(t).Contains(searchFile)).ToList();
            //            break;
            //        case "starts with":
            //            filesList = filesList.Where(t => System.IO.Path.GetFileNameWithoutExtension(t).StartsWith(searchFile)).ToList();
            //            break;
            //        case "ends with":
            //            filesList = filesList.Where(t => System.IO.Path.GetFileNameWithoutExtension(t).EndsWith(searchFile)).ToList();
            //            break;
            //        case "exact match":
            //            filesList = filesList.Where(t => System.IO.Path.GetFileNameWithoutExtension(t).Equals(searchFile)).ToList();
            //            break;
            //    }
            //}

            var compareFunc = this.GetCompareFunction(engine);
            var comparedFilesList = new List<string>();
            foreach (var f in fullFilesList) 
            { 
                if (compareFunc(Path.GetFileNameWithoutExtension(f), searchFile))
                {
                    comparedFilesList.Add(f);
                }
            }

            var ext = v_SearchExtension.ExpandValueOrUserVariable(engine).ToLower();
            List<string> extFilterdList;
            if (!string.IsNullOrEmpty(ext))
            {
                ext = "." + ext;
                extFilterdList = comparedFilesList.Where(t => Path.GetExtension(t).ToLower() == ext).ToList();
            }
            else
            {
                extFilterdList = comparedFilesList;
            }

            //filesList.StoreInUserVariable(engine, v_UserVariableName);
            //this.StoreListInUserVariable(fullFilesList, nameof(v_Result), engine);
            this.StoreListInUserVariable(extFilterdList, engine);
        }
    }
}