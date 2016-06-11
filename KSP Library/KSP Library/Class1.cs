﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KSP_Library
{
    // [Serializable]
    public class Stage
    {
        // properties
        public string StageName { get; set; }
        public int ID { get; set; }
        public double WetMass { get; set; }
        public double DryMass { get; set; }
        public int Isp { get; set; }
        public double Thrust { get; set; }
        public int DeltaV { get; set; }
        public double MinTWR { get; set; }
        public double MaxTWR { get; set; }

        // constructors
        public Stage() { }
        public Stage(string stageName)
        {
            StageName = stageName;
        }
        public Stage(int id)
        {
            ID = id;
        }
        public Stage(string stageName, int id)
        {
            StageName = stageName;
            id = id;
        }

        // methods
        public void CalculateDeltaV()
        {
            DeltaV = (int)Math.Round(Math.Log(WetMass / DryMass) * 9.81 * Isp);
        }
        public void CalculateIsp()
        {
            Isp = (int)Math.Round(DeltaV / (Math.Log(WetMass / DryMass) * 9.81));
        }
        public void CalculateMinTWR()
        {
            MinTWR = Thrust / (WetMass * (9.81));
        }
        public void CalculateMaxTWR()
        {
            MaxTWR = Thrust / (DryMass * (9.81));
        }
        public void CalculateMinTWR(long GM, double Radius)
        {
            MinTWR = Thrust / (WetMass * (GM / Math.Pow(Radius, 2)));
        }
        public void CalculateMaxTWR(long GM, double Radius)
        {
            MaxTWR = Thrust / (DryMass * (GM / Math.Pow(Radius, 2)));
        }
        public void CalculateThrustFromMinTWR()
        {
            Thrust = MinTWR * (WetMass * (9.81));
        }
        public void CalculateThrustFromMaxTWR()
        {
            Thrust = MaxTWR * (DryMass * (9.81));
        }
        public void CalculateThrustFromMinTWR(long GM, double Radius)
        {
            Thrust = MinTWR * (WetMass * (GM / Math.Pow(Radius, 2)));
        }
        public void CalculateThrustFromMaxTWR(long GM, double Radius)
        {
            Thrust = MaxTWR * (DryMass * (GM / Math.Pow(Radius, 2)));
        }
        public void CalculateTWR()
        {
            MinTWR = GetMinTWR();
            MaxTWR = GetMaxTWR();
        }
        public void GetTWR(long GM, double Radius)
        {
            MinTWR = GetMinTWR(GM, Radius);
            MaxTWR = GetMaxTWR(GM, Radius);
        }

        public int GetDeltaV()
        {
            DeltaV = (int)Math.Round(Math.Log(WetMass / DryMass) * 9.81 * Isp);
            return DeltaV;
        }
        public int GetIsp()
        {
            Isp = (int)Math.Round(DeltaV / (Math.Log(WetMass / DryMass) * 9.81));
            return Isp;
        }
        public double GetMinTWR()
        {
            MinTWR = Thrust / (WetMass * (9.81));
            return MinTWR;
        }
        public double GetMaxTWR()
        {
            MaxTWR = Thrust / (DryMass * (9.81));
            return MaxTWR;
        }
        public double GetMinTWR(long GM, double Radius)
        {
            MinTWR = Thrust / (WetMass * (GM / Math.Pow(Radius, 2)));
            return MinTWR;
        }
        public double GetMaxTWR(long GM, double Radius)
        {
            MaxTWR = Thrust / (DryMass * (GM / Math.Pow(Radius, 2)));
            return MaxTWR;
        }
        public double GetThrustFromMinTWR()
        {
            Thrust = MinTWR * (WetMass * (9.81));
            return Thrust;
        }
        public double GetThrustFromMaxTWR()
        {
            Thrust = MaxTWR * (DryMass * (9.81));
            return Thrust;
        }
        public double GetThrustFromMinTWR(long GM, double Radius)
        {
            Thrust = MinTWR * (WetMass * (GM / Math.Pow(Radius, 2)));
            return Thrust;
        }
        public double GetThrustFromMaxTWR(long GM, double Radius)
        {
            Thrust = MaxTWR * (DryMass * (GM / Math.Pow(Radius, 2)));
            return Thrust;
        }
        public void GetTWR(out double minTWR, out double maxTWR)
        {
            minTWR = GetMinTWR();
            maxTWR = GetMaxTWR();
        }
        public void GetTWR(long GM, double Radius, out double minTWR, out double maxTWR)
        {
            minTWR = GetMinTWR(GM, Radius);
            maxTWR = GetMaxTWR(GM, Radius);
        }
    }

    namespace SolarSystems
    {
        abstract class SolarSystem
        {
            List<Body> bodies = new List<Body>();
            public virtual Body GetSystemBody(string body)
            {
                foreach (Body targetBody in bodies)
                {
                    if (body.ToUpper() != targetBody.Name)
                    {
                        continue;
                    }
                    else return targetBody;
                }
                return null;
            }
        }
        class KerbolSystem : SolarSystem
        {
            List<Body> bodies = new List<Body>();
            public KerbolSystem()
            {
                Body KERBOL = new Body
                {
                    Name = "KERBOL",
                    Radius = 261600000,
                    GM = 1172332800000000000
                };
                bodies.Add(KERBOL);

                bodies[1] = new Body
                {
                    Name = "MOHO",
                    Radius = 250000,
                    GM = 168609380000
                };

                bodies[2] = new Body
                {
                    Name = "EVE",
                    Radius = 700000,
                    GM = 8171730200000
                };

                bodies[3] = new Body
                {
                    Name = "GILLY",
                    Radius = 13000,
                    GM = 8289450
                    // Actual GM == 8289449.8
                };

                bodies[4] = new Body
                {
                    Name = "KERBIN",
                    Radius = 600000,
                    GM = 3531600000000
                };

                bodies[5] = new Body
                {
                    Name = "MUN",
                    Radius = 200000,
                    GM = 65138398000
                };

                bodies[6] = new Body
                {
                    Name = "MINMUS",
                    Radius = 60000,
                    GM = 1765800000
                };

                bodies[7] = new Body
                {
                    Name = "DUNA",
                    Radius = 320000,
                    GM = 301363210000
                };

                bodies[8] = new Body
                {
                    Name = "IKE",
                    Radius = 130000,
                    GM = 18568369000
                };

                bodies[9] = new Body
                {
                    Name = "DRES",
                    Radius = 138000,
                    GM = 21484489000
                };

                bodies[10] = new Body
                {
                    Name = "JOOL",
                    Radius = 6000000,
                    GM = 282528000000000
                };

                bodies[11] = new Body
                {
                    Name = "LAYTHE",
                    Radius = 500000,
                    GM = 1962000000000
                };

                bodies[12] = new Body
                {
                    Name = "VALL",
                    Radius = 300000,
                    GM = 207481500000
                };

                bodies[13] = new Body
                {
                    Name = "TYLO",
                    Radius = 600000,
                    GM = 2825280000000
                };

                bodies[14] = new Body
                {
                    Name = "BOP",
                    Radius = 65000,
                    GM = 2486834900
                };

                bodies[15] = new Body
                {
                    Name = "POL",
                    Radius = 44000,
                    GM = 721702080
                };

                bodies[16] = new Body
                {
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000
                };
            }
        }
    }

    public static class RealSolarSystem
    {
        public static Body GetSystemBody(string body)
        {
            Body[] bodies = new Body[17];

            bodies[0] = new Star
            {
                Name = "SUN",
                Radius = 695700000,
                GM = BigGM.GMPower(132712440018, 20)
                //GM = 132712440018000000000
            };

            bodies[1] = new Body
            {
                Name = "MERCURY",
                Radius = 2440000,
                GM = 22032000000000
            };

            bodies[2] = new Body
            {
                Name = "VENUS",
                Radius = 6052000,
                GM = 324859000000000
            };

            bodies[3] = new Body
            {
                Name = "EARTH",
                Radius = 6371000,
                GM = 398600441800000
            };

            bodies[4] = new Body
            {
                Name = "MOON",
                Radius = 1737000,
                GM = 4904869500000
            };

            bodies[5] = new Body
            {
                Name = "MARS",
                Radius = 3390000,
                GM = 42828370000000
            };

            bodies[6] = new Body
            {
                Name = "PHOBOS",
                Radius = 11266,
                GM = 711390
            };

            bodies[7] = new Body
            {
                Name = "DEIMOS",
                Radius = 6200,
                GM = 98523
            };

            bodies[8] = new Body
            {
                Name = "VESTA",
                Radius = 262700,
                GM = 17290939500
            };

            bodies[8] = new Body
            {
                Name = "CERES",
                Radius = 473000,
                GM = 62689633440
            };

            bodies[8] = new Body
            {
                Name = "PALLAS",
                Radius = 512000,
                GM = 14082308800
            };

            bodies[8] = new Body
            {
                Name = "INTERAMNIA",
                Radius = 158310,
                GM = 2602891200
            };

            bodies[8] = new Body
            {
                Name = "HYGIEA",
                Radius = 431000,
                GM = 5786427360
            };

            bodies[9] = new Body
            {
                Name = "JUPITER",
                Radius = 69911000,
                GM = 126686534000000000
            };

            bodies[10] = new Body
            {
                Name = "IO",
                Radius = 1821600,
                GM = 5961246900000
            };

            bodies[11] = new Body
            {
                Name = "EUROPA",
                Radius = 1560800,
                GM = 3203454300000
            };

            bodies[12] = new Body
            {
                Name = "GANYMEDE",
                Radius = 2634100,
                GM = 9890319200000
            };

            bodies[13] = new Body
            {
                Name = "CALLISTO",
                Radius = 2410300,
                GM = 7180896300000
            };

            bodies[14] = new Body
            {
                Name = "SATURN",
                Radius = 58232000,
                GM = 37931187000000000
            };

            bodies[15] = new Body
            {
                Name = "MIMAS",
                Radius = 198200,
                GM = 2502312814
            };

            bodies[16] = new Body
            {
                Name = "ENCELADUS",
                Radius = 252100,
                GM = 7209474698
            };

            bodies[17] = new Body
            {
                Name = "TETHYS",
                Radius = 531100,
                GM = 41209040219
            };

            bodies[18] = new Body
            {
                Name = "DIONE",
                Radius = 561400,
                GM = 73111342842
            };

            bodies[19] = new Body
            {
                Name = "RHEA",
                Radius = 763800,
                GM = 153938856534
            };

            bodies[20] = new Body
            {
                Name = "TITAN",
                Radius = 2575500,
                GM = 8977972400000
            };

            bodies[21] = new Body
            {
                Name = "IAPETUS",
                Radius = 734500,
                GM = 120509524408
            };

            bodies[22] = new Body
            {
                Name = "URANUS",
                Radius = 25362000,
                GM = 5793939000000000
            };

            bodies[23] = new Body
            {
                Name = "MIRANDA",
                Radius = 235800,
                GM = 4398218720
            };

            bodies[24] = new Body
            {
                Name = "ARIEL",
                Radius = 578900,
                GM = 90300302400
            };

            bodies[25] = new Body
            {
                Name = "UMBRIEL",
                Radius = 584700,
                GM = 78220217600
            };

            bodies[26] = new Body
            {
                Name = "TITANIA",
                Radius = 788400,
                GM = 235394801600
            };

            bodies[27] = new Body
            {
                Name = "OBERON",
                Radius = 761400,
                GM = 201156771200
            };

            bodies[28] = new Body
            {
                Name = "NEPTUNE",
                Radius = 24622000,
                GM = 6836529000000000
            };

            bodies[29] = new Body
            {
                Name = "PROTEUS",
                Radius = 210000,
                GM = 2936595200
            };

            bodies[30] = new Body
            {
                Name = "TRITON",
                Radius = 1353400,
                GM = 1428253100000
            };

            bodies[31] = new Body
            {
                Name = "NEREID",
                Radius = 170000,
                // GM unknown
            };

            bodies[32] = new Body
            {
                Name = "PLUTO",
                Radius = 1187000,
                GM = 871000000000
            };

            bodies[33] = new Body
            {
                Name = "CHARON",
                Radius = 606000,
                GM = 105850908800
            };

            bodies[34] = new Body
            {
                Name = "HAUMEA",
                Radius = 620000,
                GM = 267363644800
            };

            bodies[35] = new Body
            {
                Name = "MAKEMAKE",
                Radius = 715000,
                GM = 293659520000
            };

            bodies[36] = new Body
            {
                Name = "ERIS",
                Radius = 1163000,
                GM = 1108000000000
            };

            foreach (Body targetBody in bodies)
            {
                if (body.ToUpper() != targetBody.Name)
                {
                    continue;
                }
                else return targetBody;
            }
            Body NoBody = new Body();
            NoBody.Name = "NOBODY";
            return NoBody;
        }
    }

    public class Star : Body
    {
        new public BigInteger GM { get; set; }
    }

    public struct BigGM
    {
        public static BigInteger GMPower(double value, double power)
        {
            return (BigInteger)Math.Pow(value, power);
        }
    }

    public class Body
    {
        public string Name { get; set; }
        public int Radius { get; set; }
        public long GM { get; set; }
    }
}
