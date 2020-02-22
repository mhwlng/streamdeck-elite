# streamdeck-elite
Elgato Stream Deck toggle-button plugin for Elite Dangerous

![Elgato Stream Deck](https://i.imgur.com/2JmmqNm.jpg)

This plugin connects to Elite Dangerous, to get the on/off status for 12 different toggle-buttons, 
4 buttons to control the power distributor pips and 4 alarm buttons.

If you press the relevant button on your keyboard or hotas, then the image on the stream deck will change correctly.

When a button has no effect (e.g. when docked) then the image won't change.

(normal buttons don't need any plugin, they simply simulate a keypress)

The supported toggle-buttons are:
- Cargo Scoop
- Landing Gear
- Flight Assist
- Lights
- Night Vision
- Analysis Mode
- Hardpoints
- Supercruise
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
- Deploy Shield Cell Bank (alarm = shields down status)

The plugin looks for a StartPreset.start file in this Elite Dangerous key bindings directory :

`%userprofile%\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\`

That .start file should contain the exact name of the key binding file. (Without the extension .3.0.binds or .binds)

Also, the steam library directories are searched, for any of the default key binding files :
 
`....\steamapps\common\Elite Dangerous\Products\elite-dangerous-64\ControlSchemes`

This plugin ony works with keyboard bindings. 
So, when there is only a binding to a joystick / controller for a function, then you need to add a keyboard binding.

If you change the bindings in Elite Dangerous, then you need to restart the streamdeck application.

The plugin installer is here: https://github.com/mhwlng/streamdeck-elite/releases

To install the plugin, double click the file `com.mhwlng.elite.streamDeckPlugin` which should install the plugin.

(This only works, if the plugin not already installed. Otherwise you will need to uninstall or remove the plugin first.)

This .streamDeckPlugin file is a zip file and the contents are simply copied to :

`%userprofile%\AppData\Roaming\Elgato\StreamDeck\Plugins\com.mhwlng.elite.sdPlugin`

To uninstall, stop the Stream Deck application:

`c:\Program Files\Elgato\StreamDeck\StreamDeck.exe`

and delete the com.mhwlng.elite.sdPlugin directory.

Some example button images can be found in the source code images directory.

The com.mhwlng.elite.sdPlugin directory contains a pluginlog.log file, which may be useful for troubleshooting.


Also see companion application for Logitech Flight Instrument Panel :

https://github.com/mhwlng/fip-elite

Thanks to :

https://github.com/BarRaider/streamdeck-tools

https://github.com/EliteAPI/EliteAPI

https://github.com/ishaaniMittal/inputsimulator

https://nerdordie.com/product/stream-deck-key-icons/

