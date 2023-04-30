using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam.Core.Graphics {
    
    public class JamSpriteSheet {

        private Texture2D _texture;
        private Rectangle[] _sprites;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public int Count => _sprites.Length;

        public JamSpriteSheet( Texture2D texture, int rows, int columns ) {
            _texture = texture;
            _sprites = new Rectangle[ rows * columns ];
            Rows     = rows;
            Columns  = columns;

            GrabSprites( );
        }

        public JamSpriteSheet( Texture2D texture )
            : this( texture, 1, 1 ) 
        { }

        private void GrabSprites( ) {
            var spr_width  = _texture.Width / Columns;
            var spr_height = _texture.Height / Rows;

            for ( var y = 0; y < Rows; y++ ) {
                for ( var x = 0; x < Columns; x++ )
                    _sprites[ y * Columns + x ] = new Rectangle( x * spr_width, y * spr_height, spr_width, spr_height );
            }
        }

        public bool GetIsValid( Point sprite )
            => GetIsValid( sprite.X, sprite.Y );

        public bool GetIsValid( int row, int column )
            => row > -1 && row < Rows && column > -1 && column < Columns;

        public Rectangle this[ int sprite_id ] {
            get => sprite_id < _sprites.Length ? _sprites[ sprite_id ] : Rectangle.Empty;
            set {
                if (sprite_id < _sprites.Length )
                    _sprites[ sprite_id ] = value;
            }
        }

        public Rectangle this[ int row, int column ]
            => GetIsValid( row, column ) ? this[ row * Columns + column ] : Rectangle.Empty;

        public static implicit operator Texture2D( JamSpriteSheet sheet ) => sheet._texture;

    }

}
