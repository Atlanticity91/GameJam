using GameJam.Core.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameJam.Core {

    public class JamInput {

        private JamInputDevice[] _devices;
        private Dictionary<string, List<JamInputQuery>> _input_queries;

        public Point Cursor2i   => ((JamMouse)_devices[ (int)JamInputTypes.Mouse ]).Cursor2i;
        public Vector2 Cursor2f => ((JamMouse)_devices[ (int)JamInputTypes.Mouse ]).Cursor2f;

        public JamInput( ) {
            _devices       = new JamInputDevice[ (int)JamInputTypes.COUNT ];
            _input_queries = new Dictionary<string, List<JamInputQuery>>( );

            _devices[ 0 ] = new JamMouse( );
            _devices[ 1 ] = new JamKeyboard( );
            _devices[ 2 ] = new JamGamepad( );
        }

        public JamInput Register( string name, JamInputQuery query ) {
            if ( !string.IsNullOrEmpty( name ) ) {
                if ( !_input_queries.ContainsKey( name ) )
                    _input_queries[ name ] = new List<JamInputQuery>( );

                _input_queries[ name ].Add( query );
            }

            return this;
        }

        public void Tick( ) {
            foreach ( var device in _devices ) 
                device.Tick( );
        }

        public bool GetQuery( string name ) {
            var result = false;

            if ( !string.IsNullOrEmpty( name ) ) { 
                foreach ( var query in _input_queries[ name ] ) {
                    result = _devices[ (int)query.Type ].GetIsInput( query.Input, query.State );

                    if ( result ) break;
                }
            }

            return result;
        }

        public bool GetIsKey( Keys key, JamInputStates state )
            => _devices[ (int)JamInputTypes.Keyboard ].GetIsInput( (int)key, state );

    }

}
