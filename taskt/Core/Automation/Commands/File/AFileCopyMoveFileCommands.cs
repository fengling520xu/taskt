using System;
using System.IO;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// for Copy/Move file commands
    /// </summary>
    public abstract class AFileCopyMoveFileCommands : AFileExistsFilePathBeforeAfterResultCommands
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        [PropertyDisplayText(true, "Folder")]
        [PropertyParameterOrder(6000)]
        public virtual string v_DestinationFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("Create Folder When Destination Folder does not Exist")]
        [PropertyUISelectionOption("Yes")]
        [PropertyUISelectionOption("No")]
        [Remarks("Specify whether the directory should be created if it does not already exist.")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(7000)]
        public virtual string v_CreateDirectory { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("Delete File if it already Exists")]
        [PropertyUISelectionOption("Yes")]
        [PropertyUISelectionOption("No")]
        [Remarks("Specify whether the file should be deleted first if it is already found to exist.")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(8000)]
        public virtual string v_DeleteExisting { get; set; }

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
                // todo: use folderAction
                var destinationFolder = v_DestinationFolderPath.ExpandValueOrUserVariableAsFolderPath(engine);

                if (!Directory.Exists(destinationFolder))
                {
                    if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_CreateDirectory), engine))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }
                    else
                    {
                        throw new Exception("destination folder does not exists: " + destinationFolder);
                    }
                }

                //get source file name and info
                var sourceFileInfo = new FileInfo(path);

                //create destination
                var destinationFilePath = Path.Combine(destinationFolder, sourceFileInfo.Name);

                // todo: check folder is same

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
