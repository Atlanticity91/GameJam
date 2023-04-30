using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam.Core.Inputs {
    
    public class JamMouse : JamInputDevice {

        private MouseState _prev;
        private MouseState _next;

        public Point Cursor2i   => _next.Position;
        public Vector2 Cursor2f => Cursor2i.ToVector2( );

        public JamMouse() { }

        public void Tick( ) {
            _prev = _next;
            _next = Mouse.GetState( );
        }

        public bool GetIsInput( int input, JamInputStates state ) {
            return false;
        }

    }

}
