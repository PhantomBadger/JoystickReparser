using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JoystickReparser
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"====================================");
            Console.WriteLine($"Joystick Reparser - PhantomBadger 2023");
            Console.WriteLine($"====================================");
            Console.WriteLine($"This program is a fairly jank solution to take defined inputs from a Joystick (A DDR Pad in this case)");
            Console.WriteLine($"and simulate the pressing of a normal keyboard key when received.");
            Console.WriteLine($"This was used to allow a stream overlay to detect inputs from the pad and display them through " +
                $"an existing 'input-overlay' plugin specialised for keyboard inputs");
            Console.WriteLine($"====================================");
            Console.WriteLine($"Twitter - @PhantomBadger_");
            Console.WriteLine($"Twitch - PhantomBadger");
            Console.WriteLine($"====================================");

            try
            {
                // Get the target joystick
                var joystickParser = new JoystickParser();
                Joystick joystick = joystickParser.GetFirstJoystick();

                // Identify our button remappings
                Dictionary<int, ButtonRemap> buttonRemaps = new Dictionary<int, ButtonRemap>()
                {
                    {0, new ButtonRemap(ScanCodeShort.F22) }, // LEFT
                    {1, new ButtonRemap(ScanCodeShort.F24) }, // DOWN
                    {2, new ButtonRemap(ScanCodeShort.F21) }, // UP
                    {3, new ButtonRemap(ScanCodeShort.F23) }, // RIGHT
                    {6, new ButtonRemap(ScanCodeShort.F20) }, // B
                    {7, new ButtonRemap(ScanCodeShort.F19) }, // A
                };

                // Continually poll the Joystick, calling the button remappings when appropriate
                while (true)
                {
                    joystickParser.PollJoystickForInputs(joystick, buttonRemaps);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
