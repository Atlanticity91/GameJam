namespace GameJam.Core.Graphics {

    public class JamSpriteAnim {

        private bool _use_multi_sheet;
        private JamSpriteAnimFrame?[] _frames;

        public bool UseMultiSheet => _use_multi_sheet;
        public int Length         => _frames.Length;

        public JamSpriteAnim( bool use_multi_sheet, int length ) {
            _use_multi_sheet = use_multi_sheet;
            _frames          = new JamSpriteAnimFrame?[ length ];
        }

        public JamSpriteAnim Set( int frame_id, JamSpriteAnimFrame? frame ) {
            if ( frame_id < _frames.Length && frame != null && frame?.Duration > 0.0f )
                _frames[ frame_id ] = frame;

            return this;
        }

        public JamSpriteAnimFrame? this[ int frame_id ] {
            get => frame_id < _frames.Length ? _frames[ frame_id ] : null;
            set => Set( frame_id, value );
        }

    }

}
