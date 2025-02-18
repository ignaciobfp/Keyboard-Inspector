﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Keyboard_Inspector {
    static partial class WiitarListener {
        /// <summary>
        /// Enumeration containing HID usage page flags.
        /// </summary>
        public enum HIDUsagePage : ushort {
            /// <summary>Unknown usage page.</summary>
            Undefined = 0x00,
            /// <summary>Generic desktop controls.</summary>
            Generic = 0x01,
            /// <summary>Simulation controls.</summary>
            Simulation = 0x02,
            /// <summary>Virtual reality controls.</summary>
            VR = 0x03,
            /// <summary>Sports controls.</summary>
            Sport = 0x04,
            /// <summary>Games controls.</summary>
            Game = 0x05,
            /// <summary>Keyboard controls.</summary>
            Keyboard = 0x07,
            /// <summary>LED controls.</summary>
            LED = 0x08,
            /// <summary>Button.</summary>
            Button = 0x09,
            /// <summary>Ordinal.</summary>
            Ordinal = 0x0A,
            /// <summary>Telephony.</summary>
            Telephony = 0x0B,
            /// <summary>Consumer.</summary>
            Consumer = 0x0C,
            /// <summary>Digitizer.</summary>
            Digitizer = 0x0D,
            /// <summary>Physical interface device.</summary>
            PID = 0x0F,
            /// <summary>Unicode.</summary>
            Unicode = 0x10,
            /// <summary>Alphanumeric display.</summary>
            AlphaNumeric = 0x14,
            /// <summary>Medical instruments.</summary>
            Medical = 0x40,
            /// <summary>Monitor page 0.</summary>
            MonitorPage0 = 0x80,
            /// <summary>Monitor page 1.</summary>
            MonitorPage1 = 0x81,
            /// <summary>Monitor page 2.</summary>
            MonitorPage2 = 0x82,
            /// <summary>Monitor page 3.</summary>
            MonitorPage3 = 0x83,
            /// <summary>Power page 0.</summary>
            PowerPage0 = 0x84,
            /// <summary>Power page 1.</summary>
            PowerPage1 = 0x85,
            /// <summary>Power page 2.</summary>
            PowerPage2 = 0x86,
            /// <summary>Power page 3.</summary>
            PowerPage3 = 0x87,
            /// <summary>Bar code scanner.</summary>
            BarCode = 0x8C,
            /// <summary>Scale page.</summary>
            Scale = 0x8D,
            /// <summary>Magnetic strip reading devices.</summary>
            MSR = 0x8E
        }

        /// <summary>
        /// Enumeration containing the HID usage values.
        /// </summary>
        public enum HIDUsage : ushort {
            Pointer = 0x01,
            Mouse = 0x02,
            Joystick = 0x04,
            Gamepad = 0x05,
            Keyboard = 0x06,
            Keypad = 0x07,
            SystemControl = 0x80,
            X = 0x30,
            Y = 0x31,
            Z = 0x32,
            RelativeX = 0x33,    
            RelativeY = 0x34,
            RelativeZ = 0x35,
            Slider = 0x36,
            Dial = 0x37,
            Wheel = 0x38,
            HatSwitch = 0x39,
            CountedBuffer = 0x3A,
            ByteCount = 0x3B,
            MotionWakeup = 0x3C,
            VX = 0x40,
            VY = 0x41,
            VZ = 0x42,
            VBRX = 0x43,
            VBRY = 0x44,
            VBRZ = 0x45,
            VNO = 0x46,
            SystemControlPower = 0x81,
            SystemControlSleep = 0x82,
            SystemControlWake = 0x83,
            SystemControlContextMenu = 0x84,
            SystemControlMainMenu = 0x85,
            SystemControlApplicationMenu = 0x86,
            SystemControlHelpMenu = 0x87,
            SystemControlMenuExit = 0x88,
            SystemControlMenuSelect = 0x89,
            SystemControlMenuRight = 0x8A,
            SystemControlMenuLeft = 0x8B,
            SystemControlMenuUp = 0x8C,
            SystemControlMenuDown = 0x8D,
            KeyboardNoEvent = 0x00,
            KeyboardRollover = 0x01,
            KeyboardPostFail = 0x02,
            KeyboardUndefined = 0x03,
            KeyboardaA = 0x04,
            KeyboardzZ = 0x1D,
            Keyboard1 = 0x1E,
            Keyboard0 = 0x27,
            KeyboardLeftControl = 0xE0,
            KeyboardLeftShift = 0xE1,
            KeyboardLeftALT = 0xE2,
            KeyboardLeftGUI = 0xE3,
            KeyboardRightControl = 0xE4,
            KeyboardRightShift = 0xE5,
            KeyboardRightALT = 0xE6,
            KeyboardRightGUI = 0xE7,
            KeyboardScrollLock = 0x47,
            KeyboardNumLock = 0x53,
            KeyboardCapsLock = 0x39,
            KeyboardF1 = 0x3A,
            KeyboardF12 = 0x45,
            KeyboardReturn = 0x28,
            KeyboardEscape = 0x29,
            KeyboardDelete = 0x2A,
            KeyboardPrintScreen = 0x46,
            LEDNumLock = 0x01,
            LEDCapsLock = 0x02,
            LEDScrollLock = 0x03,
            LEDCompose = 0x04,
            LEDKana = 0x05,
            LEDPower = 0x06,
            LEDShift = 0x07,
            LEDDoNotDisturb = 0x08,
            LEDMute = 0x09,
            LEDToneEnable = 0x0A,
            LEDHighCutFilter = 0x0B,
            LEDLowCutFilter = 0x0C,
            LEDEqualizerEnable = 0x0D,
            LEDSoundFieldOn = 0x0E,
            LEDSurroundFieldOn = 0x0F,
            LEDRepeat = 0x10,
            LEDStereo = 0x11,
            LEDSamplingRateDirect = 0x12,
            LEDSpinning = 0x13,
            LEDCAV = 0x14,
            LEDCLV = 0x15,
            LEDRecordingFormatDet = 0x16,
            LEDOffHook = 0x17,
            LEDRing = 0x18,
            LEDMessageWaiting = 0x19,
            LEDDataMode = 0x1A,
            LEDBatteryOperation = 0x1B,
            LEDBatteryOK = 0x1C,
            LEDBatteryLow = 0x1D,
            LEDSpeaker = 0x1E,
            LEDHeadset = 0x1F,
            LEDHold = 0x20,
            LEDMicrophone = 0x21,
            LEDCoverage = 0x22,
            LEDNightMode = 0x23,
            LEDSendCalls = 0x24,
            LEDCallPickup = 0x25,
            LEDConference = 0x26,
            LEDStandBy = 0x27,
            LEDCameraOn = 0x28,
            LEDCameraOff = 0x29,    
            LEDOnLine = 0x2A,
            LEDOffLine = 0x2B,
            LEDBusy = 0x2C,
            LEDReady = 0x2D,
            LEDPaperOut = 0x2E,
            LEDPaperJam = 0x2F,
            LEDRemote = 0x30,
            LEDForward = 0x31,
            LEDReverse = 0x32,
            LEDStop = 0x33,
            LEDRewind = 0x34,
            LEDFastForward = 0x35,
            LEDPlay = 0x36,
            LEDPause = 0x37,
            LEDRecord = 0x38,
            LEDError = 0x39,
            LEDSelectedIndicator = 0x3A,
            LEDInUseIndicator = 0x3B,
            LEDMultiModeIndicator = 0x3C,
            LEDIndicatorOn = 0x3D,
            LEDIndicatorFlash = 0x3E,
            LEDIndicatorSlowBlink = 0x3F,
            LEDIndicatorFastBlink = 0x40,
            LEDIndicatorOff = 0x41,
            LEDFlashOnTime = 0x42,
            LEDSlowBlinkOnTime = 0x43,
            LEDSlowBlinkOffTime = 0x44,
            LEDFastBlinkOnTime = 0x45,
            LEDFastBlinkOffTime = 0x46,
            LEDIndicatorColor = 0x47,
            LEDRed = 0x48,
            LEDGreen = 0x49,
            LEDAmber = 0x4A,
            LEDGenericIndicator = 0x3B,
            TelephonyPhone = 0x01,
            TelephonyAnsweringMachine = 0x02,
            TelephonyMessageControls = 0x03,
            TelephonyHandset = 0x04,
            TelephonyHeadset = 0x05,
            TelephonyKeypad = 0x06,
            TelephonyProgrammableButton = 0x07,
            SimulationRudder = 0xBA,
            SimulationThrottle = 0xBB
        }

        /// <summary>Enumeration containing flags for a raw input device.</summary>
        [Flags()]
        public enum RawInputDeviceFlags {
            /// <summary>No flags.</summary>
            None = 0,
            /// <summary>If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from a device which matches the top level collection.</summary>
            Remove = 0x00000001,
            /// <summary>If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC whose usage page is already specified with PageOnly.</summary>
            Exclude = 0x00000010,
            /// <summary>If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that Usage must be zero. To exclude a particular top level collection, use Exclude.</summary>
            PageOnly = 0x00000020,
            /// <summary>If set, this prevents any devices specified by UsagePage or Usage from generating legacy messages. This is only for the mouse and keyboard.</summary>
            NoLegacy = 0x00000030,
            /// <summary>If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that WindowHandle must be specified.</summary>
            InputSink = 0x00000100,
            /// <summary>If set, the mouse button click does not activate the other window.</summary>
            CaptureMouse = 0x00000200,
            /// <summary>If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. NoHotKeys can be specified even if NoLegacy is not specified and WindowHandle is NULL.</summary>
            NoHotKeys = 0x00000200,
            /// <summary>If set, application keys are handled.  NoLegacy must be specified.  Keyboard only.</summary>
            AppKeys = 0x00000400
        }

        /// <summary>Value type for raw input devices.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTDEVICE {
            /// <summary>Top level collection Usage page for the raw input device.</summary>
            public HIDUsagePage UsagePage;
            /// <summary>Top level collection Usage for the raw input device. </summary>
            public HIDUsage Usage;
            /// <summary>Mode flag that specifies how to interpret the information provided by UsagePage and Usage.</summary>
            public RawInputDeviceFlags Flags;
            /// <summary>Handle to the target device. If NULL, it follows the keyboard focus.</summary>
            public IntPtr WindowHandle;
        }

        /// <summary>Function to register a raw input device.</summary>
        /// <param name="pRawInputDevices">Array of raw input devices.</param>
        /// <param name="uiNumDevices">Number of devices.</param>
        /// <param name="cbSize">Size of the RAWINPUTDEVICE structure.</param>
        /// <returns>TRUE if successful, FALSE if not.</returns>
        [DllImport("user32.dll")]
        public static extern bool RegisterRawInputDevices([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);

        /// <summary>
        /// Enumeration contanining the command types to issue.
        /// </summary>
        public enum RawInputCommand {
            /// <summary>
            /// Get input data.
            /// </summary>
            Input = 0x10000003,
            /// <summary>
            /// Get header data.
            /// </summary>
            Header = 0x10000005
        }

        /// <summary>
        /// Value type for a raw input header.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RawInputHeader {
            /// <summary>Type of device the input is coming from.</summary>
            public int Type;
            /// <summary>Size of the packet of data.</summary>
            public int Size;
            /// <summary>Handle to the device sending the data.</summary>
            public IntPtr Device;
            /// <summary>wParam from the window message.</summary>
            public IntPtr wParam;
        }

        /// <summary>
        /// Function to retrieve raw input data.
        /// </summary>
        /// <param name="hRawInput">Handle to the raw input.</param>
        /// <param name="uiCommand">Command to issue when retrieving data.</param>
        /// <param name="pData">Raw input data.</param>
        /// <param name="pcbSize">Number of bytes in the array.</param>
        /// <param name="cbSizeHeader">Size of the header.</param>
        /// <returns>0 if successful if pData is null, otherwise number of bytes if pData is not null.</returns>
        [DllImport("user32.dll")]
        public static extern bool GetRawInputData(IntPtr hRawInput, RawInputCommand uiCommand, byte[] pData, out int pcbSize, int cbSizeHeader);

        const int WM_INPUT = 0x00FF;
    }
}
