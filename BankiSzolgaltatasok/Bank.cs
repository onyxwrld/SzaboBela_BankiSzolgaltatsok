using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class Bank
	{
		List<Szamla> list_Szamla = new List<Szamla>();

		public long OsszHitelkeret { get
            {
				long ossz = 0;
                foreach (var item in list_Szamla)
                {
                    if (item.GetType() == typeof(HitelSzamla))
                    {
						ossz += ((HitelSzamla)item).HitelKeret;
                    }
                }
				return ossz;
            } }
		public long GetOsszEgyenleg(Tulajdonos tulajdonos)
		{
			long a = 0;
			foreach (var item in list_Szamla)
			{
				if (item.Tulajdonos == tulajdonos)
				{
					a += item.AktualisEgyenleg;
				}
			}
			return a;
		}

		public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
		{
			Szamla szamla;
			if (hitelKeret < 0)
			{
				throw new ArgumentException("hibas");
			}
			else
			{
				szamla = new HitelSzamla(tulajdonos, hitelKeret);
				list_Szamla.Add(szamla);
				return szamla;
			}
		}
		public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
		{
			Szamla max = list_Szamla[0];
            foreach (Szamla item in list_Szamla)
            {
                if (item.AktualisEgyenleg > max.AktualisEgyenleg && item.Tulajdonos.Equals(tulajdonos))
                {
					max = item;
                }
            }
            return max;
        }
	}
}
