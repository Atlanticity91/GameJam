using Microsoft.Xna.Framework;

namespace GameJam.Core.Utils {

    public struct JamTranform2D {

        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
        public float LayerDepth;

        public JamTranform2D( Vector2 position, float rotation, Vector2 scale ) {
            Position   = position;
            Rotation   = rotation;
            Scale      = scale;
            LayerDepth = 1.0f;
        }

        public JamTranform2D( Vector2 position ) 
            : this( position, 0.0f, Vector2.One )
        { }

        public JamTranform2D( float rotation )
                : this( Vector2.Zero, rotation, Vector2.One ) 
        { }

    }

}
