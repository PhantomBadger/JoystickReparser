using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JoystickReparser.InputSpoofer;

namespace JoystickReparser
{
    /// <summary>
    /// A class responsible for remapping a given joystick button index into a key code
    /// </summary>
    public class ButtonRemap
    {
        private readonly ScanCodeShort inputToSpoof;

        private bool previousButtonState;

        /// <summary>
        /// A constructor for creating a <see cref="ButtonRemap"/>
        /// </summary>
        /// <param name="inputToSpoof">The <see cref="ScanCodeShort"/> to invoke when the button is held</param>
        public ButtonRemap(ScanCodeShort inputToSpoof)
        {
            this.inputToSpoof = inputToSpoof;

            previousButtonState = false;
        }

        /// <summary>
        /// Handles the joystick button state, spoofing the appropriate input
        /// </summary>
        /// <param name="joystickButtonState">The current state of the joystick button, <see cref="true"/> if down, <see cref="false"/> if up</param>
        public void HandleButtonState(bool joystickButtonState)
        {
            if (joystickButtonState && !previousButtonState)
            {
                // Down Press
                previousButtonState = true;
                INPUT[] inputs = new INPUT[1];
                INPUT input = new INPUT();
                input.type = 1;
                input.U.ki.wScan = inputToSpoof;
                input.U.ki.dwFlags = KeyEventFlags.SCANCODE;
                inputs[0] = input;
                SendInput(1, inputs, INPUT.Size);
            }
            if (!joystickButtonState && previousButtonState)
            {
                // Up Press
                previousButtonState = false;
                INPUT[] inputs = new INPUT[1];
                INPUT input = new INPUT();
                input.type = 1;
                input.U.ki.wScan = inputToSpoof;
                input.U.ki.dwFlags = KeyEventFlags.KEYUP | KeyEventFlags.SCANCODE;
                inputs[0] = input;
                SendInput(1, inputs, INPUT.Size);
            }
        }
    }
}
