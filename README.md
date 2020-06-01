# streamdeck-elite
Elgato Stream Deck toggle-button plugin for Elite Dangerous

![Elgato Stream Deck](https://i.imgur.com/bc3Xrv0.jpg)

This plugin connects to Elite Dangerous, to get the on/off status for 12 different toggle-buttons, 
4 buttons to control the power distributor pips, 4 alarm buttons, 3 FSD related buttons and a generic limpet controller button.

If you press the relevant button on your keyboard or hotas, then the image on the stream deck will change correctly.

When a button has no effect (e.g. when docked) then the image won't change.

The plugin can (optionally) automatically switch to a different profile, if the in-game state changes (e.g. deploy hardpoints, enter SRV etc.)

More instructions on the[Wiki](https://github.com/mhwlng/streamdeck-elite/wiki/Automatic-Profile-Switching)

(normal buttons don't need any plugin, they simply simulate a keypress)

The supported toggle-buttons are:
- Cargo Scoop
- Landing Gear
- Flight Assist
- Lights
- Night Vision
- Analysis Mode
- Hardpoints
- Supercruise (no longer needed)
- Silent Running
- SRV Turret
- SRV Drive Assist
- SRV Handbrake

The supported power distributor pips buttons are:
- Reset
- System
- Engines
- Weapons

A long press on a button will set the power distributor to 4 pips.
There is a separate button image for 4 pips.

The supported alarm buttons are:
- Highest Threat (alarm = under attack status)
- Deploy Chaff (alarm = under attack status)
- Deploy Heatsink (alarm = overheating status)
- Deploy Shield Cell Bank (alarm = shields down status. In that case DON'T fire a shield cell bank.)

The supported FSD related buttons are:
- Toggle FSD, also shows Remaining Jumps In Route
- Supercruise
- Hyperspace Jump, also shows Remaining Jumps In Route

These FSD buttons have 3 images:
- engaged  : supercruise/hyperspace is active
- enabled  : supercruise/hyperspace is inactive
- disabled : supercruise/hyperspace is blocked for reasons like (Docked, Landed, LandingGearDown, CargoScoopDeployed, FsdMassLocked, FsdCooldown, HardpointsDeployed)

The limpet controller button works with any type of limpet controller.

The button shows the current number of limpets in the cargo hold. (The same value is shown on all buttons).
There is no specific keybind for any type of limpet controller.
Instead, you need to set up a fire group letter and primary or secondary fire button.

The plugin looks for a StartPreset.start file in this Elite Dangerous key bindings directory :

`%LocalAppData%\Frontier Developments\Elite Dangerous\Options\Bindings\`

That .start file should contain the exact name of the key binding file. (Without the extension .3.0.binds or .binds)

Also, the steam library directories are searched, for any of the default key binding files :
 
`....\steamapps\common\Elite Dangerous\Products\elite-dangerous-64\ControlSchemes`

This plugin ony works with keyboard bindings. 
So, when there is only a binding to a joystick / controller for a function, then you need to add a keyboard binding.

If you change the key bindings in Elite Dangerous, then you don't have to restart the streamdeck software. The plugin key bindings are updated automatically.

The plugin installer is here: https://github.com/mhwlng/streamdeck-elite/releases

To install the plugin, double click the file `com.mhwlng.elite.streamDeckPlugin` which should install the plugin.

(This only works, if the plugin not already installed. Otherwise you will need to uninstall or remove the plugin first.)

This .streamDeckPlugin file is a zip file and the contents are simply copied to :

`%appdata%\Elgato\StreamDeck\Plugins\com.mhwlng.elite.sdPlugin`

To uninstall : select 'more actions' in the streamdeck application, find the plugin and select uninstall.

or stop the Stream Deck application:

`c:\Program Files\Elgato\StreamDeck\StreamDeck.exe`

and delete the com.mhwlng.elite.sdPlugin directory.

The button configurations are not stored in the plugin directory.

Note that the entire plugin directory is deleted when uninstalling. (including any images that you may have manually put there yourself)

After uninstalling and re-installing the plugin, all the button definition should still be there.

Some example button images can be found in the source code images directory.

The com.mhwlng.elite.sdPlugin directory contains a pluginlog.log file, which may be useful for troubleshooting.

Best is to create a separate directory for the images, so that they are not deleted when uninstalling/reinstalling the plugin.


Also see companion application for Logitech Flight Instrument Panel and VR :

https://github.com/mhwlng/fip-elite

Thanks to :

https://github.com/BarRaider/streamdeck-tools

https://github.com/MagicMau/EliteJournalReader

https://github.com/ishaaniMittal/inputsimulator

https://nerdordie.com/product/stream-deck-key-icons/

