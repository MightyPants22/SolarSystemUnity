using System.Collections.Generic;
using UnityEngine;
using static PlanetaryObject;
using static MassClass;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    private List<IPlanetaryObject> planetaryObjects = new List<IPlanetaryObject>();
    private const float TimeStep = 0.01f;
    private const float GravitationalConstant = 6.6f;

    public IEnumerable<IPlanetaryObject> PlanetaryObjects => planetaryObjects;

    public void AddPlanetaryObject(IPlanetaryObject planetaryObject)
    {
        planetaryObjects.Add(planetaryObject);
    }

    public void Update()
{
    foreach (var planet in PlanetaryObjects)
    {
        Vector3 netForce = Vector3.zero;

        foreach (var otherPlanet in PlanetaryObjects)
        {
            if (planet == otherPlanet)
                continue;

            Vector3 direction = otherPlanet.Position - planet.Position;
            float distance = direction.magnitude;
            float forceMagnitude = (GravitationalConstant * (float)planet.Mass * (float)otherPlanet.Mass) / (distance * distance);
            Vector3 force = forceMagnitude * direction.normalized;
            netForce += force;
        }

        Vector3 acceleration = netForce / (float)planet.Mass;
        planet.Velocity += acceleration * Time.deltaTime;
        planet.Position += planet.Velocity * Time.deltaTime;

        
    }    
}
}
