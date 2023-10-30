using System.Collections.Generic;

public enum MassClass
{
    Asteroidan,
    Mercurian,
    Subterran,
    Terran,
    Superterran,
    Neptunian,
    Jovian
}

public class MassClassSpecifications
{
    public double MinMass { get; }
    public double MaxMass { get; }
    public double MinRadius { get; }
    public double MaxRadius { get; }

    public MassClassSpecifications(double minMass, double maxMass, double minRadius, double maxRadius)
    {
        MinMass = minMass;
        MaxMass = maxMass;
        MinRadius = minRadius;
        MaxRadius = maxRadius;
    }
}

public static class MassClassDictionary
{
    public static Dictionary<MassClass, MassClassSpecifications> Specifications = new Dictionary<MassClass, MassClassSpecifications>
    {
        { MassClass.Asteroidan, new MassClassSpecifications(0, 0.00001, 0, 0.03) },
        { MassClass.Mercurian, new MassClassSpecifications(0.00001, 0.1, 0.03, 0.7) },
        { MassClass.Subterran, new MassClassSpecifications(0.1, 0.5, 0.5, 1.2) },
        { MassClass.Terran, new MassClassSpecifications(0.5, 2, 0.8, 1.9) },
        { MassClass.Superterran, new MassClassSpecifications(2, 10, 1.3, 3.3) },
        { MassClass.Neptunian, new MassClassSpecifications(10, 50, 2.1, 5.7) },
        { MassClass.Jovian, new MassClassSpecifications(50, 5000, 3.5, 27) }
    };

        public static MassClass GetMassClassFromMass(double Mass)
        {
            for (int i = 0; i <= (int)MassClass.Jovian; i++)
            {
                if (Mass > Specifications[(MassClass)i].MaxMass)
                    continue;
                else
                    return (MassClass)i;
            }

            return MassClass.Asteroidan;
        }
    }

    public class Planet
    {
        public double Mass { get; }
        public double Radius { get; }

        public Planet(double initMass, double initRadius)
        {
            Mass = initMass;
            Radius = initRadius;
        }

        public MassClass GetMassClass()
        {
            return MassClassDictionary.GetMassClassFromMass(Mass);
        }
    }