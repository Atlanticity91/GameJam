using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameJam.Core.Graphics {

    public class JamModel {

        private Model _model;
        private Dictionary<string, object> _parameters;

        public JamModel( Model model ) {
            _model = model;
            _parameters = new Dictionary<string, object>( );
        }

        public JamModel SetParameter( string name, object value ) {
            if ( !string.IsNullOrEmpty( name ) && value != null )
                _parameters[ name ] = value;

            return this;
        }

    }

}
