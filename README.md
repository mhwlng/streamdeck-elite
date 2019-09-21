# streamdeck-elite
Elgato Stream Deck plugin for Elite Dangerous

The plugin looks for a file StartPreset.start in this Elite Dangerous directory :

C:\Users\{UserName}\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\

That file should contain the exact name of the binding file, with the extension .binds

To install the plugin, first stop Stream Deck
c:\Program Files\Elgato\StreamDeck\StreamDeck.exe

double click the file com.mhwlng.elite.streamDeckPlugin
which should install the plugin (if it's not already installed)

The streamDeckPlugin file is a zip file and it's contents are simply copied to

C:\Users\{UserName}\AppData\Roaming\Elgato\StreamDeck\Plugins\com.mhwlng.elite.sdPlugin

and the contents 

To uninstall, stop the Stream Deck application and remove the com.mhwlng.elite.sdPlugin directory

Some example button images can be found in the source code images directory


Thanks to 
https://github.com/BarRaider/streamdeck-tools
https://github.com/ishaaniMittal/inputsimulator
https://nerdordie.com/product/stream-deck-key-icons/
