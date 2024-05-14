using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_13.Program;

namespace C_13
{
    internal class Program
    {

        public class Prece 
        {
           
            public string Nosaukums;
            public double Iepirksanas_cena;


            public Prece(string nosaukums, double iepirksanasCena) 
            {
                Nosaukums = nosaukums;
                Iepirksanas_cena = iepirksanasCena;
            }

            
            public void Izvadit()
            {
                Console.WriteLine($"Prece: {Nosaukums}, Iepirksanas cena: {Iepirksanas_cena}");
            }
        }

     
        public class Partikas_Prece : Prece
        {
            public string Deriguma_termins;
            public bool Ir_alergisks;
            public string Mervieniba;
            public double Pardosanas_cena;

            public Partikas_Prece(string nosaukums, double iepirksanasCena, string derigumaTermins, bool irAlergisks, string mervieniba)
                : base(nosaukums, iepirksanasCena) 
            {
                Deriguma_termins = derigumaTermins;
                Ir_alergisks = irAlergisks;
                Mervieniba = mervieniba;
                Pardosanas_cena = Iepirksanas_cena * 1.3; 
            }

            public void Registret()
            {
                Console.WriteLine("Partikas prece registreta!");
            }

            public void Izvadit()
            {
                base.Izvadit();
                Console.WriteLine($"Deriguma termins: {Deriguma_termins}, Ir alergisks: {Ir_alergisks}, Mervieniba: {Mervieniba}, Pardosanas cena: {Pardosanas_cena}");
            }
        }

        public class Saimniecibas_Prece : Prece
        {
            public string Materials;
            public bool Ir_bistama;
            public double Pardosanas_cena;

            public Saimniecibas_Prece(string nosaukums, double iepirksanasCena, string materials, bool irBistama)
                : base(nosaukums, iepirksanasCena) 
            {
                Materials = materials;
                Ir_bistama = irBistama;
                Pardosanas_cena = Iepirksanas_cena * 1.5; 
            }

            public void Registret()
            {
                Console.WriteLine("Saimniecibas prece registreta!");
            }

            public void Izvadit()
            {
                base.Izvadit(); 
                Console.WriteLine($"Materials: {Materials}, Ir bistama: {Ir_bistama}, Pardosanas cena: {Pardosanas_cena}");
            }
        }

        public class Veikals
        {
 
            public string Nosaukums;
            public int Partikas_precu_skaits;
            public int Saimniecibas_precu_skaits;
            public Partikas_Prece[] Partikas_Prece;
            public Saimniecibas_Prece[] Saimniecibas_Prece;

            public Veikals(string nosaukums, int partikasPrecuSkaits, int saimniecibasPrecuSkaits)
            {
                Nosaukums = nosaukums;
                Partikas_precu_skaits = partikasPrecuSkaits;
                Saimniecibas_precu_skaits = saimniecibasPrecuSkaits;
                Partikas_Prece = new Partikas_Prece[partikasPrecuSkaits]; 
                Saimniecibas_Prece = new Saimniecibas_Prece[saimniecibasPrecuSkaits]; 
            }

            public void Registret()
            {
                Console.WriteLine("Veikals registrets!");
            }

            public void Izvadit()
            {
                Console.WriteLine($"Veikals: {Nosaukums}, Partikas precu skaits: {Partikas_precu_skaits}, Saimniecibas precu skaits: {Saimniecibas_precu_skaits}");
            }

            public void Veikla_tips()
            {
                if (Partikas_precu_skaits > 0 && Saimniecibas_precu_skaits == 0)
                    Console.WriteLine("Pārtikas veikals");
                else if (Partikas_precu_skaits == 0 && Saimniecibas_precu_skaits > 0)
                    Console.WriteLine("Saimniecības veikals");
                else
                    Console.WriteLine("Lielveikals");
            }

            public void Atlasit_arpus_termina()
            {
                foreach (var partikasPrece in Partikas_Prece)
                {
                    if (partikasPrece != null && (partikasPrece.Deriguma_termins == DateTime.Today.ToString() || DateTime.Parse(partikasPrece.Deriguma_termins) < DateTime.Today))
                    {
                        partikasPrece.Izvadit(); 
                    }
                }
            }
            public void Atlasit_bistamus()
            {
                foreach (var saimniecibasPrece in Saimniecibas_Prece)
                {
                    if (saimniecibasPrece != null && saimniecibasPrece.Ir_bistama)
                    {
                        saimniecibasPrece.Izvadit(); 
                    }
                }
            }
        }

        class Programm
        {
            static void Main(string[] args)
            {

                Veikals veikals = new Veikals("Betiņa", 2, 2);
                veikals.Partikas_Prece[0] = new Partikas_Prece("Maize", 1.2, "2024-05-08", true, "gab");
                veikals.Partikas_Prece[1] = new Partikas_Prece("Piens", 0.8, "2024-05-10", false, "gab");
                veikals.Saimniecibas_Prece[0] = new Saimniecibas_Prece("Kaste", 2.5, "plastmasa", false);
                veikals.Saimniecibas_Prece[1] = new Saimniecibas_Prece("Mazgašanas lidz.", 5.0, "kimija", false);

                // Izsaucam veikala funkcijas
                veikals.Registret();
                veikals.Izvadit();
                veikals.Veikla_tips();
                veikals.Atlasit_arpus_termina();
                veikals.Atlasit_bistamus();
            }
        }
    }
}