# Handling `nxm://` links

## Registering `Fo76ini.exe` as a URL handler

> See the related code:
> - [Fo76ini/Forms/FormMain/Views/UserControlSettings.cs](https://github.com/FelisDiligens/Fallout76-QuickConfiguration/blob/8254960a603c5c0939b9ba46bbf3233af77cc2ef/Fo76ini/Forms/FormMain/Views/UserControlSettings.cs#L277)
> - [Fo76ini/NexusAPI/NXMHandler.cs](https://github.com/FelisDiligens/Fallout76-QuickConfiguration/blob/8254960a603c5c0939b9ba46bbf3233af77cc2ef/Fo76ini/NexusAPI/NXMHandler.cs)

## How it's handled

- When the app get's opened with an `nxm://` link as an argument, it writes that url to a `nxm.txt` file into the configuration path (`$env:LocalAppData\Fallout 76 Quick Configuration`).
- If an instance of the app is already running, it just quits.
- If not...
    - It will notice the `nxm.txt` file, load it, and then delete it.
    - Open FormMods, if it isn't already opened.
    - Download the file and import it.
