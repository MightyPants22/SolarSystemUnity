using System.Collections.Generic;
using UnityEngine;

public interface IPlanetaryObject

{
    MassClass MassClass {get; set;}
    double Mass {get; set;}
    double Radius {get; set;}
    Vector3 Position { get; set; }
    Vector3 Velocity { get; set;}
    GameObject Go { get; set; }
}

public interface IPlanetarySystem
{
    IEnumerable<IPlanetaryObject> PlanetaryObjects {get;}
}

public interface IPlanetarySystemFactory
{
    IPlanetarySystem GeneratePlanetarySystem(double mass);
}