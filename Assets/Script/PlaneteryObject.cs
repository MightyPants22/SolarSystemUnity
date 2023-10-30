using UnityEngine;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
  public MassClass MassClass {get; set;}
  public double Mass {get; set;}
  public double Radius {get; set;}
  public Vector3 Position { get; set; } = Vector3.zero;
  public Vector3 Velocity { get; set; } = Vector3.zero;
  public GameObject Go { get; set; }

  public void InitializePlanet(double mass, double radius)
    {   
        Mass = mass;
        Radius = radius;
    }
}