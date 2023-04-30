using GameJam.Core;
using GameJam.Core.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameJam {

    public delegate void JamCallback( JamGame game );

    public class JamGame : Game {

        private GraphicsDeviceManager _graphics;

        private JamInput _inputs;
        private JamAudio _audio;
        private JamCanvas _canvas;
        private JamRenderer _renderer;

        public JamGame( ) {
            _graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void Resize( int width, int height ) {
            _graphics.PreferredBackBufferWidth  = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges( );

            _canvas.Resize( width, height );
            _renderer.Resize( width, height );
        }

        public void ToggleMouse( bool is_visible ) 
            => IsMouseVisible = is_visible;

        protected override void LoadContent( ) {
            _inputs   = new JamInput( );
            _audio    = new JamAudio( Content );
            _canvas   = new JamCanvas( );
            _renderer = new JamRenderer( GraphicsDevice, Content );
        }

        protected override void Update( GameTime game_time ) {
            _inputs.Tick( );
            _canvas.Tick( this, game_time );
        }

        protected override void Draw( GameTime game_time ) {
            _renderer.Clear( );

            _canvas.Display( _renderer );
        }

        public JamInput GetInputs( ) => _inputs;

        public JamAudio GetAudio( ) => _audio;

        public JamCanvas GetCanvas( ) => _canvas;

        public JamRenderer GetRenderer( ) => _renderer;

    }

}
