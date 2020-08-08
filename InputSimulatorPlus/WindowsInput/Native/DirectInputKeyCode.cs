namespace WindowsInput.Native
{
    /// <summary>
    /// The list of DirectInput keyboard scan codes from dinput.h in dxsdk
    /// </summary>
    public enum DirectInputKeyCode
    {
        /// <summary>
        /// Escape key
        /// </summary>
        DikEscape = 0x01,
        /// <summary>
        /// '1' key on main keyboard
        /// </summary>
        Dik1 = 0x02,
        /// <summary>
        /// '2' key on main keyboard
        /// </summary>
        Dik2 = 0x03,
        /// <summary>
        /// '3' key on main keyboard
        /// </summary>
        Dik3 = 0x04,
        /// <summary>
        /// '4' key on main keyboard
        /// </summary>
        Dik4 = 0x05,
        /// <summary>
        /// '5' key on main keyboard
        /// </summary>
        Dik5 = 0x06,
        /// <summary>
        /// '6' key on main keyboard
        /// </summary>
        Dik6 = 0x07,
        /// <summary>
        /// '7' key on main keyboard
        /// </summary>
        Dik7 = 0x08,
        /// <summary>
        /// '8' key on main keyboard
        /// </summary>
        Dik8 = 0x09,
        /// <summary>
        /// '9' key on main keyboard
        /// </summary>
        Dik9 = 0x0A,
        /// <summary>
        /// '0' key on main keyboard
        /// </summary>
        Dik0 = 0x0B,
        /// <summary>
        /// '-' key on main keyboard
        /// </summary>
        DikMinus = 0x0C,
        /// <summary>
        /// '=' key
        /// </summary>
        DikEquals = 0x0D,
        /// <summary>
        /// Backspace key
        /// </summary>
        DikBack = 0x0E,
        /// <summary>
        /// Tab key
        /// </summary>
        DikTab = 0x0F,
        /// <summary>
        /// 'q' key
        /// </summary>
        DikQ = 0x10,
        /// <summary>
        /// 'w' key
        /// </summary>
        DikW = 0x11,
        /// <summary>
        /// 'e' key
        /// </summary>
        DikE = 0x12,
        /// <summary>
        /// 'r' key
        /// </summary>
        DikR = 0x13,
        /// <summary>
        /// 't' key
        /// </summary>
        DikT = 0x14,
        /// <summary>
        /// 'y' key
        /// </summary>
        DikY = 0x15,
        /// <summary>
        /// 'u' key
        /// </summary>
        DikU = 0x16,
        /// <summary>
        /// 'i' key
        /// </summary>
        DikI = 0x17,
        /// <summary>
        /// 'o' key
        /// </summary>
        DikO = 0x18,
        /// <summary>
        /// 'p' key
        /// </summary>
        DikP = 0x19,
        /// <summary>
        /// '[' key???
        /// </summary>
        DikLbracket = 0x1A,
        /// <summary>
        /// ']' key???
        /// </summary>
        DikRbracket = 0x1B,
        /// <summary>
        /// 'enter' key on main keyboard
        /// </summary>
        DikReturn = 0x1C,
        /// <summary>
        /// Left control key
        /// </summary>
        DikLcontrol = 0x1D,
        /// <summary>
        /// 'a' key
        /// </summary>
        DikA = 0x1E,
        /// <summary>
        /// 's' key
        /// </summary>
        DikS = 0x1F,
        /// <summary>
        /// 'd' key
        /// </summary>
        DikD = 0x20,
        /// <summary>
        /// 'f' key
        /// </summary>
        DikF = 0x21,
        /// <summary>
        /// 'g' key
        /// </summary>
        DikG = 0x22,
        /// <summary>
        /// 'h' key
        /// </summary>
        DikH = 0x23,
        /// <summary>
        /// 'j' key
        /// </summary>
        DikJ = 0x24,
        /// <summary>
        /// 'k' key
        /// </summary>
        DikK = 0x25,
        /// <summary>
        /// 'l' key
        /// </summary>
        DikL = 0x26,
        /// <summary>
        /// ';' key
        /// </summary>
        DikSemicolon = 0x27,
        /// <summary>
        /// ' key
        /// </summary>
        DikApostrophe = 0x28,
        /// <summary>
        /// '`' key (Accent grave)
        /// </summary>
        DikGrave = 0x29,
        /// <summary>
        /// Left shift key
        /// </summary>
        DikLshift = 0x2A,
        /// <summary>
        /// '\' key
        /// </summary>
        DikBackslash = 0x2B,
        /// <summary>
        /// 'z' key
        /// </summary>
        DikZ = 0x2C,
        /// <summary>
        /// 'x' key
        /// </summary>
        DikX = 0x2D,
        /// <summary>
        /// 'c' key
        /// </summary>
        DikC = 0x2E,
        /// <summary>
        /// 'v' key
        /// </summary>
        DikV = 0x2F,
        /// <summary>
        /// 'b' key
        /// </summary>
        DikB = 0x30,
        /// <summary>
        /// 'n' key
        /// </summary>
        DikN = 0x31,
        /// <summary>
        /// 'm' key
        /// </summary>
        DikM = 0x32,
        /// <summary>
        /// ',' key
        /// </summary>
        DikComma = 0x33,
        /// <summary>
        /// '.' key on main keyboard
        /// </summary>
        DikPeriod = 0x34,
        /// <summary>
        /// '/' key on main keyboard
        /// </summary>
        DikSlash = 0x35,
        /// <summary>
        /// Right shift key
        /// </summary>
        DikRshift = 0x36,
        /// <summary>
        /// '*' key on numeric keypad
        /// </summary>
        DikMultiply = 0x37,
        /// <summary>
        /// Left alt key
        /// </summary>
        DikLmenu = 0x38,
        /// <summary>
        /// ' ' key
        /// </summary>
        DikSpace = 0x39,
        /// <summary>
        /// Caps lock key
        /// </summary>
        DikCapital = 0x3A,
        /// <summary>
        /// 'F1' key
        /// </summary>
        DikF1 = 0x3B,
        /// <summary>
        /// 'F2' key
        /// </summary>
        DikF2 = 0x3C,
        /// <summary>
        /// 'F3' key
        /// </summary>
        DikF3 = 0x3D,
        /// <summary>
        /// 'F4' key
        /// </summary>
        DikF4 = 0x3E,
        /// <summary>
        /// 'F5' key
        /// </summary>
        DikF5 = 0x3F,
        /// <summary>
        /// 'F6' key
        /// </summary>
        DikF6 = 0x40,
        /// <summary>
        /// 'F7' key
        /// </summary>
        DikF7 = 0x41,
        /// <summary>
        /// 'F8' key
        /// </summary>
        DikF8 = 0x42,
        /// <summary>
        /// 'F9' key
        /// </summary>
        DikF9 = 0x43,
        /// <summary>
        /// 'F10' key
        /// </summary>
        DikF10 = 0x44,
        /// <summary>
        /// Numlock key
        /// </summary>
        DikNumlock = 0x45,
        /// <summary>
        /// Scroll lock key
        /// </summary>
        DikScroll = 0x46    /* Scroll Lock */,
        /// <summary>
        /// '7' key on numeric keypad
        /// </summary>
        DikNumpad7 = 0x47,
        /// <summary>
        /// '8' key on numeric keypad
        /// </summary>
        DikNumpad8 = 0x48,
        /// <summary>
        /// '9' key on numeric keypad
        /// </summary>
        DikNumpad9 = 0x49,
        /// <summary>
        /// '-' key on numeric keypad
        /// </summary>
        DikSubtract = 0x4A,
        /// <summary>
        /// '4' key on numeric keypad
        /// </summary>
        DikNumpad4 = 0x4B,
        /// <summary>
        /// '5' key on numeric keypad
        /// </summary>
        DikNumpad5 = 0x4C,
        /// <summary>
        /// '6' key on numeric keypad
        /// </summary>
        DikNumpad6 = 0x4D,
        /// <summary>
        /// '+' key on numeric keypad
        /// </summary>
        DikAdd = 0x4E,
        /// <summary>
        /// '1' key on numeric keypad
        /// </summary>
        DikNumpad1 = 0x4F,
        /// <summary>
        /// '2' key on numeric keypad
        /// </summary>
        DikNumpad2 = 0x50,
        /// <summary>
        /// '3' key on numeric keypad
        /// </summary>
        DikNumpad3 = 0x51,
        /// <summary>
        /// '0' key on numeric keypad
        /// </summary>
        DikNumpad0 = 0x52,
        /// <summary>
        /// '.' key on numeric keypad
        /// </summary>
        DikDecimal = 0x53,
        /// <summary>
        /// PrintScreen key
        /// </summary>
        DikPrintscreen = 0x54,
        /// <summary>
        /// &lt;&gt; or \| on RT 102-key keyboard (Non-U.S.)
        /// </summary>
        DikOem102 = 0x56,
        /// <summary>
        /// 'F11' key
        /// </summary>
        DikF11 = 0x57,
        /// <summary>
        /// 'F12' key
        /// </summary>
        DikF12 = 0x58,
        /// <summary>
        /// 'F12' key
        /// </summary>
        DikNumeric5 = 0x59,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xEE)
        /// </summary>
        DikOemEe = 0x5A,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF1)
        /// </summary>
        DikOemF1 = 0x5B,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF1)
        /// </summary>
        DikOemEa = 0x5C,
        /// <summary>
        /// Erase EOF key
        /// </summary>
        DikEraseEof = 0x5D,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF5)
        /// </summary>
        DikOemF5 = 0x5E,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF3)
        /// </summary>
        DikOemF3 = 0x5F,
        /// <summary>
        /// 'Zoom' key
        /// </summary>
        DikZoom = 0x62,
        /// <summary>
        /// 'HELP' key
        /// </summary>
        DikHelp = 0x63,
        /// <summary>
        /// 'F13' key (NEC PC98)
        /// </summary>
        DikF13 = 0x64,
        /// <summary>
        /// 'F14' key (NEC PC98)
        /// </summary>
        DikF14 = 0x65,
        /// <summary>
        /// 'F15' key (NEC PC98)
        /// </summary>
        DikF15 = 0x66,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF16 = 0x67,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF17 = 0x68,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF18 = 0x69,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF19 = 0x6A,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF20 = 0x6B,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF21 = 0x6C,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF22 = 0x6D,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DikF23 = 0x6E,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xED)
        /// </summary>
        DikOemEd = 0x6F,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DikKana = 0x70,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xE9)
        /// </summary>
        DikOemE9 = 0x71,
        /// <summary>
        /// /? on Brazilian keyboard
        /// </summary>
        DikAbntC1 = 0x73,
        /// <summary>
        /// F24 key
        /// </summary>
        DikF24 = 0x76,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DikConvert = 0x79,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DikNoconvert = 0x7B,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DikYen = 0x7D,
        /// <summary>
        /// Numpad . on Brazilian keyboard
        /// </summary>
        DikAbntC2 = 0x7E,
        /// <summary>
        /// '=' on numeric keypad (NEC PC98)
        /// </summary>
        DikNumpadequals = 0x8D,
        /// <summary>
        /// Previous Track key (DIK_CIRCUMFLEX on Japanese keyboard)
        /// </summary>
        DikPrevtrack = 0x90,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DikAt = 0x91,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DikColon = 0x92,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DikUnderline = 0x93,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DikKanji = 0x94,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DikStop = 0x95,
        /// <summary>
        /// Japan AX
        /// </summary>
        DikAx = 0x96,
        /// <summary>
        /// J3100
        /// </summary>
        DikUnlabeled = 0x97,
        /// <summary>
        /// Next Track key
        /// </summary>
        DikNexttrack = 0x99,
        /// <summary>
        /// Enter key on numeric keypad
        /// </summary>
        DikNumpadenter = 0x9C,
        /// <summary>
        /// Right control key
        /// </summary>
        DikRcontrol = 0x9D,
        /// <summary>
        /// Mute key
        /// </summary>
        DikMute = 0xA0,
        /// <summary>
        /// Calculator key
        /// </summary>
        DikCalculator = 0xA1,
        /// <summary>
        /// Play/Pause key
        /// </summary>
        DikPlaypause = 0xA2,
        /// <summary>
        /// Media Stop key
        /// </summary>
        DikMediastop = 0xA4,
        /// <summary>
        /// Volume down key
        /// </summary>
        DikVolumedown = 0xAE,
        /// <summary>
        /// Volume up key
        /// </summary>
        DikVolumeup = 0xB0,
        /// <summary>
        /// Web home key
        /// </summary>
        DikWebhome = 0xB2,
        /// <summary>
        /// ',' key on numeric keypad
        /// </summary>
        DikNumpadcomma = 0xB3,
        /// <summary>
        /// '/' key on numeric keypad
        /// </summary>
        DikDivide = 0xB5,
        /// <summary>
        /// ???
        /// </summary>
        DikSysrq = 0xB7,
        /// <summary>
        /// Right alt key
        /// </summary>
        DikRmenu = 0xB8,
        /// <summary>
        /// Pause key
        /// </summary>
        DikPause = 0xC5,
        /// <summary>
        /// Home key on arrow keypad
        /// </summary>
        DikHome = 0xC7,
        /// <summary>
        /// Up arrow key on arrow keypad
        /// </summary>
        DikUp = 0xC8,
        /// <summary>
        /// PageUp key on arrow keypad
        /// </summary>
        DikPrior = 0xC9,
        /// <summary>
        /// Left arrow key on arrow keypad
        /// </summary>
        DikLeft = 0xCB,
        /// <summary>
        /// Right arrow key on arrow keypad
        /// </summary>
        DikRight = 0xCD,
        /// <summary>
        /// End key on arrow keypad
        /// </summary>
        DikEnd = 0xCF,
        /// <summary>
        /// Down arrow key on arrow keypad
        /// </summary>
        DikDown = 0xD0,
        /// <summary>
        /// PageDown key on arrow keypad
        /// </summary>
        DikNext = 0xD1,
        /// <summary>
        /// Insert key on arrow keypad
        /// </summary>
        DikInsert = 0xD2,
        /// <summary>
        /// Delete key on arrow keypad
        /// </summary>
        DikDelete = 0xD3,
        /// <summary>
        /// Left Windows key
        /// </summary>
        DikLwin = 0xDB,
        /// <summary>
        /// Right Windows key
        /// </summary>
        DikRwin = 0xDC,
        /// <summary>
        /// AppMenu key
        /// </summary>
        DikApps = 0xDD,
        /// <summary>
        /// System power key
        /// </summary>
        DikPower = 0xDE,
        /// <summary>
        /// System sleep key
        /// </summary>
        DikSleep = 0xDF,
        /// <summary>
        /// System wake key
        /// </summary>
        DikWake = 0xE3,
        /// <summary>
        /// Web search key
        /// </summary>
        DikWebsearch = 0xE5,
        /// <summary>
        /// Web favorites key
        /// </summary>
        DikWebfavorites = 0xE6,
        /// <summary>
        /// Web refresh key
        /// </summary>
        DikWebrefresh = 0xE7,
        /// <summary>
        /// Web stop key
        /// </summary>
        DikWebstop = 0xE8,
        /// <summary>
        /// Web forward key
        /// </summary>
        DikWebforward = 0xE9,
        /// <summary>
        /// Web back key
        /// </summary>
        DikWebback = 0xEA,
        /// <summary>
        /// My computer key
        /// </summary>
        DikMycomputer = 0xEB,
        /// <summary>
        /// Mail key
        /// </summary>
        DikMail = 0xEC,
        /// <summary>
        /// Media select
        /// </summary>
        DikMediaselect = 0xED,
        /// <summary>
        /// PageUp key on arrow keypad
        /// </summary>
        DikPageUp = DikPrior,
        /// <summary>
        /// PageDown key on arrow keypad
        /// </summary>
        DikPageDown = DikNext,
        /// <summary>
        /// Backspace key
        /// </summary>
        DikBackspace = DikBack,
        /// <summary>
        /// '*' key on numeric keypad
        /// </summary>
        DikNumpadStar = DikMultiply,
        /// <summary>
        /// Left alt key
        /// </summary>
        DikLalt = DikLmenu,
        /// <summary>
        /// Caps lock key
        /// </summary>
        DikCapslock = DikCapital,
        /// <summary>
        /// '-' key on numeric keypad
        /// </summary>
        DikNumpadMinus = DikSubtract,
        /// <summary>
        /// '+' key on numeric keypad
        /// </summary>
        DikNumpadPlus = DikAdd,
        /// <summary>
        /// '.' key on numeric keypad
        /// </summary>
        DikNumpadPeriod = DikDecimal,
        /// <summary>
        /// '/' key on numeric keypad
        /// </summary>
        DikNumpadSlash = DikDivide,
        /// <summary>
        /// Right alt key
        /// </summary>
        DikRalt = DikRmenu,
        /// <summary>
        /// Up arrow key on arrow keypad
        /// </summary>
        DikUparrow = DikUp,
        /// <summary>
        /// PageUp key on arrow keypad
        /// </summary>
        DikPgup = DikPrior,
        /// <summary>
        /// Left arrow key on arrow keypad
        /// </summary>
        DikLeftarrow = DikLeft,
        /// <summary>
        /// Right arrow key on arrow keypad
        /// </summary>
        DikRightarrow = DikRight,
        /// <summary>
        /// Down arrow key on arrow keypad
        /// </summary>
        DikDownarrow = DikDown,
        /// <summary>
        /// PageDown key on arrow keypad
        /// </summary>
        DikPgdn = DikNext,

        /// <summary>
        /// </summary>
        DikEnter = DikReturn,
        /// <summary>
        /// </summary>
        DikNumpad_Equals = DikNumpadequals,
        /// <summary>
        /// </summary>
        DikNumpad_Enter = DikNumpadenter,
        /// <summary>
        /// </summary>
        DikNumpad_Comma = DikNumpadcomma,

        /// <summary>
        /// </summary>
        DikNumpad_Divide = DikNumpadSlash,
        /// <summary>
        /// </summary>
        DikNumpadDivide = DikNumpadSlash,
        /// <summary>
        /// </summary>
        DikNumpad_Multiply = DikNumpadStar,
        /// <summary>
        /// </summary>
        DikNumpadMultiply = DikNumpadStar,
        /// <summary>
        /// </summary>
        DikNumpad_Subtract = DikNumpadMinus,
        /// <summary>
        /// </summary>
        DikNumpadSubtract = DikNumpadMinus,
        /// <summary>
        /// </summary>
        DikNumpad_Decimal = DikNumpadPeriod,
        /// <summary>
        /// </summary>
        DikNumpadDecimal = DikNumpadPeriod,
        /// <summary>
        /// </summary>
        DikNumpad_Add = DikNumpadPlus,
        /// <summary>
        /// </summary>
        DikNumpadAdd = DikNumpadPlus,
        /// <summary>
        /// </summary>
        DikNumpad_7 = DikNumpad7,
        /// <summary>
        /// </summary>
        DikNumpad_8 = DikNumpad8,
        /// <summary>
        /// </summary>
        DikNumpad_9 = DikNumpad9,
        /// <summary>
        /// </summary>
        DikNumpad_4 = DikNumpad4,
        /// <summary>
        /// </summary>
        DikNumpad_5 = DikNumpad5,
        /// <summary>
        /// </summary>
        DikNumpad_6 = DikNumpad6,
        /// <summary>
        /// </summary>
        DikNumpad_1 = DikNumpad1,
        /// <summary>
        /// </summary>
        DikNumpad_2 = DikNumpad2,
        /// <summary>
        /// </summary>
        DikNumpad_3 = DikNumpad3,
        /// <summary>
        /// </summary>
        DikNumpad_0 = DikNumpad0,
        /// <summary>
        /// </summary>
        DikLeftBracket = DikLbracket,
        /// <summary>
        /// </summary>
        DikRightBracket = DikRbracket,

        /// <summary>
        /// </summary>
        DikLeftAlt = DikLmenu,
        /// <summary>
        /// </summary>
        DikRightAlt = DikRmenu,
        /// <summary>
        /// </summary>
        DikRightControl = DikRcontrol,
        /// <summary>
        /// </summary>
        DikLeftControl = DikLcontrol,
        /// <summary>
        /// </summary>
        DikRightShift = DikRshift,
        /// <summary>
        /// </summary>
        DikLeftShift = DikLshift


        /*
        //DikCircumflex = DikPrevtrack,

        Dikß = 0x0C,
        Dikü = 0,
        Dikö = 0,
        Dikä = 0,
        Diké = 0,
        Dikè = 0,
        Dikç = 0,
        Dikà = 0,
        Dikù = 0,

        DikAcute = 0,
        DikCircumflex = 0,
        DikPlus = 0,
        DikHash = 0,

        DikSuperscriptTwo = 0,
        DikAmpersand = 0,
        DikDoubleQuote = 0,
        DikLeftParenthesis = 0,
        DikRightParenthesis = 0,
        DikDollar = 0,
        DikAsterisk = 0,
        DikExclamationPoint = 0
                
        DikScrollLock = 0x46,
        DikABNT_C1 = 0x73,
        DikABNT_C2 = 0x7E,
        DikWebFavourites = 0,
        DikGreenModifier = 0,
        DikOrangeModifier = 0,
        DikSection = 0,
        DikClear = 0,
        DikLeftBracket = 0,
        DikRightBracket = 0,
        DikUnderline = 0,
        DikLessThan = 0,
        DikGreaterThan = 0,
        DikTilde = 0,
        DikRing = 0,
        DikUmlaut = 0,
        DikHalf = 0,
        DikDollar = 0,
        DikSuperscriptTwo = 0,
        DikAmpersand = 0,
        DikDoubleQuote = 0,
        DikLeftParenthesis = 0,
        DikRightParenthesis = 0,
        DikAsterisk = 0,
        DikExclamationPoint = 0,
        DikMacron = 0,
        DikOverline = 0,
        DikBreve = 0,
        DikOverdot = 0,
        DikHookAbove = 0,
        DikRingAbove = 0,
        DikDoubleAcute = 0,
        DikCaron = 0,
        DikVerticalLineAbove = 0,
        DikDoubleVerticalLineAbove = 0,
        DikDoubleGrave = 0,
        DikCandrabindu = 0,
        DikInvertedBreve = 0,
        DikTurnedCommaAbove = 0,
        DikCommaAbove = 0,
        DikReversedCommaAbove = 0,
        DikCommaAboveRight = 0,
        DikGraveBelow = 0,
        DikAcuteBelow = 0,
        DikLeftTackBelow = 0,
        DikRightTackBelow = 0,
        DikLeftAngleAbove = 0,
        DikHorn = 0,
        DikLeftHalfRingBelow = 0,
        DikUpTackBelow = 0,
        DikDownTackBelow = 0,
        DikPlusSignBelow = 0,
        DikCedilla = 0*/







    }
}