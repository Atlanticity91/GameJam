namespace GameJam.Core.Inputs {

    public enum JamInputStates : int {

        Pressed  = 0,
        Released = 1,
        Down     = 2,
        Up       = 3,

        COUNT

    }

    public interface JamInputDevice {

        public void Tick( );

        public bool GetIsInput( int input, JamInputStates state );

    }

}
