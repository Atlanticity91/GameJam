using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam.Core.Graphics {
    
    public struct JamSpriteMeta {

        public int SpriteSheet;
        public int Row;
        public int Column;
        public Color Color;
        public SpriteEffects Effect;

        public JamSpriteMeta( int sprite_sheet, int row, int column, Color color ) {
            SpriteSheet = sprite_sheet;
            Row         = row;
            Column      = column;
            Color       = color;
            Effect      = SpriteEffects.None;
        }

        public JamSpriteMeta( int sprite_sheet, int row, int column ) 
            : this( sprite_sheet, row, column, Color.White )
        { }

        public JamSpriteMeta( int sprite_sheet ) 
            : this( sprite_sheet, 0, 0, Color.White ) 
        { }

    }

}
