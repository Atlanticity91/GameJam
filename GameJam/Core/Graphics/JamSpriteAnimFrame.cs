namespace GameJam.Core.Graphics {

    public struct JamSpriteAnimFrame {

        public float Duration;
        public int SpriteSheet;
        public int Row;
        public int Column;

        public JamSpriteAnimFrame( float duration, int row, int column )
            : this( duration, 0, row, column ) { }

        public JamSpriteAnimFrame( float duration, int sprite_sheet, int row, int column ) {
            Duration = duration;
            SpriteSheet = sprite_sheet;
            Row = row;
            Column = column;
        }

    }

}
