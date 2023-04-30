using Microsoft.Xna.Framework.Input;

namespace GameJam.Core.Inputs {

    public enum JamInputTypes : int {

        Mouse    = 0,
        Keyboard = 1,
        Gamepad  = 2,

        COUNT

    }

    public struct JamInputQuery {

        public JamInputTypes Type;
        public JamInputStates State;
        public int Input;

        public JamInputQuery( Keys key, JamInputStates state ) {
            Type  = JamInputTypes.Keyboard;
            State = state;
            Input = (int)key;
        }

    }

}
