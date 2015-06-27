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

using SampSharp.GameMode;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;

namespace RiverShell.World
{
    public class Team : IdentifiedPool<Team>, IIdentifiable
    {
        public Color Color { get; set; }
        public string GameTextTeamName { get; set; }
        public Vector3 Target { get; set; }
        public int TimesCaptured { get; set; }
        public GtaVehicle TargetVehicle { get; set; }
        public Vector3 FixedSpectatePosition { get; set; }
        public Vector3 FixedSpectateLookAtPosition { get; set; }
        public Vector3 ResupplyPosition { get; set; }
        public int Id { get; set; }
    }
}