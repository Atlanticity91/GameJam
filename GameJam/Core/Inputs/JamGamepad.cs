using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam.Core.Inputs {

    public class JamGamepad : JamInputDevice {

        public JamGamepad( ) { }

        public void Tick( ) {
        }

        public bool GetIsInput( int input, JamInputStates state ) {
            return false;
        }

    }

}
