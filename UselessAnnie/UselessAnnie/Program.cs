using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.SDK.Core;
using LeagueSharp.SDK.Core.Enumerations;
using LeagueSharp.SDK.Core.Events;
using LeagueSharp.SDK.Core.Extensions;
using LeagueSharp.SDK.Core.UI.IMenu;
using LeagueSharp.SDK.Core.UI.IMenu.Values;
using LeagueSharp.SDK.Core.Wrappers;

namespace YiMultiEyedPerv
{
    class Program
    {
        public static Menu Config;
        public static Spell Q, W, E, R;
        static void Main(string[] args)
        {
            Load.OnLoad += Load_OnLoad;
        }

        static void Load_OnLoad(object sender, EventArgs e)
        {
            Bootstrap.Init(null);

            Config = new Menu("Useless Annie", "Useless Annie", true);

            var combo = Config.Add(new Menu("Combo", "Combo"));
            combo.Add(new MenuBool("useQ", "Use Q", true));
            combo.Add(new MenuBool("UseW", "Use W", true));
            combo.Add(new MenuBool("useE", "Use E", true));
            combo.Add(new MenuBool("useR", "Use R", true));

            var harass = Config.Add(new Menu("harass", "Harass"));
            harass.Add(new MenuBool("useQ", "Use Q", true));
            harass.Add(new MenuBool("useW", "Use W", true));

            var farm = Config.Add(new Menu("farm", "Farming"));
            farm.Add(new MenuSeparator("ss", "Last Hit Settings"));
            farm.Add(new MenuBool("useQLH", "Use Q", true));
            farm.Add(new MenuSeparator("ss2", "WaveClear Settings"));
            farm.Add(new MenuBool("useQWC", "Use Q", true));
            farm.Add(new MenuBool("useWWC", "Use W", true));
            farm.Add(new MenuSeparator("ss3", "Jungle Settings"));
            farm.Add(new MenuBool("useQJC", "Use Q", true));
            farm.Add(new MenuBool("useWJC", "Use W", true));

            Config.Attach();

            Q = new Spell(SpellSlot.Q, 625);
            W = new Spell(SpellSlot.W, 625);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R, 600);

            Game.OnUpdate += Game_OnUpdate;
        }

        static void Game_OnUpdate(EventArgs args)
        {
            if (Orbwalker.ActiveMode == OrbwalkerMode.Orbwalk)
            {
                var target = TargetSelector.GetTarget(Q.Range);
                if (!target.IsValidTarget())
                    return;

            }
        }
    }
}