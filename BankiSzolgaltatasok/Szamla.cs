﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public abstract class Szamla: BankiSzolgaltatas
	{
		protected int aktualisEgyenleg;

		public Szamla(Tulajdonos tulajdonos): base(tulajdonos)
		{
			aktualisEgyenleg = 0;
		}

		public int AktualisEgyenleg { get => aktualisEgyenleg;}
		public void Befizet(int osszeg)
		{
			if (osszeg > 0) {
				aktualisEgyenleg += osszeg;
			}
			else
			{
				throw new Exception(nameof(osszeg) +" nem lehet a befizetendő összeg");
			}
			
		}
		public abstract bool Kivesz(int osszeg);
		public Kartya UjKartya(string kartyaSzam)
		{
			return new Kartya(Tulajdonos,this,kartyaSzam);
		}

	}
}
