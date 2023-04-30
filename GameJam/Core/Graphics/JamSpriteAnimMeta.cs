using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam.Core.Graphics {

    public delegate void JamSpriteAnimCallback( JamGame game, int prev_frame, int next_frame );

    public struct JamSpriteAnimMeta {

        public bool IsPlaying;
        public int Animation;
        public int Frame;
        public float Time;
        public JamSpriteAnimCallback OnChange;

    }

}
