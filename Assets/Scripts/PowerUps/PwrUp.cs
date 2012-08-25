using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ShipParts;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public interface PwrUp
    {
        void Give(Hull part);
        void Take(Hull part);
        void Action(Hull part);
    }
}
