namespace dbox
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.Runtime.InteropServices;

    // Invoke calls to the DboxSdkWrapper.dll
    static public class DboxSdkWrapper
    {
        // D-BOX Manager Methods
        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int InitializeDbox();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int TerminateDbox();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int OpenDbox();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int CloseDbox();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int StartDbox();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int StopDbox();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int ResetState();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern bool IsInitialized();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern bool IsOpened();

        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern bool IsStarted();

        // FRAME_UPDATES
        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int PostFrameUpdate([MarshalAs(UnmanagedType.Struct)] DboxStructs.FrameUpdate oFrameUpdate);

        // CONFIGURATION_UPDATES
        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int PostConfigUpdate([MarshalAs(UnmanagedType.Struct)] DboxStructs.ConfigUpdate oConfigUpdate);

        // ACTIONS_WITH_DATA
        [DllImport(@"DboxSdkWrapper.DLL")]
        public static extern int PostSimConfig([MarshalAs(UnmanagedType.Struct)] DboxStructs.SimConfig oSimConfig);

    }

    // DBOX FRAME_UPDATE, CONFIG_UPDATE and ACTION_WITH_DATA Structures definitions 
    public class DboxStructs
    {

        // FRAME_UPDATE Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct FrameUpdate
        {
            public float Roll;
            public float Pitch;
            public float Heave;
            public float EngineRpm;
            public float EngineTorque;
        }

        // SIM_CONFIG Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct SimConfig
        {
            public float MasterGain;
            public float MasterSpectrum;
        }

        // CONFIGURATION_UPDATE Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct ConfigUpdate
        {
            public float EngineRpmIdle;
            public float EngineRpmMax;
            public float EngineTorqueMax;
        }

    }
}