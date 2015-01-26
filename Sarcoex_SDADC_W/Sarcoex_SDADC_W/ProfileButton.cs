using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarcoex_SDADC_W
{
    public class ProfileButton : System.Windows.Forms.Button
    {
        private Profile _profile;
        public Profile profile 
        { 
            get {return _profile; }
            set {_profile = value; }
        }
    }
}
