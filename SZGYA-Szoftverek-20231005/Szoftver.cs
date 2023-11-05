using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;


namespace SZGYA_Szoftverek_20231005
{
    class Szoftver
    {
        public int Id { get; set; }
        public string NevEsVerzio { get; set; }
        public string LicenszTipus { get; set; }
        public string[] TamogatottOSek { get; set; }
        public string Kategoria { get; set; }
        public float Ertekeles { get; set; }
        public float NettoAr { get; set; }
        public int AdoKulcs { get; set; }
        //
        public float BruttoAr => NettoAr + NettoAr * AdoKulcs/100f;

        public Szoftver(string sor)
        {
            string[] adatok = sor.Split('|');
            this.Id = int.Parse(adatok[0]);
            this.NevEsVerzio = adatok[1];
            this.LicenszTipus = adatok[2];
            this.TamogatottOSek = adatok[3].Split(", ");
            this.Kategoria = adatok[4];
            this.Ertekeles = float.Parse(adatok[5]);
            this.NettoAr = float.Parse(adatok[6]);
            this.AdoKulcs = int.Parse(adatok[7]);
        }

        public override string ToString()
        {
            return $"{this.Id,-2}|{this.NevEsVerzio,-45}|{this.LicenszTipus,-12}|{String.Join(", ", this.TamogatottOSek), -14}|{this.Kategoria,-27}|{this.Ertekeles,-3}|{this.NettoAr,-6}|{this.Ertekeles,-3}";
        }
    }
}
