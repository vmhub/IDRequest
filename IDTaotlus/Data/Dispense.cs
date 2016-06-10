using System;
using System.Collections.Generic;
using System.Collections.Immutable;
namespace IDTaotlus
{   /*
     * Class containing dispense combobox data.
     * Klass mis sisaldab väljastamise combobox adndmed.
     */
    static class Dispense
    {
        public static ImmutableDictionary<string, UInt16> POD = new Dictionary<string, UInt16> {
        {"P.Pinna 4, 13615 Tallinn",(UInt16)717},
        {"A.H. Tammsaare 47, 11316 Tallinn",(UInt16)783},
        {"Rahu 38, 41532 Jõhvi",(UInt16)730},
        {"Vahtra 3, 21003 Narva",(UInt16)733},
        {"Fr. R. Kreutzwaldi 5a, 44314 Rakvere",(UInt16)732},
        {"Aida 5, 80010 Pärnu",(UInt16)740},
        {"Jaama 14/3, 90507 Haapsalu",(UInt16)742},
        {"Transvaali 58, 93811 Kuressaare",(UInt16)743},
        {"Sadama 26, 92411 Kärdla",(UInt16)744},
        {"Suur-Aia 19/21, 72711 Paide",(UInt16)714},
        {"Tallinna mnt 14, 79513 Rapla",(UInt16)715},
        {"Riia mnt 132, 50096 Tartu",(UInt16)720},
        {"Suur 1, 48306 Jõgeva",(UInt16)722},
        {"Võru 12, 63308 Põlva",(UInt16)723},
        {"Aia 17, 68203 Valga",(UInt16)724},
        {"Vabaduse plats 6, 71020 Viljandi",(UInt16)725},
        {"Räpina mnt 20a, 65606, Võru",(UInt16)726},
        }.ToImmutableDictionary<string, UInt16>();
    }
}
