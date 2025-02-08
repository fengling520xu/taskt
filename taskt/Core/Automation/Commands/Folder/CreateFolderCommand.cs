using System;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;
using taskt.Core.Automation.Commands.Folder;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Folder Operation")]
    [Attributes.ClassAttributes.CommandSettings("Create Folder")]
    [Attributes.ClassAttributes.Description("This command creates a folder in a specified destination")]
    [Attributes.ClassAttributes.UsesDescription("Use this command to create a folder in a specific location.")]
    [Attributes.ClassAttributes.ImplementationDescription("This command implements '' to achieve automation.")]
    [Attributes.ClassAttributes.CommandIcon(nameof(Properties.Resources.command_files))]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public sealed class CreateFolderCommand : AFolderExistsFolderPathPathResultCommands, ICanHandleFolderName
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_DisallowNewLine_OneLineTextBox))]
        [PropertyDescription("Name of the New Folder")]
        [InputSpecification("Name of the New Folder", true)]
        //[SampleUsage("**myFolderName** or **{{{vFolderName}}}**")]
        [PropertyDetailSampleUsage("**myFolder**", PropertyDetailSampleUsage.ValueType.Value, "Folder Name")]
        [PropertyDetailSampleUsage("**{{{vFolderName}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "Folder Name")]
        [PropertyValidationRule("New Folder Name", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "New Folder Name")]
        [PropertyParameterOrder(4000)]
        public string v_NewFolderName { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        //[PropertyDescription("Location where you want to Create the Folder")]
        //public string v_TargetFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(SelectionItemsControls), nameof(SelectionItemsControls.v_YesNoComboBox))]
        [PropertyDescription("Delete Folder When it already Exists")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(5100)]
        public string v_DeleteExisting { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_WaitTime))]
        //public string v_WaitTimeForFolder { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_Result))]
        //[PropertyDescription("Variable Name to Store Created Folder Path")]
        //[PropertyIsOptional(true)]
        //[PropertyValidationRule("", PropertyValidationRule.ValidationRuleFlags.None)]
        //[PropertyDisplayText(false, "")]
        //public string v_ResultPath { get; set; }

        public CreateFolderCommand()
        {
            //this.CommandName = "CreateFolderCommand";
            //this.SelectionName = "Create Folder";
            //this.CommandEnabled = true;
            //this.CustomRendering = true;
        }

        public override void RunCommand(Engine.AutomationEngineInstance engine)
        {
            ////apply variable logic
            //var destinationDirectory = FolderPathControls.WaitForFolder(this, nameof(v_DestinationDirectory), nameof(v_WaitForFolder), engine);

            //var newFolder = v_NewFolderName.ConvertToUserVariableAsFolderName(engine);

            //var finalPath = System.IO.Path.Combine(destinationDirectory, newFolder);
            //if (System.IO.Directory.Exists(finalPath)) { }
            //{
            //    if (this.GetYesNoSelectionValue(nameof(v_DeleteExisting), engine))
            //    {
            //        System.IO.Directory.Delete(finalPath, true);
            //    }
            //}

            ////create folder if it doesn't exist
            //if (!System.IO.Directory.Exists(finalPath))
            //{
            //    System.IO.Directory.CreateDirectory(finalPath);
            //}

            //FolderPathControls.FolderAction(this, engine,
            //    new Action<string>(path =>
            //    {
            //        var newFolder = v_NewFolderName.ExpandValueOrUserVariableAsFolderName(engine);

            //        var finalPath = System.IO.Path.Combine(path, newFolder);
            //        if (System.IO.Directory.Exists(finalPath)) { }
            //        {
            //            if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_DeleteExisting), engine))
            //            {
            //                System.IO.Directory.Delete(finalPath, true);
            //            }
            //        }

            //        //create folder if it doesn't exist
            //        if (!System.IO.Directory.Exists(finalPath))
            //        {
            //            System.IO.Directory.CreateDirectory(finalPath);
            //        }

            //        if (!string.IsNullOrEmpty(v_ResultPath))
            //        {
            //            finalPath.StoreInUserVariable(engine, v_ResultPath);
            //        }
            //    })
            //);

            this.FolderAction(engine,
                new Func<string, string>(path =>
                {
                    var newFolder = this.ExpandValueOrUserVariableAsFolderName(nameof(v_NewFolderName), engine);

                    // create folder path
                    var createdFolderPath = System.IO.Path.Combine(path, newFolder);
                    if (System.IO.Directory.Exists(createdFolderPath)) { }
                    {
                        if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_DeleteExisting), engine))
                        {
                            System.IO.Directory.Delete(createdFolderPath, true);
                        }
                    }

                    // create folder if it doesn't exist
                    if (!System.IO.Directory.Exists(createdFolderPath))
                    {
                        System.IO.Directory.CreateDirectory(createdFolderPath);
                    }

                    return createdFolderPath;
                })
            );
        }
    }
}
