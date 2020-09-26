using System;
using System.Collections.Generic;
using WindowsInput.Native;

namespace WindowsInput
{
    /// <summary>
    /// The service contract for a keyboard simulator for the Windows platform.
    /// </summary>
    public interface IKeyboardSimulator
    {
        /// <summary>
        /// Gets the <see cref="IMouseSimulator"/> instance for simulating Mouse input.
        /// </summary>
        /// <value>The <see cref="IMouseSimulator"/> instance.</value>
        IMouseSimulator Mouse { get; }

        /// <summary>
        /// Simulates the key down gesture for the specified key.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKeyCode"/> for the key.</param>
        IKeyboardSimulator KeyDown(VirtualKeyCode keyCode);

        /// <summary>
        /// Simulates the key press gesture for the specified key.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKeyCode"/> for the key.</param>
        IKeyboardSimulator KeyPress(VirtualKeyCode keyCode);

        /// <summary>
        /// Simulates a key press for each of the specified key codes in the order they are specified.
        /// </summary>
        /// <param name="keyCodes"></param>
        IKeyboardSimulator KeyPress(params VirtualKeyCode[] keyCodes);

        /// <summary>
        /// Simulates the key up gesture for the specified key.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKeyCode"/> for the key.</param>
        IKeyboardSimulator KeyUp(VirtualKeyCode keyCode);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and multiple keys like CTRL-ALT-K-C where CTRL and ALT are the modifierKeys and K and C are the keys.
        /// The flow is Modifiers KeyDown in order, Keys Press in order, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierKeyCodes">The list of <see cref="VirtualKeyCode"/>s for the modifier keys.</param>
        /// <param name="keyCodes">The list of <see cref="VirtualKeyCode"/>s for the keys to simulate.</param>
        IKeyboardSimulator ModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, IEnumerable<VirtualKeyCode> keyCodes);

