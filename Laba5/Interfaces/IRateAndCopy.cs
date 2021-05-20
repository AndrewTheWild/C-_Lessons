namespace Laba1.Interfaces
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();  
    }
}
