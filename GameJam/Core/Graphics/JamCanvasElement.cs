using GameJam.Core.Utils;
using Microsoft.Xna.Framework;

namespace GameJam.Core.Graphics {

    public abstract class JamCanvasElement {

        public abstract void Create( JamCanvas canvas, JamGame game, JamTranform2D? transform );

        public abstract void Tick( JamCanvas canvas, JamGame game, GameTime game_time );

        public abstract void Draw( JamCanvas canvas, JamRenderer renderer );

        public abstract void Destroy( JamCanvas canvas, JamGame game );

    }

}
