using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AstroSuitStation : InterectiveEnergy
{

    [Range(1, 10)] public int CurrentEnergy = 1;
    [Range(1, 10)] public int ChargePerEnergy = 3;
    public int CurrentCharge => CurrentEnergy * ChargePerEnergy;
}
