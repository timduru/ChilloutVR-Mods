using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_RC.Systems.Camera;
using MelonLoader;

namespace KAT
{
    class CameraUtils
    {
        private static bool initialized = false;

        public static void Init()
        {
            if (CameraUtils.initialized) return;

            PortableCameraSetting setting = PortableCamera.Instance.@interface.AddAndGetSetting(PortableCameraSettingType.Bool);


            setting.BoolChanged = CameraUtils.setRes4k;
            setting.SettingName = "4kRes";
            setting.DisplayName = "4k Resolution";
            setting.OriginType = typeof(PortableCamera);
            setting.DefaultValue = (object)false;
            setting.Load();
            if (setting.enabled)
            {
                MelonLogger.Msg("4K enabled");
            //    PortableCamera.Instance.ChangeResolution();
            }

            CameraUtils.initialized = true;
        }

        public static void setRes4k(bool b)
        {
            MelonLogger.Msg("setRes4k " +  (b?"Enabled":"Disabled"));

            PortableCamera.Instance.ChangeResolution();
        }
    }
}
