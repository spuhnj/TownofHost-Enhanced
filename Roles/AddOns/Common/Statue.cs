using System.Linq;
using UnityEngine;
using AmongUs.GameOptions;
using static TOHE.Options;

namespace TOHE.Roles.AddOns.Common
{
    public static class Statue
    {
        private static readonly int Id = 27800;

        public static OptionItem CanBeOnCrew;
        public static OptionItem CanBeOnImp;
        public static OptionItem CanBeOnNeutral;
        public static OptionItem StatueSpeed;
        public static OptionItem StatueFreezeRadius;
        public static void SetupCustomOption() 
        {
            Options.SetupAdtRoleOptions(Id, CustomRoles.Statue, canSetNum: true, tab: TabGroup.Addons);
            CanBeOnImp = BooleanOptionItem.Create(Id + 11, "ImpCanBeStatue", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Statue]);
            CanBeOnCrew = BooleanOptionItem.Create(Id + 12, "CrewCanBeStatue", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Statue]);
            CanBeOnNeutral = BooleanOptionItem.Create(Id + 13, "NeutralCanBeStatue", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Statue]);
            StatueSpeed = FloatOptionItem.Create(Id + 14, "StatueSpeed", new(0f, 5f, 0f), 0.75f, TabGroup.Addons, false).SetParent(CustomRoleSpawnChances[CustomRoles.Statue])
            .SetValueFormat(OptionFormat.Multiplier);
            StatueFreezeRadius = FloatOptionItem.Create(Id + 15, "StatueFreezeRadius", new(0.25f, 5f, 0.25f), 1.5f, TabGroup.Addons, false).SetParent(CustomRoleSpawnChances[CustomRoles.Statue])
            .SetValueFormat(OptionFormat.Multiplier);
        }

        private static void OnFixedUpdate(PlayerControl target)
        {
            if (Main.AllAlivePlayerControls.Any(x =>
            x.PlayerId != target.PlayerId
            && Vector2.Distance(x.transform.position, target.transform.position) < StatueFreezeRadius.GetFloat()))
            {
                target.MarkDirtySettings();
                var tmpSpeed = Main.AllPlayerSpeed[target.PlayerId];
                Main.AllPlayerSpeed[target.PlayerId] = StatueSpeed.GetFloat();
            }
        }
    }
}