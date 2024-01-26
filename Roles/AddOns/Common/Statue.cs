using System.Linq;
using UnityEngine;

namespace TOHE.Roles.AddOns.Common
{
    public static class Statue
    {
        private static readonly int Id = 27800;

        public static OptionItem CanBeOnCrew;
        public static OptionItem CanBeOnImp;
        public static OptionItem CanBeOnNeutral;
        public static void SetupCustomOption() 
        {
            Options.SetupAdtRoleOptions(Id, CustomRoles.Statue, canSetNum: true, tab: TabGroup.Addons);
            CanBeOnImp = BooleanOptionItem.Create(Id + 11, "ImpCanBeStatue", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Statue]);
            CanBeOnCrew = BooleanOptionItem.Create(Id + 12, "CrewCanBeStatue", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Statue]);
            CanBeOnNeutral = BooleanOptionItem.Create(Id + 13, "NeutralCanBeStatue", true, TabGroup.Addons, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Statue]);
        }
    }
}