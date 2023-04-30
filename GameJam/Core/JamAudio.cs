using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace GameJam.Core {
    
    public class JamAudio {

        private ContentManager _content;

        public JamAudio( ContentManager content ) {
            _content = content;
        }

        public bool LoadSound( string path ) {
            return false;
        }

        public bool LoadMusic( string path ) {
            return false;
        }

    }

}
