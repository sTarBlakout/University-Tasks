
using System.Numerics;

public interface IVector
{
    double abs();
    double cdot(IVector v);
    double[] getComponents();
}

public class Vector2D : IVector
{
    protected double x;
    protected double y;

    public double abs()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public double cdot(IVector v)
    {
        return v.getComponents()[0] * x + v.getComponents()[1] * y;
    }

    public double[] getComponents()
    {
        return new double[2] {x, y};
    }
}

#region Polar2D

    public interface IPolar2D
    {
        double getAngle();
        double abs();
    }

    public class Polar2DAdapter : IVector, IPolar2D
    {
        private Vector2D srcVector;

        public double abs()
        {
            return srcVector.abs();
        }

        public double cdot(IVector v)
        {
            return (srcVector.cdot(v));
        }

        public double getAngle()
        {
            return Math.Atan2(-srcVector.getComponents()[1], srcVector.getComponents()[0]) * (Math.PI / 180.0);
        }

        public double[] getComponents()
        {
            return srcVector.getComponents();
        }
    }

    public class Polar2DInheritance : Vector2D
    {
        public double GetAngle()
        {
            return Math.Atan2(-y, x) * (Math.PI / 180.0);
        }
    }

#endregion

#region Vector 3D

public class Vector3DDecorator : IVector
{
    private IVector srcVector;
    private double z;

    public double abs()
    {
        var x = srcVector.getComponents()[0];
        var y = srcVector.getComponents()[1];
        return Math.Sqrt(x * x + y * y + z * z);
    }

    public double cdot(IVector v)
    {
        var x = srcVector.getComponents()[0];
        var y = srcVector.getComponents()[1];
        var x1 = v.getComponents()[0];
        var y1 = v.getComponents()[1];
        var z1 = v.getComponents()[2];
        return (x * x1 + y * y1 + z * z1);
    }

    public double[] getComponents()
    {
        return new double[3] { srcVector.getComponents()[0], srcVector.getComponents()[1], z };
    }

    private Vector3 cross(IVector v)
    {
        var v1 = new Vector3();
        v1.X = (float) srcVector.getComponents()[0];
        v1.Y = (float) srcVector.getComponents()[1];
        v1.Z = (float) z;
        var v2 = new Vector3();
        v2.X = (float) v.getComponents()[0];
        v2.Y = (float) v.getComponents()[1];
        v2.Z = (float) v.getComponents()[2];
        return Vector3.Multiply(v1, v2);
    }

    private IVector getSrcV()
    {
        return srcVector;
    }
}

public class Vector3DInheritance : Vector2D
{
    private double z;

    public double abs()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    public double cdot(IVector v)
    {
        var x1 = v.getComponents()[0];
        var y1 = v.getComponents()[1];
        var z1 = v.getComponents()[2];
        return (x * x1 + y * y1 + z * z1);
    }

    public double[] getComponents()
    {
        return new double[3] { x, y, z };
    }

    private Vector3 cross(IVector v)
    {
        var v1 = new Vector3();
        v1.X = (float)x;
        v1.Y = (float)y;
        v1.Z = (float)z;
        var v2 = new Vector3();
        v2.X = (float)v.getComponents()[0];
        v2.Y = (float)v.getComponents()[1];
        v2.Z = (float)v.getComponents()[2];
        return Vector3.Multiply(v1, v2);
    }

    private IVector getSrcV()
    {
        return this;
    }
}

#endregion
