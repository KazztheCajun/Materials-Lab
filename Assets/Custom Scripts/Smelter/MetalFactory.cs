using System.Collections;
using System.Collections.Generic;
using System;

public class MetalFactory
{
    private static Metal[] metals = { // an array of the different metals that can be made
        new Metal("null", 0f, 0f, 0, 0f, 0f), // Null metal for an erronious mixture
        new Metal("304", 1825f, 7.85f, 70, 73.2f, 2642f), // Stainless Steel 304
        new Metal("316", 1175f, 7.87f, 95, 75f, 2252f), // Stainless Steel 316
        
};

    public static Metal CreateNewMetal(float iron, float nickel, float chrome, float carbon, float manga, float silicon, float phosp, float sulfur, float nitrogen, float moly)
    {
        if( (iron <= .48) &&
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
        else if( (iron <= .48) &&
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
    
}


