using BepInEx.Configuration;
using CSync.Lib;
using CSync.Util;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AngryTulipSnakes.Configs
{
    [DataContract]
    internal class ATSConfigs : SyncedConfig<ATSConfigs>
    {
        [DataMember]
        internal SyncedEntry<int> YOINK_POWER_MULTIPLPLIER;
        [DataMember]
        internal SyncedEntry<int> DROP_HEIGHT;

        internal ATSConfigs(ConfigFile cfg) : base(MyPluginInfo.PLUGIN_NAME)
        {
            ConfigManager.Register(this);

            YOINK_POWER_MULTIPLPLIER = cfg.BindSyncedEntry("LiftingPower", "lifting power multiplier", 5, "How fast a player gets yoinked.");
            DROP_HEIGHT = cfg.BindSyncedEntry("LiftingPower", "max flight height", 65, "The height from where a player is dropped.");
        }

    }
}
