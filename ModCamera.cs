using MelonLoader;
using System.Collections;
using HarmonyLib;
using ABI_RC.Systems.Camera;


namespace KAT
{
    public static class ModBuildInfo
    {
        public const string Version = "1.0.0";
        public const string Name = "KATCamera";
        public const string Author = "Timduru";
        public const string Company = null;
        public const string GameDeveloper = "Alpha Blend Interactive";
        public const string Game = "ChilloutVR";
        public const string DownloadLink = "";
    }


    public class ModCamera : MelonMod
    {
        private const string ModCategory = ModBuildInfo.Name;
        public static bool scenesInit = false;


        static ModCamera()
        {
        }


        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Mod loaded.");
/*            // Add Melon main settings preferences
            MelonPreferences.CreateCategory(ModCategory, ModBuildInfo.Name);

            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.instaMirrorDistance, Settings.Melon.instaMirrorDistance, "InstaMirror Distance");
            //            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.instaMirrorElevation, Settings.Melon.instaMirrorElevation, "InstaMirror Elevation");
            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.instaMirrorSize, Settings.Melon.instaMirrorSize, "InstaMirror Screen Size");

            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.SelfieFarDistance, Settings.Melon.SelfieFarDistance, "SelfieFar Distance");
            //            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.SelfieFarElevation, Settings.Melon.SelfieFarElevation, "SelfieFar Elevation");
            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.SelfieFarSize, Settings.Melon.SelfieFarSize, "SelfieFar Screen Size");

            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.SelfieDistance, Settings.Melon.SelfieDistance, "Selfie Distance");
            //            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.SelfieElevation, Settings.Melon.SelfieElevation, "Selfie Elevation");
            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.SelfieSize, Settings.Melon.SelfieSize, "Selfie Screen Size");

            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.camToHeadDistance, Settings.Melon.camToHeadDistance, "CamToHead Distance");
            MelonPreferences.CreateEntry(ModCategory, Settings.Melon.keys.enlargeShrinkRatio, Settings.Melon.enlargeShrinkRatio, "Enlarge/Shrink Screen Ratio");

            OnPreferencesSaved();

*/
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "Login")
            {
                MelonCoroutines.Start(Setup());
            } 
        }

        public override void OnPreferencesSaved()
        {
/*            Settings.Melon.camToHeadDistance = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.camToHeadDistance);
            Settings.Melon.enlargeShrinkRatio = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.enlargeShrinkRatio);

            Settings.Melon.instaMirrorDistance = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.instaMirrorDistance);
            Settings.Melon.instaMirrorElevation = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.instaMirrorElevation);
            Settings.Melon.instaMirrorSize = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.instaMirrorSize);

            Settings.Melon.SelfieFarDistance = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.SelfieFarDistance);
            Settings.Melon.SelfieFarElevation = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.SelfieFarElevation);
            Settings.Melon.SelfieFarSize = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.SelfieFarSize);

            Settings.Melon.SelfieDistance = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.SelfieDistance);
            Settings.Melon.SelfieElevation = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.SelfieElevation);
            Settings.Melon.SelfieSize = MelonPreferences.GetEntryValue<float>(ModCategory, Settings.Melon.keys.SelfieSize);
            */

        }

        private IEnumerator Setup()
        {
            scenesInit = true;
            MelonLogger.Msg("Setup");

            HarmonyInstance.Patch(
              typeof(PortableCamera).GetMethod(nameof(PortableCamera.UpdateOptionsDisplay)),
              prefix: new HarmonyMethod(typeof(CameraUtils).GetMethod(nameof(CameraUtils.Init)))
            );


            yield return null;
        }

        public override void OnUpdate()
        {
            // Take pic

            /*            if (Input.GetKeyDown(KeyCode.KeypadPlus))
                        {
                            if (Settings.cameraEnabled) CameraUtils.TakePicture(0);
                        }
             */
        }

    }
}
