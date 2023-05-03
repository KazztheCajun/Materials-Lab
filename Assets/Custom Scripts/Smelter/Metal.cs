using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal
{
    string n; // metal name
    float c; // $/kg
    float d; // g/cm^3
    int h; // Rockwell
    float t; // tensile strength | ksi (Kilopound per square inch)
    float m; // melting point | F

    public string MetalName { get {return n;} }
    public float Cost { get {return c;} }
    public float Density { get {return d;} }
    public int Hardness { get {return h;} }
    public float TensileStrength { get {return t;} }
    public float MeltingPoint { get {return m;} }

    public Metal(string n, float c, float d, int h, float t, float m)
    {
        this.n = n;
        this.c = c;
        this.d = d;
        this.h = h;
        this.t = t;
        this.m = m;
    }

}
