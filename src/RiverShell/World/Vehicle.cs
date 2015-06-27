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

using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace RiverShell.World
{
    public class Vehicle : GtaVehicle
    {
        public Vehicle(int id) : base(id)
        {
        }

        public override void OnStreamIn(PlayerEventArgs e)
        {
            var player = e.Player as Player;

            if (this == GameMode.BlueTeam.TargetVehicle)
                SetParametersForPlayer(player, true, player.Team == GameMode.GreenTeam);
            else if (this == GameMode.GreenTeam.TargetVehicle)
                SetParametersForPlayer(player, true, player.Team == GameMode.BlueTeam);

            base.OnStreamIn(e);
        }
    }
}