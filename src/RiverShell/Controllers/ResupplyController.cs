// RiverShell
// Copyright 2015 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using RiverShell.World;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Natives;

namespace RiverShell.Controllers
{
    public class ResupplyController : IEventListener
    {
        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerUpdate += (sender, args) =>
            {
                var player = sender as Player;
                if (player.IsInRangeOfPoint(2.5f, GameMode.BlueTeam.ResupplyPosition))
                {
                    Resupply(player);
                }
            };
        }

        private void Resupply(Player player)
        {
            //Check if we haven't resupplied recently
            if (player.LastResupplyTime != 0 &&
                (Native.GetTickCount() - player.LastResupplyTime) <= Config.ResupplyTime*1000) return;

            //Resupply
            player.LastResupplyTime = Native.GetTickCount();

            player.ResetWeapons();
            player.GiveWeapon(Weapon.M4, 100);
            player.GiveWeapon(Weapon.MP5, 200);
            player.GiveWeapon(Weapon.Sniper, 10);

            player.Health = 100.0f;
            player.Armour = 100.0f;

            player.GameText("Resupplied", 2000, 5);
            player.PlaySound(1150);
        }
    }
}