using System;
using System.IO;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;
using taskt.Core.Script;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// for Copy/Move file commands
    /// </summary>
    public abstract class AFileCopyMoveFileCommands : AFileExistsFilePathBeforeAfterResultCommands, ICanHandleFolderPath
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        [PropertyDescription("Destination Folder")]
        [PropertyDisplayText(true, "Destination Folder")]
        [PropertyParameterOrder(6000)]
        public virtual string v_DestinationFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("Create Folder When Destination Folder does not Exist")]
        [PropertyUISelectionOption("Yes")]
        [PropertyUISelectionOption("No")]
        [Remarks("Specify whether the directory should be created if it does not already exist.")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(6100)]
        public virtual string v_CreateDirectory { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("When Description File Path is Same as Target File Path")]
        [PropertyUISelectionOption("Rise An Error")]
        [PropertyUISelectionOption("Ignore")]
        [PropertyShowSampleUsageInDescription(false)]
        [PropertyDetailSampleUsage("**Rise An Error", "Rise an Error")]
        [PropertyDetailSampleUsage("**Ignore", "Do Nothing and move to Next Process")]
        [PropertyIsOptional(true, "Rise An Error")]
        [PropertyValidationRule("When Path Is Same", PropertyValidationRule.ValidationRuleFlags.None)]
        [PropertyDisplayText(false, "")]
        [PropertyParameterOrder(6200)]
        public virtual string v_WhenDestinationIsSame { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("Delete File if it already Exists")]
        [PropertyUISelectionOption("Yes")]
        [PropertyUISelectionOption("No")]
        [Remarks("Specify whether the file should be deleted first if it is already found to exist.")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(6300)]
        public virtual string v_DeleteExisting { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_WaitTime))]
        [PropertyDescription("Wait Time For Destination Folder")]
        [PropertyParameterOrder(30000)]
        public virtual string v_WaitTimeForFolder { get; set; }

        /// <summary>
        /// create action func for copy/move file
        /// </summary>
        /// <param name="processFunc">(source, destination)</param>
        /// <param name="engine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Func<string, string> CreateActionFunc(Action<string, string> processFunc, Engine.AutomationEngineInstance engine)
        {
            return new Func<string, string>(path =>
            {
                //var destinationFolder = v_DestinationFolderPath.ExpandValueOrUserVariableAsFolderPath(engine);

                //if (!Directory.Exists(destinationFolder))
                //{
                //    if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_CreateDirectory), engine))
                //    {
                //        Directory.CreateDirectory(destinationFolder);
                //    }
                //    else
                //    {
                //        throw new Exception("destination folder does not exists: " + destinationFolder);
                //    }
                //}

                // TODO: fix to call extension methods
                var destinationFolder = EM_CanHandleFolderPathExtensionMethods.ExpandValueOrUserVariableAsFolderPath(this, nameof(v_DestinationFolderPath), engine);
                using (var folderResult = new InnerScriptVariable(engine))
                {
                    var checkFolder = new CheckFolderExistsCommand()
                    {
                        v_TargetFolderPath = this.v_DestinationFolderPath,
                        v_WaitTimeForFolder = this.v_WaitTimeForFolder,
                        v_Result = folderResult.VariableName,
                    };
                    checkFolder.RunCommand(engine);

                    if (!bool.Parse(folderResult.VariableValue.ToString()))
                    {                        
                        if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_CreateDirectory), engine))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }
                        else
                        {
                            throw new Exception($"Destination Folder does not Exists. Folder Path: '{v_DestinationFolderPath}', Expand Folder Path: '{destinationFolder}'");
                        }
                    }
                }

                //get source file name and info
                var sourceFileInfo = new FileInfo(path);

                //create destination
                var destinationFilePath = Path.Combine(destinationFolder, sourceFileInfo.Name);

                // check folder is same
                //if (path.Equals(destinationFilePath, StringComparison.OrdinalIgnoreCase))
                if (EM_CanHandleFileOrFolderPathExtensionMethods.IsSamePath(path, destinationFilePath))
                {
                    switch(this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_WhenDestinationIsSame), engine))
                    {
                        case "rise an error":
                            throw new Exception($"Target File Path and Destination Path are Same. Path: '{path}'");

                        default:
                            // nothing todo
                            return destinationFilePath;
                    }
                }

                //delete if it already exists per user
                if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_DeleteExisting), engine))
                {
                    File.Delete(destinationFilePath);
                }

                processFunc(path, destinationFilePath);

                return destinationFilePath;
            });
        }
    }
}
