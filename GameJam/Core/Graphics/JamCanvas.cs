using GameJam.Core.Utils;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameJam.Core.Graphics {

    public class JamCanvas {

        private Vector2 _global_scale;
        private List<JamCanvasElement> _elements;

        public JamCanvas( ) {
            _global_scale = Vector2.One;
            _elements     = new List<JamCanvasElement>( );
        }

        public JamCanvas SetGlobalScale( float x, float y )
            => SetGlobalScale( new Vector2( x, y ) );

        public JamCanvas SetGlobalScale( Vector2 scale ) {
            _global_scale = scale;

            return this;
        }

        public void Resize( int width, int height ) { 
        }

        public T Create<T>( JamGame game, JamTranform2D? tranform ) where T : JamCanvasElement, new( ) {
            var element = new T( );

            if ( element != default( T ) ) {
                element.Create( this, game, tranform );

                _elements.Add( element );
            }

            return element;
        }

        public T Create<T>( JamGame game ) where T : JamCanvasElement, new( )
            => Create<T>( game, null );

        public void Clear( JamGame game ) {
            foreach ( var element in _elements )
                element.Destroy( this, game );

            _elements.Clear( );
        }

        public void Destroy( JamGame game, int element_id ) {
            if ( element_id > -1 && element_id < _elements.Count ) {
                _elements[ element_id ].Destroy( this, game );

                _elements.RemoveAt( element_id );
            }
        }

        public void Destroy( JamGame game, JamCanvasElement element ) {
            if ( element != null && _elements.Contains( element ) ) {
                element.Destroy( this, game );

                _elements.Remove( element );
            }
        }

        public void Tick( JamGame game, GameTime game_time ) {
            foreach ( var element in _elements )
                element.Tick( this, game, game_time );
        }

        public void Display( JamRenderer renderer ) {
            renderer.Begin2D( _global_scale );

            foreach ( var element in _elements )
                element.Draw( this, renderer );

            renderer.End2D( );
        }

        public int GetNextHandle( ) => _elements.Count; 

        public Vector2 GetGlobalScale( ) => _global_scale;

        public JamCanvasElement GetElement( int element_id ) 
            => element_id < _elements.Count ? _elements[ element_id ] : null;

        public T GetElementAs<T>( int element_id ) where T : JamCanvasElement 
            => (T)GetElement( element_id );

        public IEnumerator<JamCanvasElement> GetElements( ) => _elements.GetEnumerator( );

    }

}
