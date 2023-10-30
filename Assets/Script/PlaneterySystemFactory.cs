using System.Collections.Generic;
using UnityEngine;
using static MassClass;
using Random = UnityEngine.Random;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    public double massSetup = 1000.0;
    public GameObject planetPrefab;
    public Transform planetContainer;

    private IPlanetarySystem _planetarySystem;
    private void Start()
    {
         _planetarySystem = GeneratePlanetarySystem(massSetup);
    }

    public IPlanetarySystem GeneratePlanetarySystem(double mass)
    {
        var planetarySystem = GetComponent<PlanetarySystem>(); 

        List<double> MassResults = new List<double>();
        double systemMassLeft = massSetup;

        for (int i = 0; i < mass; i++)
        {
            if (systemMassLeft <= 0.0)
                break;

            MassClass maxPossibleClass = MassClass.Asteroidan;

            foreach (MassClass massClass in System.Enum.GetValues(typeof(MassClass)))
            {
                if (systemMassLeft >= MassClassDictionary.Specifications[massClass].MinMass)
                {
                    maxPossibleClass = massClass;
                }
                else
                {
                    break;
                }
            }

            MassClass chosenClass = (MassClass)Random.Range(0, (int)maxPossibleClass + 1);

            double deltaMass = MassClassDictionary.Specifications[chosenClass].MaxMass - MassClassDictionary.Specifications[chosenClass].MinMass;
            double generatedMass = MassClassDictionary.Specifications[chosenClass].MinMass + Random.value * deltaMass;

            generatedMass = Mathf.Min((float)generatedMass, (float)systemMassLeft);
            MassResults.Add(generatedMass);
            systemMassLeft -= generatedMass;
        }

        foreach (double Result in MassResults)
        {
            double minRadius = MassClassDictionary.Specifications[MassClassDictionary.GetMassClassFromMass(Result)].MinRadius;
            double maxRadius = MassClassDictionary.Specifications[MassClassDictionary.GetMassClassFromMass(Result)].MaxRadius;

            double deltaRadius = maxRadius - minRadius;
            double radius = minRadius + Random.value * deltaRadius;
            
            GameObject planetObjectGo = Instantiate(planetPrefab, planetContainer);
            var planetaryObject = planetObjectGo.GetComponent<PlanetaryObject>();
            planetaryObject.Go = planetObjectGo;
            planetaryObject.InitializePlanet(Result, radius);
            planetaryObject.Position = new Vector3(Random.Range(0,80), Random.Range(0,80), Random.Range(0,80));
            planetObjectGo.transform.position = planetaryObject.Position;

            float scale = (float)(planetaryObject.Radius * 2);
            planetObjectGo.transform.localScale = new Vector3(scale, scale, scale);
           
            planetarySystem.AddPlanetaryObject(planetaryObject);
        }

        return planetarySystem;
    }


}