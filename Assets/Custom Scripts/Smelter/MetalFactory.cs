using System.Collections;
using System.Collections.Generic;
using System;

public class MetalFactory
{
    private static Metal[] metals = { // an array of the different metals that can be made
        new Metal("null", 0f, 0f, 0, 0f, 0f), // Null metal for an erronious mixture
        new Metal("304", 1.764f, 7.85f, 70, 73.2f, 2642f), // Stainless Steel 304
        new Metal("316", 4.850f, 7.87f, 95, 75f, 2252f), // Stainless Steel 316
    };
    private static Metal[] materials = { // and aray of different materials that can by used to make an alloy | https://en.wikipedia.org/wiki/Prices_of_chemical_elements
        new Metal("iron", .106f, 7.874f, 0, 0f, 2800f),      // 0
        new Metal("nickel", 13.9f, 8.908f, 0, 0f,1453f),     // 1
        new Metal("chrome", 1.28f, 7.15f, 0, 0, 3465f),      // 2
        new Metal("carbon", .122f, 2.2f, 0, 0f, 6422f),      // 3
        new Metal("manganese", 1.82f, 7.12f, 0, 0, 2275f),   // 4
        new Metal("sulfur", .0926f, 2.07f, 0, 0f, 239.38f),  // 5
        new Metal("silicon", 1.7f, 2.329f, 0, 0f, 2577f),    // 6
        new Metal("phosphorus", 2.69f, 2.34f, 0, 0f, 1090f), // 7
        new Metal("molybdenum", 40.1f, 10.28f, 0, 0f, 4753f) // 8
};



    public static Metal CreateNewAlloy(float iron, float nickel, float chrome, float carbon, float manga, float silicon, float phosp, float sulfur, float nitrogen, float moly)
    {
        if( (iron >= .66) &&
            (nickel >= .08 && nickel <= 10.5) &&
            (chrome >= .18 && chrome <= .2) &&
            (carbon <= .0008) &&
            (manga <= .02) &&
            (silicon <= .0075) &&
            (phosp <= .00045) &&
            (sulfur <= .0003) &&
            (nitrogen <= .001) &&
            (moly <= 0) )
        {
            return metals[1]; // this is Stainless Steel 304
        }
        else if( (iron <= .61) &&
                 (nickel >= .10 && nickel <= 14) &&
                 (chrome >= .16 && chrome <= .18) &&
                 (carbon <= .0008) &&
                 (manga <= .02) &&
                 (silicon <= .0075) &&
                 (phosp <= .00045) &&
                 (sulfur <= .0003) &&
                 (nitrogen <= .001) &&
                 (moly >= .02 && moly <= .03))
        {
            return metals[2]; // this is Stainless Steel 316
        }
        else
        {
            return metals[0]; // this is a null metal | the student made a drastic error
        }
    }

    public static Metal CreateNewMaterial(string type)
    {
        switch (type)
        {
            case "fe":
                return materials[0];
            case "ni":
                return materials[1];
            case "cr":
                return materials[2];
            case "c":
                return materials[3];
            case "mn":
                return materials[4];
            case "s":
                return materials[5];
            case "si":
                return materials[6];
            case "p":
                return materials[7];
            case "mo":
                return materials[8];
            default:
                return null;
        }
    }
    
}


