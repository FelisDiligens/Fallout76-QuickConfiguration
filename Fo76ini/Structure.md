# Project structure
* 📁 .\
    * 📁 **Forms**: Contains all forms.
        * 📁 **Form1**: Main form
        * 📁 **FormMods**: Mod manager form
        * 📁 **FormNexusAPI**: Form that lets you enter the apikey.
        * 📁 **FormProfiles**: Profile manager
        * 📁 **FormWhatsNew**: The little "What's new" form.
        * 📁 **FormTextPrompt**: A versatile text prompt designed to be opened using ShowDialog(), similiar to JavaScript's prompt().
        * 📁 **ExceptionDialog**: The form that pops up when something bad happens.
        * 📁 FormSplash: *Unused splash screen*
    * 📁 **Profiles**: Contains classes that represent and handle game instances and their profiles.
    * 📁 **Tweaks**: Contains classes that implement the ITweak and ITweakInfo interfaces.<br>These classes contain information about a particular tweak (description, affected values, etc.) and provide getter and setter.
    * 📁 **Mods**: Contains classes for representing and handling mods.
        * **ManagedMod**: Represents a managed mod without altering it.
        * **ManagedMods**: Represents a list of managed mods as well as a list of resources.
        * **ModActions**: Bundles functions that change the state or the files of a mod, but don't affect game files.
        * **ModDeployment**: Bundles functions that add, remove, or change game files.
        * **ModHelpers**: Bundles functions that help with working with mods.<br>They don't affect any files and don't change any state.
        * **ModInstallations**: Bundles methods that handle the installation and import of mods.
        * **ResourceList**: Wrapper around the resource lists to function as a regular List.<br>Implements ways to read and write to *.ini file.
    * 📁 **Interface**: Contains classes related to the interface.
        * **DropDown**: A wrapper around ComboBox, designed to be easily translated.
        * **MsgBox**: A wrapper around MessageBox.Show(), designed to be easily translated.
        * **Versioning**: Checks if there's an update.
        * **Translation**: Looks for, loads, and generates *.xml files (translations) and applies translated texts to various controls, as well as raising an event, so other classes can update their UI.
        * **Translation.Shared.cs**: Defines a lot of messageboxes and strings that are used throughout the code. These messageboxes and strings can be translated.
        * **InvalidXmlException**: Thrown when e.g. an XML file **doesn't** contain a needed element or attribute.
    * 📁 **NexusAPI**: Contains classes that connect to the NexusMods public API.
    * 📁 **Utilities**: Various classes used throughout the code, such as a logger.