// SampSharp
// Copyright (C) 2014 Tim Potze
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org>

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