        /// <summary>
        /// Manually creates a keystroke and delays the keyup by a specified number of ms.
        /// The flow is Modifiers KeyDown in order, Keys Press in order, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierKeyCodes">The list of <see cref="VirtualKeyCode"/>s for the modifier keys.</param>
        /// <param name="keyCodes">The list of <see cref="VirtualKeyCode"/>s for the keys to simulate.</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, IEnumerable<VirtualKeyCode> keyCodes, int delay);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
        /// The flow is Modifiers KeyDown in order, Key Press, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierKeyCodes">The list of <see cref="VirtualKeyCode"/>s for the modifier keys.</param>
        /// <param name="keyCode">The <see cref="VirtualKeyCode"/> for the key.</param>
        IKeyboardSimulator ModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, VirtualKeyCode keyCode);

        /// <summary>
        /// Simulates a modified keystroke where there is one modifier and multiple keys like CTRL-K-C where CTRL is the modifierKey and K and C are the keys.
        /// The flow is Modifier KeyDown, Keys Press in order, Modifier KeyUp.
        /// </summary>
        /// <param name="modifierKey">The <see cref="VirtualKeyCode"/> for the modifier key.</param>
        /// <param name="keyCodes">The list of <see cref="VirtualKeyCode"/>s for the keys to simulate.</param>
        IKeyboardSimulator ModifiedKeyStroke(VirtualKeyCode modifierKey, IEnumerable<VirtualKeyCode> keyCodes);

        /// <summary>
        /// Simulates a simple modified keystroke like CTRL-C where CTRL is the modifierKey and C is the key.
        /// The flow is Modifier KeyDown, Key Press, Modifier KeyUp.
        /// </summary>
        /// <param name="modifierKeyCode">The <see cref="VirtualKeyCode"/> for the  modifier key.</param>
        /// <param name="keyCode">The <see cref="VirtualKeyCode"/> for the key.</param>
        IKeyboardSimulator ModifiedKeyStroke(VirtualKeyCode modifierKeyCode, VirtualKeyCode keyCode);

        /// <summary>
        /// Calls the Win32 SendInput method to simulate a KeyDown.
        /// </summary>
        /// <param name="dikCode">The <see cref="DirectInputKeyCode"/> to press</param>
        IKeyboardSimulator KeyDown(DirectInputKeyCode dikCode);

        /// <summary>
        /// Calls the Win32 SendInput method to simulate a KeyUp.
        /// </summary>
        /// <param name="dikCode">The <see cref="DirectInputKeyCode"/> to lift up</param>
        IKeyboardSimulator KeyUp(DirectInputKeyCode dikCode);

        /// <summary>
        /// Calls the Win32 SendInput method with a KeyDown and KeyUp message in the same input sequence in order to simulate a Key PRESS.
        /// </summary>
        /// <param name="dikCode">The <see cref="DirectInputKeyCode"/> to press</param>
        IKeyboardSimulator KeyPress(DirectInputKeyCode dikCode);

        /// <summary>
        /// Calls the Win32 SendInput method with a KeyDown and KeyUp message in the same input sequence in order to simulate a Key PRESS.
        /// </summary>
        /// <param name="dikCode">The <see cref="DirectInputKeyCode"/> to press</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedKeyPress(DirectInputKeyCode dikCode, int delay);


        /// <summary>
        /// Calls the Win32 SendInput method with a KeyUp message
        /// </summary>
        /// <param name="dikCode">The <see cref="DirectInputKeyCode"/> to press</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedKeyPressUp(DirectInputKeyCode dikCode, int delay);

        /// <summary>
        /// Calls the Win32 SendInput method with a KeyDown message
        /// </summary>
        /// <param name="dikCode">The <see cref="DirectInputKeyCode"/> to press</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedKeyPressDown(DirectInputKeyCode dikCode, int delay);


        /// <summary>
        /// Simulates a simple modified keystroke like CTRL-C where CTRL is the modifierKey and C is the key.
        /// The flow is Modifier KeyDown, Key Press, Modifier KeyUp.
        /// </summary>
        /// <param name="modifierDikCode">The modifier key</param>
        /// <param name="dikCode">The key to simulate</param>
        IKeyboardSimulator ModifiedKeyStroke(DirectInputKeyCode modifierDikCode, DirectInputKeyCode dikCode);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
        /// The flow is Modifiers KeyDown in order, Key Press, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierDikCodes">The list of modifier keys</param>
        /// <param name="dikCode">The key to simulate</param>
        IKeyboardSimulator ModifiedKeyStroke(IEnumerable<DirectInputKeyCode> modifierDikCodes, DirectInputKeyCode dikCode);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
        /// The flow is Modifiers KeyDown in order, Key Press, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierDikCodes">The list of modifier keys</param>
        /// <param name="dikCode">The key to simulate</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedModifiedKeyStroke(IEnumerable<DirectInputKeyCode> modifierDikCodes, DirectInputKeyCode dikCode, int delay);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
        /// The flow is Modifiers KeyDown in order, Key Press
        /// </summary>
        /// <param name="modifierDikCodes">The list of modifier keys</param>
        /// <param name="dikCode">The key to simulate</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedModifiedKeyStrokeDown(IEnumerable<DirectInputKeyCode> modifierDikCodes, DirectInputKeyCode dikCode, int delay);


        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and one key like CTRL-ALT-C where CTRL and ALT are the modifierKeys and C is the key.
        /// The flow is Key Press, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierDikCodes">The list of modifier keys</param>
        /// <param name="dikCode">The key to simulate</param>
        /// <param name="delay">Delay in ms between keydown and keyup of final keyCode.</param>
        IKeyboardSimulator DelayedModifiedKeyStrokeUp(IEnumerable<DirectInputKeyCode> modifierDikCodes, DirectInputKeyCode dikCode, int delay);

        /// <summary>
        /// Simulates a modified keystroke where there is one modifier and multiple keys like CTRL-K-C where CTRL is the modifierKey and K and C are the keys.
        /// The flow is Modifier KeyDown, Keys Press in order, Modifier KeyUp.
        /// </summary>
        /// <param name="modifierDikCode">The modifier key</param>
        /// <param name="dikCodes">The list of keys to simulate</param>
        IKeyboardSimulator ModifiedKeyStroke(DirectInputKeyCode modifierDikCode, IEnumerable<DirectInputKeyCode> dikCodes);

        /// <summary>
        /// Simulates a modified keystroke where there are multiple modifiers and multiple keys like CTRL-ALT-K-C where CTRL and ALT are the modifierKeys and K and C are the keys.
        /// The flow is Modifiers KeyDown in order, Keys Press in order, Modifiers KeyUp in reverse order.
        /// </summary>
        /// <param name="modifierDikCodes">The list of modifier keys</param>
        /// <param name="dikCodes">The list of keys to simulate</param>
        IKeyboardSimulator ModifiedKeyStroke(IEnumerable<DirectInputKeyCode> modifierDikCodes, IEnumerable<DirectInputKeyCode> dikCodes);

        /// <summary>
        /// Simulates uninterrupted text entry via the keyboard.
        /// </summary>
        /// <param name="text">The text to be simulated.</param>
        IKeyboardSimulator TextEntry(string text);

        /// <summary>
        /// Simulates a single character text entry via the keyboard.
        /// </summary>
        /// <param name="character">The unicode character to be simulated.</param>
        IKeyboardSimulator TextEntry(char character);

        /// <summary>
        /// Sleeps the executing thread to create a pause between simulated inputs.
        /// </summary>
        /// <param name="millsecondsTimeout">The number of milliseconds to wait.</param>
        IKeyboardSimulator Sleep(int millsecondsTimeout);

        /// <summary>
        /// Sleeps the executing thread to create a pause between simulated inputs.
        /// </summary>
        /// <param name="timeout">The time to wait.</param>
        IKeyboardSimulator Sleep(TimeSpan timeout);
    }
}
