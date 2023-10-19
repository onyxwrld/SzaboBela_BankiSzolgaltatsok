using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class MegtakaritasiSzamla:Szamla
	{
		public static double alapKamat = 1.1;
		private double kamat;

		public MegtakaritasiSzamla(Tulajdonos tulajdonos) : base(tulajdonos)
		{
			this.Kamat = alapKamat;
		}

		public double AlapKamat { get => alapKamat; set => alapKamat = value; }
		public double Kamat { get => kamat; set => kamat = value; }

		public override bool Kivesz(int osszeg)
		{
			if (osszeg>0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void KamatJovairas()
		{
			kamat = alapKamat * AktualisEgyenleg;
		}
	}
}
