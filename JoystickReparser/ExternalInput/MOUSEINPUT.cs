using System;
using System.Runtime.InteropServices;

namespace JoystickReparser
{
    /// <summary>
    /// Define the layout of the MOUSEINPUT struct used
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        internal int dx;
        internal int dy;
        internal MouseEventData mouseData;
        internal MouseEventFlags dwFlags;
        internal uint time;
        internal UIntPtr dwExtraInfo;
    }

    /// <summary>
    /// Define the MouseEvent Data enums
    /// </summary>
    [Flags]
    public enum MouseEventData : uint
    {
        NOTHING = 0x00000000,
        XBUTTON1 = 0x00000001,
        XBUTTON2 = 0x00000002
    }

    /// <summary>
    /// Define the MouseEvent Flags
    /// </summary>
    [Flags]
    public enum MouseEventFlags : uint
    {
        ABSOLUTE = 0x8000,
        HWHEEL = 0x01000,
        MOVE = 0x0001,
        MOVE_NOCOALESCE = 0x2000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        VIRTUALDESK = 0x4000,
        WHEEL = 0x0800,
        XDOWN = 0x0080,
        XUP = 0x0100
    }
}
