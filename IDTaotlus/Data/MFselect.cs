using System.Collections.Generic;
using System.Collections.Immutable;
namespace IDTaotlus.Helpers
{ /*
     * Class containing gender combobox data.
     * Klass mis sisaldab sugu combobox adndmed.
     */
    class MFselect
    {
        public static ImmutableDictionary<string, byte> MF = new Dictionary<string, byte> {
          {"Mees",(byte)1},
          {"Naine",(byte)0},
          {"Mõlemad",(byte)2},
          }.ToImmutableDictionary<string, byte>();
    }
}
