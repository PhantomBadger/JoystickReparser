using System.Runtime.InteropServices;

namespace JoystickReparser
{
    /// <summary>
    /// Define HARDWARE INPUT struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        internal int uMsg;
        internal short wParamL;
        internal short wParamH;
    }
}
