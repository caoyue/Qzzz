Qzzz
====

A scheduler app for windows.

### How to use
- **Run as a windows service**<br/>
    Use ```Install.bat``` to install the ```QzzzService```
- **Run as a console**<br/>
    Run ```Qzzz.exe``` and do not close the console.

### Web Admin
- Run ```Qzzz.Admin.exe``` on your scheduler server
- Open ```http://[YourIP/localhost]:1874```

### Create a plugin
- create a config file ```qzzz.json```

    ```JSON
    {
        "Id": "323ADBF530C4307B336C670B3F5BD229",
        "Name": "ToastPluginDemo",
        "Version": "1.0",
        "Description": "Toast plugin demo",
        "CronExpression": "*/15 * * * * ?",
        "StartAt": "2014-06-01 00:00:00",
        "EndAt": "2014-07-01 00:01:00",
        "PluginFileName": "Qzzz.ToastPluginDemo.dll",
        "Author": "caoyue",
        "Url": "https://github.com/caoyue/Qzzz"
    }
    ```
    * ```Id``` should be a guid string
    * ```CronExpression``` is a Quartz Cron Expression, a little different from *nix
    * ```StartAt``` and ```EndAt``` is optional
- Create a CSharp library project
- Add ```Qzzz.Plugin.dll``` to the references
- Implement ```IPlugin``` interface

    ```CSharp
    public class SimplePlugin : IPlugin
    {
        public void Execute(PluginContext pluginContext)
        {
            // do your job here...
        }

        public bool Pause(PluginContext pluginContext)
        {
            // pause job while the return is true...
        }
    }
    ```
    * You can find a demo in ```Plugins\Qzzz.SimplePluginDemo```

- Build your project and copy the plugin folder to ```Qzzz\Plugins```


