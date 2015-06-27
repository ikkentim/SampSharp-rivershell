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

using System;
using RiverShell.Controllers;
using RiverShell.World;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.World;

namespace RiverShell
{
    public class GameMode : BaseMode
    {
        public static Team BlueTeam = new Team
        {
            Id = 1,
            Color = 0x7777DDFF,
            GameTextTeamName = "~b~BLUE ~w~team",
            Target = new Vector3(2329.4226f, 532.7426f, 0.5862f),
            FixedSpectatePosition = new Vector3(2221.5820f, -273.9985f, 61.7806f),
            FixedSpectateLookAtPosition = new Vector3(2220.9978f, -273.1861f, 61.4606f),
            ResupplyPosition = new Vector3(2140.83f, -235.13f, 7.13f)
        };

        public static Team GreenTeam = new Team
        {
            Id = 2,
            Color = 0x77CC77FF,
            GameTextTeamName = "~g~GREEN ~w~team",
            Target = new Vector3(2135.7368f, -179.8811f, -0.5323f),
            FixedSpectatePosition = new Vector3(2274.8467f, 591.3257f, 30.1311f),
            FixedSpectateLookAtPosition = new Vector3(2275.0503f, 590.3463f, 29.9460f),
            ResupplyPosition = new Vector3(2318.73f, 590.96f, 6.75f)
        };

        public static bool ObjectiveReached;

