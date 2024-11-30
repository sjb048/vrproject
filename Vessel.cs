using System;


public class Vessel
{
    private string name;
    private string yearBuilt;
    private Speed speed;

    public Vessel(string name, string yearBuilt)
    {
        if (name == "NULL" || (DateTime.Now.Year - int.Parse(yearBuilt)) > 20)
            throw new OldShipException("Vessel is old or name can't be null .");

        this.name = name;
        this.yearBuilt = yearBuilt;
    }

    public string GetName()
    {
        return name;
    }

    public string GetYearBuilt()
    {
        return yearBuilt;
    }

    public Speed GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(Speed speed)
    {
        this.speed = speed;
    }

    public override string ToString()
    {
        return $"Vessel: {name} ({yearBuilt})";
    }
}

public class Ferry : Vessel
{
    public int passengers;

    public Ferry(string name, string yearBuilt, int passengers) : base(name, yearBuilt)
    {
        this.passengers = passengers;
    }

    public int GetPassengers()
    {
        return passengers;
    }

    public override string ToString()
    {
        return base.ToString() + $", Passengers: {passengers}";
    }
}

public class Tugboat : Vessel
{
    private int maxForce;

    public Tugboat(string name, string yearBuilt, int maxForce) : base(name, yearBuilt)
    {
        this.maxForce = maxForce;
    }

    public int GetMaxForce()
    {
        return maxForce;
    }

    public override string ToString()
    {
        return base.ToString() + $", Max Force: {maxForce}";
    }
}

public class Submarine : Vessel
{
    private int maxDepth;

    public Submarine(string name, string yearBuilt, int maxDepth) : base(name, yearBuilt)
    {
        this.maxDepth = maxDepth;
    }

    public int GetMaxDepth()
    {
        return maxDepth;
    }

    public override string ToString()
    {
        return base.ToString() + $", Max Depth: {maxDepth}";
    }
}

public class Speed : IFormattable
{
    private double knots;

    public Speed(double knots)
    {
        this.knots = knots;
    }

    public double GetKnots()
    {
        return knots;
    }

    public double GetMetersPerSecond()
    {
        return knots * 0.5144;
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (format == "MS")
            return GetMetersPerSecond().ToString() + " m/s";
        else if (format == "KN")
            return GetKnots().ToString() + " knots";
        else
            return GetKnots().ToString() + " knots";
    }
}

public class OldShipException : Exception
{
    public OldShipException(string message) : base(message) { }
}
