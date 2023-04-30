using Microsoft.Xna.Framework.Input;

namespace GameJam.Core.Inputs {
    
    public class JamKeyboard : JamInputDevice {

        private KeyboardState _prev;
        private KeyboardState _next;

        public JamKeyboard( ) { }

        public void Tick( ) {
            _prev = _next;
            _next = Keyboard.GetState( );
        }

        public bool GetIsInput( int input, JamInputStates state ) {
            var result = false;
            var key    = (Keys)input;

            switch ( state ) {
                case JamInputStates.Pressed  : result = _prev.IsKeyUp( key )   && _next.IsKeyDown( key ); break;
                case JamInputStates.Released : result = _prev.IsKeyDown( key ) && _next.IsKeyUp( key );   break;
                case JamInputStates.Down     : result = _prev.IsKeyDown( key ) && _next.IsKeyDown( key ); break;
                case JamInputStates.Up       : result = _prev.IsKeyUp( key )   && _next.IsKeyUp( key );   break;

                default : break;
            }

            return result;
        }

    }

}
