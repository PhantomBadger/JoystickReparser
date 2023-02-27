using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoystickReparser
{
    /// <summary>
    /// A class responsibly for parsing the input from an attached joystick
    /// </summary>
    public class JoystickParser
    {
        private readonly DirectInput directInput;

        /// <summary>
        /// Constructor for creating a <see cref="JoystickParser"/>
        /// </summary>
        public JoystickParser()
        {
            directInput = new DirectInput();
        }

        /// <summary>
        /// Gets the first <see cref="Joystick"/> it finds, if it can't find any, returns <see langword="null"/>
        /// </summary>
        /// <returns>Either the first <see cref="Joystick"/> or <see langword="null"/> if none are found</returns>
        public Joystick GetFirstJoystick()
        {
            Joystick joystick = null;
            if (directInput == null)
            {
                return joystick;
            }

            // Get all joystick devices
            var joysticks = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);
            if (joysticks.Count <= 0)
            {
                Console.WriteLine("No Joysticks!");
                return joystick;
            }

            // Get the first valid joystick and then exit
            foreach (var device in joysticks)
            {
                if (device == null)
                {
                    continue;
                }

                Console.WriteLine($"JOYSTICK: {device.ProductName} - {device.InstanceName} - {device.Subtype}");

                // Create a reference using the GUID
                // Call acquire otherwise we won't have permission to poll the device
                joystick = new Joystick(directInput, device.InstanceGuid);
                joystick.Acquire();
                break;
            }

            return joystick;
        }

        /// <summary>
        /// Polls the provided joystick, and invokes the callback with the state of the buttons found
        /// </summary>
        /// <param name="joystick">The <see cref="Joystick"/> to poll</param>
        /// <param name="buttonRemapCallbacks">A collection of <see cref="ButtonRemap"/> to be called if a matching input is found</param>
        public void PollJoystickForInputs(Joystick joystick, Dictionary<int, ButtonRemap> buttonRemapCallbacks)
        {
            if (joystick == null || buttonRemapCallbacks == null)
            {
                return;
            }
         
            joystick.Poll();
            JoystickState state = joystick.GetCurrentState();

            for (int i = 0; i < state.Buttons.Length; i++)
            {
                // Invoke the callback for the current button number & it's state
                if (buttonRemapCallbacks.ContainsKey(i))
                {
                    buttonRemapCallbacks[i].HandleButtonState(state.Buttons[i]);
                }
            }
        }
    }
}
