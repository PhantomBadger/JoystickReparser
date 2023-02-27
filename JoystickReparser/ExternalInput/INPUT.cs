using System.Runtime.InteropServices;

namespace JoystickReparser
{
    /// <summary>
    /// Define the layout of the INPUT struct used
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        internal uint type;
        internal InputUnion U;
        internal static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }

    /// <summary>
    /// Define the layout of the InputUnion struct used
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)]
        internal MOUSEINPUT mi;
        [FieldOffset(0)]
        internal KEYBDINPUT ki;
        [FieldOffset(0)]
        internal HARDWAREINPUT hi;
    }
}
