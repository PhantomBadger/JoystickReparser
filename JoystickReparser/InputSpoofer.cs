using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JoystickReparser
{
    /// <summary>
    /// A class which wraps a call to an external SendInput command via user32.dll
    /// </summary>
    public class InputSpoofer
    {
        /// <summary>
        /// Hookup to the external SendInput function from user32
        /// </summary>
        [DllImport("user32.dll")]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);
    }
}
