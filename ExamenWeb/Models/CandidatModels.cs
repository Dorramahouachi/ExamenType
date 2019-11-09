﻿using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public enum countries
    {
        Afghanistan,
        Albania,
        Algeria,
        AmericanSamoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        AntiguaandBarbuda,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        BosniaandHerzegovina,
        Botswana,
        Brazil,
        Bulgaria,
        BurkinaFaso,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        CapeVerde,
        CaymanIslands,
        CentralAfricanRepublic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        Congo,
        CookIslands,
        CostaRica,
        CoteDIvoire,
        Croatia,
        Cuba,
        Cyprus,
        CzechRepublic,
        Denmark,
        Djibouti,
        Dominica,
        DominicanRepublic,
        Ecuador,
        Egypt,
        ElSalvador,
        EquatorialGuinea,
        Eritrea,
        Estonia,
        Ethiopia,
        FaroeIslands,
        Fiji,
        Finland,
        France,
        FrenchGuiana,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greece,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guatemala,
        GuineaBissau,
        Guyana,
        Haiti,
        Honduras,
        HongKong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Korea, DemocraticPeoplesRepublicof,
        Republicofkorea,
        Kuwait,
        Kyrgyzstan,
        LaoPeoplsDemocraticRepublic,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macao,
        Macedonia, theFormerYugoslavRepublicof,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        MarshallIslands,
        Martinique,
        Mauritania,
        Mauritius,
        Mayotte,
        Mexico,
        Micronesia, FederatedStatesof,
        RepublicofMoldova,
        Monaco,
        Mongolia,
        Montserrat,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        NetherlandsAntilles,
        NewCaledonia,
        NewZealand,
        Nicaragua,
        Niger,
        Nigeria,
        Niue,
        NorfolkIsland,
        NorthernMarianaIslands,
        Norway,
        Oman,
        Pakistan,
        Palau,
        PalestinianTerritory, Occupied,
        Panama,
        PapuaNewGuinea,
        Paraguay,
        Peru,
        Philippines,
        Pitcairn,
        Poland,
        Portugal,
        PuertoRico,
        Qatar,
        Reunion,
        Romania,
        RussianFederation,
        Rwanda,
        SaintKittsandNevis,
        SaintLucia,
        SaintPierreandMiquelon,
        SaintVincentandtheGrenadines,
        SanMarino,
        SaoTomandPrincipe,
        SaudiArabia,
        Senegal,
        SerbiaandMontenegro,
        Seychelles,
        SierraLeone,
        Singapore,
        Slovakia,
        Slovenia,
        SolomonIslands,
        Somalia,
        SouthAfrica,
        Spain,
        SriLanka,
        Sudan,
        Suriname,
        Swaziland,
        Sweden,
        Switzerland,
        Syria,
        Taiwan, ProvinceofChina,
        Tajikistan,
        Tanzania,
        Thailand,
        TimorLeste,
        Togo,
        Tokelau,
        Tonga,
        TrinidadandTobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        TurksandCaicosIslands,
        Tuvalu,
        Uganda,
        Ukraine,
        UnitedArabEmirates,
        UnitedKingdom,
        UnitedStates,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Venezuela,
        VietNam,
        VirginIslands,
        US,
        WesternSahara,
        Yemen,
        Zambia,
        Zimbabwe
    }
    public class CandidatModels:UserModels
    {
        public String name { get; set; }
        public String lastname { get; set; }
        public DateTime birthDate { get; set; }
        public String address { get; set; }
        public String Skills { get; set; }
        public String experience { get; set; }
        public String actualPost { get; set; }
        public String bio { get; set; }
        public String Country { get; set; }
        public long? phoneContact { get; set; }
        public String picture { get; set; }
        public IEnumerable<Contacts> Contacts { get; set; }
    }
}