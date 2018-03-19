using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox
{
    class BaseStat
    {
        public int alap;
        public string alap_leiras;
        public int modositott;
        public string modositott_leiras;
    }

    class FightingStats
    {
        public int ke;
        public int te;
        public int ve;
        public int ce;
        public string ke_keplet;
        public string te_keplet;
        public string ve_keplet;
        public string ce_keplet;
    }

    class Equipment
    {
        public string nev;
        public string megjegyzes;
        public int mennyiseg;
        public double suly_osszesen;
        public string suly_osszesen_keplet;
        public int egyseg_ar;
        public int ossz_ar;
        public string elhelyezes;
        public bool rajta_van;

        public virtual bool IsContainer { get { return false; } }
    }

    class Container : Equipment
    {
        public override bool IsContainer { get { return true; } }
        public List<Equipment> Content;
    }

    class Poison : Equipment
    {
        string tipus;
        string hatas;
        string idotartam;
        string hatoido;
        int szint;
    }

    class EquipmentOuter
    {
        public List<Equipment> targyak;
    }

    class Weapon : Equipment
    {
        public string nev;
        public int hasznalat_foka;
        public string hasznalat_foka_keplet;
        public int idoigeny;
        public int ke;
        public int te;
        public int ve;
        public int ce;
        public string ke_keplet;
        public string te_keplet;
        public string ve_keplet;
        public string ce_keplet;
        public string sebzes;
        public string sebzes_keplet;
        public int stp;
        public bool lefegyverzes;
        public bool fegyvertores;
        public bool atutes;
        public int tavolsag;
    }

    class WeaponOuter
    {
        public List<Weapon> fegyverek;
    }


    class Character
    {
        public Dictionary<string, BaseStat> tulajdonsag;
        public FightingStats harcertek;
        public WeaponOuter fegyver;
        public EquipmentOuter targy;
    }

    class Outer
    {
        public int response_code = 0;
        public string response_text;
        public Character karakter;
    }
}