        protected override void OnInitialized(EventArgs e)
        {
            SetGameModeText("Rivershell");
            ShowPlayerMarkers(0);
            ShowNameTags(true);
            SetWorldTime(17);
            SetWeather(11);
            UsePlayerPedAnimations();
            EnableVehicleFriendlyFire();
            SetNameTagDrawDistance(110.0f);
            DisableInteriorEnterExits();

            // Green classes
            AddPlayerClass(162, new Vector3(2117.0129f, -224.4389f, 8.15f), 0, Weapon.M4, 100, Weapon.MP5, 200,
                Weapon.Sniper, 10);
            AddPlayerClass(157, new Vector3(2148.6606f, -224.3336f, 8.15f), 347.1396f, Weapon.M4, 100, Weapon.MP5, 200,
                Weapon.Sniper, 10);

            // Blue classes
            AddPlayerClass(154, new Vector3(2352.9873f, 580.3051f, 7.7813f), 178.1424f, Weapon.M4, 100, Weapon.MP5, 200,
                Weapon.Sniper, 10);
            AddPlayerClass(138, new Vector3(2281.1504f, 567.6248f, 7.7813f), 163.7289f, Weapon.M4, 100, Weapon.MP5, 200,
                Weapon.Sniper, 10);

            // Objective vehicles
            BlueTeam.TargetVehicle = GtaVehicle.Create(453, new Vector3(2184.7156f, -188.5401f, -0.0239f), 0.0000f, 114,
                1,
                100);
            // gr reefer
            GreenTeam.TargetVehicle = GtaVehicle.Create(453, new Vector3(2380.0542f, 535.2582f, -0.0272f), 178.4999f, 79,
                7,
                100); // bl reefer

            // Green Dhingys
            GtaVehicle.Create(473, new Vector3(2096.0833f, -168.7771f, 0.3528f), 4.5000f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2103.2510f, -168.7598f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2099.4966f, -168.8216f, 0.3528f), 2.8200f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2107.1143f, -168.7798f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2111.0674f, -168.7609f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2114.8933f, -168.7898f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2167.2217f, -169.0570f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2170.4294f, -168.9724f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2173.7952f, -168.9217f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2177.0386f, -168.9767f, 0.3528f), 3.1800f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2161.5786f, -191.9538f, 0.3528f), 89.1000f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2161.6394f, -187.2925f, 0.3528f), 89.1000f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2161.7610f, -183.0225f, 0.3528f), 89.1000f, 114, 1, 100);
            GtaVehicle.Create(473, new Vector3(2162.0283f, -178.5106f, 0.3528f), 89.1000f, 114, 1, 100);

            // Green Mavericks
            GtaVehicle.Create(487, new Vector3(2088.7905f, -227.9593f, 8.3662f), 0.0000f, 114, 1, 100);
            GtaVehicle.Create(487, new Vector3(2204.5991f, -225.3703f, 8.2400f), 0.0000f, 114, 1, 100);

            // Blue Dhingys
            GtaVehicle.Create(473, new Vector3(2370.3198f, 518.3151f, 0.1240f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2362.6484f, 518.3978f, 0.0598f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2358.6550f, 518.2167f, 0.2730f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2366.5544f, 518.2680f, 0.1080f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2354.6321f, 518.1960f, 0.3597f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2350.7449f, 518.1929f, 0.3597f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2298.8977f, 518.4470f, 0.3597f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2295.6118f, 518.3963f, 0.3597f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2292.3237f, 518.4249f, 0.3597f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2289.0901f, 518.4363f, 0.3597f), 180.3600f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2304.8232f, 539.7859f, 0.3597f), 270.5998f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2304.6936f, 535.0454f, 0.3597f), 270.5998f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2304.8245f, 530.3308f, 0.3597f), 270.5998f, 79, 7, 100);
            GtaVehicle.Create(473, new Vector3(2304.8142f, 525.7471f, 0.3597f), 270.5998f, 79, 7, 100);

            // Blue Mavericks
            GtaVehicle.Create(487, new Vector3(2260.2637f, 578.5220f, 8.1223f), 182.3401f, 79, 7, 100);
            GtaVehicle.Create(487, new Vector3(2379.9792f, 580.0323f, 8.0178f), 177.9601f, 79, 7, 100);

            // Green Base Section
            new GlobalObject(9090, new Vector3(2148.64f, -222.88f, -20.60f), new Vector3(0.00f, 0.00f, 179.70f));
            // Green resupply hut
            new GlobalObject(12991, new Vector3(2140.83f, -235.13f, 7.13f), new Vector3(0.00f, 0.00f, -89.94f));

            // Blue Base Section
            new GlobalObject(9090, new Vector3(2317.09f, 572.27f, -20.97f), new Vector3(0.00f, 0.00f, 0.00f));
            // Blue resupply hut
            new GlobalObject(12991, new Vector3(2318.73f, 590.96f, 6.75f), new Vector3(0.00f, 0.00f, 89.88f));

            // General mapping
            new GlobalObject(12991, new Vector3(2140.83f, -235.13f, 7.13f), new Vector3(0.00f, 0.00f, -89.94f));
            new GlobalObject(19300, new Vector3(2137.33f, -237.17f, 46.61f), new Vector3(0.00f, 0.00f, 180.00f));
            new GlobalObject(12991, new Vector3(2318.73f, 590.96f, 6.75f), new Vector3(0.00f, 0.00f, 89.88f));
            new GlobalObject(19300, new Vector3(2325.41f, 587.93f, 47.37f), new Vector3(0.00f, 0.00f, 180.00f));
            new GlobalObject(12991, new Vector3(2140.83f, -235.13f, 7.13f), new Vector3(0.00f, 0.00f, -89.94f));
            new GlobalObject(12991, new Vector3(2318.73f, 590.96f, 6.75f), new Vector3(0.00f, 0.00f, 89.88f));
            new GlobalObject(12991, new Vector3(2140.83f, -235.13f, 7.13f), new Vector3(0.00f, 0.00f, -89.94f));
            new GlobalObject(12991, new Vector3(2318.73f, 590.96f, 6.75f), new Vector3(0.00f, 0.00f, 89.88f));
            new GlobalObject(18228, new Vector3(1887.93f, -59.78f, -2.14f), new Vector3(0.00f, 0.00f, 20.34f));
            new GlobalObject(17031, new Vector3(1990.19f, 541.37f, -22.32f), new Vector3(0.00f, 0.00f, 0.00f));
            new GlobalObject(18227, new Vector3(2000.82f, 494.15f, -7.53f), new Vector3(11.70f, -25.74f, 154.38f));
            new GlobalObject(17031, new Vector3(1992.35f, 539.80f, -2.97f), new Vector3(9.12f, 30.66f, 0.00f));
            new GlobalObject(17031, new Vector3(1991.88f, 483.77f, -0.66f), new Vector3(-2.94f, -5.22f, 12.78f));
            new GlobalObject(17029, new Vector3(2070.57f, -235.87f, -6.05f), new Vector3(-7.20f, 4.08f, 114.30f));
            new GlobalObject(17029, new Vector3(2056.50f, -228.77f, -19.67f), new Vector3(14.16f, 19.68f, 106.56f));
            new GlobalObject(17029, new Vector3(2074.00f, -205.33f, -18.60f), new Vector3(16.02f, 60.60f, 118.86f));
            new GlobalObject(17029, new Vector3(2230.39f, -242.59f, -11.41f), new Vector3(5.94f, 7.56f, 471.24f));
            new GlobalObject(17029, new Vector3(2252.53f, -213.17f, -20.81f), new Vector3(18.90f, -6.30f, -202.38f));
            new GlobalObject(17029, new Vector3(2233.04f, -234.08f, -19.00f), new Vector3(21.84f, -8.88f, -252.06f));
            new GlobalObject(17027, new Vector3(2235.05f, -201.49f, -11.90f), new Vector3(-11.94f, -4.08f, 136.32f));
            new GlobalObject(17029, new Vector3(2226.11f, -237.07f, -2.45f), new Vector3(8.46f, 2.10f, 471.24f));
            new GlobalObject(4368, new Vector3(2433.79f, 446.26f, 4.67f), new Vector3(-8.04f, -9.30f, 61.02f));
            new GlobalObject(4368, new Vector3(2031.23f, 489.92f, -13.20f), new Vector3(-8.04f, -9.30f, -108.18f));
            new GlobalObject(17031, new Vector3(2458.36f, 551.10f, -6.95f), new Vector3(0.00f, 0.00f, 0.00f));
            new GlobalObject(17031, new Vector3(2465.37f, 511.35f, -7.70f), new Vector3(0.00f, 0.00f, 0.00f));
            new GlobalObject(17031, new Vector3(2474.80f, 457.71f, -5.17f), new Vector3(0.00f, 0.00f, 172.74f));
            new GlobalObject(17031, new Vector3(2466.03f, 426.28f, -5.17f), new Vector3(0.00f, 0.00f, 0.00f));
            new GlobalObject(791, new Vector3(2310.45f, -229.38f, 7.41f), new Vector3(0.00f, 0.00f, 0.00f));
            new GlobalObject(791, new Vector3(2294.00f, -180.15f, 7.41f), new Vector3(0.00f, 0.00f, 60.90f));
            new GlobalObject(791, new Vector3(2017.50f, -305.30f, 7.29f), new Vector3(0.00f, 0.00f, 60.90f));
            new GlobalObject(791, new Vector3(2106.45f, -279.86f, 20.05f), new Vector3(0.00f, 0.00f, 60.90f));
            new GlobalObject(706, new Vector3(2159.13f, -263.71f, 19.22f), new Vector3(356.86f, 0.00f, -17.18f));
            new GlobalObject(706, new Vector3(2055.75f, -291.53f, 13.98f), new Vector3(356.86f, 0.00f, -66.50f));
            new GlobalObject(791, new Vector3(1932.65f, -315.88f, 6.77f), new Vector3(0.00f, 0.00f, -35.76f));
            new GlobalObject(790, new Vector3(2429.40f, 575.79f, 10.42f), new Vector3(0.00f, 0.00f, 3.14f));
            new GlobalObject(790, new Vector3(2403.40f, 581.56f, 10.42f), new Vector3(0.00f, 0.00f, 29.48f));
            new GlobalObject(791, new Vector3(2083.44f, 365.48f, 13.19f), new Vector3(356.86f, 0.00f, -1.95f));
            new GlobalObject(791, new Vector3(2040.15f, 406.02f, 13.33f), new Vector3(356.86f, 0.00f, -1.95f));
            new GlobalObject(791, new Vector3(1995.36f, 588.10f, 7.50f), new Vector3(356.86f, 0.00f, -1.95f));
            new GlobalObject(791, new Vector3(2126.11f, 595.15f, 5.99f), new Vector3(0.00f, 0.00f, -35.82f));
            new GlobalObject(791, new Vector3(2188.35f, 588.90f, 6.04f), new Vector3(0.00f, 0.00f, 0.00f));
            new GlobalObject(791, new Vector3(2068.56f, 595.58f, 5.99f), new Vector3(0.00f, 0.00f, 52.62f));
            new GlobalObject(698, new Vector3(2385.32f, 606.16f, 9.79f), new Vector3(0.00f, 0.00f, 34.62f));
            new GlobalObject(698, new Vector3(2309.29f, 606.92f, 9.79f), new Vector3(0.00f, 0.00f, -54.54f));
            new GlobalObject(790, new Vector3(2347.14f, 619.77f, 9.94f), new Vector3(0.00f, 0.00f, 3.14f));
            new GlobalObject(698, new Vector3(2255.28f, 606.94f, 9.79f), new Vector3(0.00f, 0.00f, -92.76f));
            new GlobalObject(4298, new Vector3(2121.37f, 544.12f, -5.74f), new Vector3(-10.86f, 6.66f, 3.90f));
            new GlobalObject(4368, new Vector3(2273.18f, 475.02f, -15.30f), new Vector3(4.80f, 8.10f, 266.34f));
            new GlobalObject(18227, new Vector3(2232.38f, 451.61f, -30.71f), new Vector3(-18.54f, -6.06f, 154.38f));
            new GlobalObject(17031, new Vector3(2228.15f, 518.87f, -16.51f), new Vector3(13.14f, -1.32f, -20.10f));
            new GlobalObject(17031, new Vector3(2230.42f, 558.52f, -18.38f), new Vector3(-2.94f, -5.22f, 12.78f));
            new GlobalObject(17031, new Vector3(2228.97f, 573.62f, 5.17f), new Vector3(17.94f, -15.60f, -4.08f));
            new GlobalObject(17029, new Vector3(2116.67f, -87.71f, -2.31f), new Vector3(5.94f, 7.56f, 215.22f));
            new GlobalObject(17029, new Vector3(2078.66f, -83.87f, -27.30f), new Vector3(13.02f, -53.94f, -0.30f));
            new GlobalObject(17029, new Vector3(2044.80f, -36.91f, -9.26f), new Vector3(-13.74f, 27.90f, 293.76f));
            new GlobalObject(17029, new Vector3(2242.41f, 426.16f, -15.43f), new Vector3(-21.54f, 22.26f, 154.80f));
            new GlobalObject(17029, new Vector3(2220.06f, 450.07f, -34.78f), new Vector3(-1.32f, 10.20f, -45.84f));
            new GlobalObject(17029, new Vector3(2252.49f, 439.08f, -19.47f), new Vector3(-41.40f, 20.16f, 331.86f));
            new GlobalObject(17031, new Vector3(2241.41f, 431.93f, -5.62f), new Vector3(-2.22f, -4.80f, 53.64f));
            new GlobalObject(17029, new Vector3(2141.10f, -81.30f, -2.41f), new Vector3(5.94f, 7.56f, 39.54f));
            new GlobalObject(17031, new Vector3(2277.07f, 399.31f, -1.65f), new Vector3(-2.22f, -4.80f, -121.74f));
            new GlobalObject(17026, new Vector3(2072.75f, -224.40f, -5.25f), new Vector3(0.00f, 0.00f, -41.22f));

            // Ramps
            new GlobalObject(1632, new Vector3(2131.97f, 110.24f, 0.00f), new Vector3(0.00f, 0.00f, 153.72f));
            new GlobalObject(1632, new Vector3(2124.59f, 113.69f, 0.00f), new Vector3(0.00f, 0.00f, 157.56f));
            new GlobalObject(1632, new Vector3(2116.31f, 116.44f, 0.00f), new Vector3(0.00f, 0.00f, 160.08f));
            new GlobalObject(1632, new Vector3(2113.22f, 108.48f, 0.00f), new Vector3(0.00f, 0.00f, 340.20f));
            new GlobalObject(1632, new Vector3(2121.21f, 105.21f, 0.00f), new Vector3(0.00f, 0.00f, 340.20f));
            new GlobalObject(1632, new Vector3(2127.84f, 102.06f, 0.00f), new Vector3(0.00f, 0.00f, 334.68f));
            new GlobalObject(1632, new Vector3(2090.09f, 40.90f, 0.00f), new Vector3(0.00f, 0.00f, 348.36f));
            new GlobalObject(1632, new Vector3(2098.73f, 39.12f, 0.00f), new Vector3(0.00f, 0.00f, 348.36f));
            new GlobalObject(1632, new Vector3(2107.17f, 37.94f, 0.00f), new Vector3(0.00f, 0.00f, 348.36f));
            new GlobalObject(1632, new Vector3(2115.88f, 36.47f, 0.00f), new Vector3(0.00f, 0.00f, 348.36f));
            new GlobalObject(1632, new Vector3(2117.46f, 45.86f, 0.00f), new Vector3(0.00f, 0.00f, 529.20f));
            new GlobalObject(1632, new Vector3(2108.98f, 46.95f, 0.00f), new Vector3(0.00f, 0.00f, 529.20f));
            new GlobalObject(1632, new Vector3(2100.42f, 48.11f, 0.00f), new Vector3(0.00f, 0.00f, 526.68f));
            new GlobalObject(1632, new Vector3(2091.63f, 50.02f, 0.00f), new Vector3(0.00f, 0.00f, 526.80f));

            Console.WriteLine("----------------------------------");
            Console.WriteLine("  Rivershell by Kye 2006-2013");
            Console.WriteLine("  SAMPSHARP PORT");
            Console.WriteLine("----------------------------------");

            base.OnInitialized(e);
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            controllers.Remove<GtaPlayerController>();
            controllers.Add(new PlayerController());

            controllers.Remove<GtaVehicleController>();
            controllers.Add(new VehicleController());

            controllers.Add(new TeamController());
            controllers.Add(new ResupplyController());
            controllers.Add(new ObjectiveController());
        }
    }
}