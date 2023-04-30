using GameJam.Core.Graphics;
using GameJam.Core.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameJam.Core {
    
    public class JamRenderer {

        private GraphicsDevice _device;
        private ContentManager _content;
        private SpriteBatch _sprite_batch;
        private Color _refresh;
        private List<JamSpriteSheet> _sprite_sheets;
        private List<JamSpriteAnim> _sprite_anims;
        private List<JamModel> _models;
        private List<Effect> _shaders;

        public JamRenderer( GraphicsDevice device, ContentManager content ) {
            _device        = device;
            _content       = content;
            _sprite_batch  = new SpriteBatch( device );
            _refresh       = Color.DarkGray;
            _sprite_sheets = new List<JamSpriteSheet>( );
            _sprite_anims  = new List<JamSpriteAnim>( );
            _models        = new List<JamModel>( );
            _shaders       = new List<Effect>( );
        }

        public void Resize( int width, int height ) { 
        }

        public bool LoadSpriteSheet( string path, int rows, int columns ) {
            var state = !string.IsNullOrEmpty( path ) && rows > 0 && columns > 0;

            if ( state ) { 
                var texture = _content.Load<Texture2D>( path );

                state = texture != null;

                if ( state )
                    _sprite_sheets.Add( new JamSpriteSheet( texture, rows, columns ) );
            }

            return state;
        }

        public JamSpriteAnim CreateSpriteAnim( bool use_multi_sheet, int length ) {
            var anim = new JamSpriteAnim( use_multi_sheet, length );

            if ( anim != null )
                _sprite_anims.Add( anim );

            return anim;
        }

        public JamSpriteAnim CreateSpriteAnim( int length )
            => CreateSpriteAnim( false, length );

        public bool LoadShader( string path ) {
            var state = !string.IsNullOrEmpty( path );

            if ( state ) {
                var effect = _content.Load<Effect>( path );

                state = effect != null;

                if ( state )
                    _shaders.Add( effect );
            }

            return state;
        }

        public void Tick( JamGame game, GameTime game_time, ref JamSpriteMeta sprite_meta, ref JamSpriteAnimMeta anim_meta ) {
            if ( anim_meta.Animation < _sprite_anims.Count && anim_meta.IsPlaying ) {
                anim_meta.Time += (float)game_time.ElapsedGameTime.TotalSeconds;

                var animation    = _sprite_anims[ anim_meta.Animation ];

                if ( anim_meta.Time / animation[ anim_meta.Frame ]?.Duration >= 1.0f ) {
                    anim_meta.Time   = 0.0f;
                    anim_meta.Frame += 1;

                    if ( anim_meta.Frame == animation?.Length )
                        anim_meta.Frame = 0;

                    if ( anim_meta.OnChange != null )
                        anim_meta.OnChange.Invoke( game, anim_meta.Frame > 0 ? anim_meta.Frame - 1 : animation.Length - 1, anim_meta.Frame );

                    if ( animation.UseMultiSheet )
                        sprite_meta.SpriteSheet = (int)animation[ anim_meta.Frame ]?.SpriteSheet;

                    sprite_meta.Row    = (int)animation[ anim_meta.Frame ]?.Row;
                    sprite_meta.Column = (int)animation[ anim_meta.Frame ]?.Column;
                }
            }
        }

        public void Begin3D( ) { }

        public void Draw3D( ) { }

        public void End3D( ) { }

        public void Begin2D( Vector2 scale ) {
            var matrix = Matrix.CreateScale( scale.X, scale.Y, 1.0f );

            _sprite_batch.Begin( transformMatrix : matrix );
        }

        public void Draw2D( JamSpriteMeta sprite, JamTranform2D tranform ) {
            var sheet = _sprite_sheets[ sprite.SpriteSheet ];

            _sprite_batch.Draw( sheet, tranform.Position, sheet[ sprite.Row, sprite.Column ], sprite.Color, tranform.Rotation, Vector2.Zero, tranform.Scale, sprite.Effect, tranform.LayerDepth );
        }

        public void End2D( ) => _sprite_batch.End( );

        public void Clear( ) => _device.Clear( _refresh );

    }

}
