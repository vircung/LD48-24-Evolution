using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ShipParts;

namespace Assets.Scripts.PowerUps
{
	class Exp
	{
        int exp;

        public Exp(int amount)
        {
            exp = amount;
        }

        public void Give(Hull part)
        {
            part.TakeExp(exp);
        }
	}
}
