public class Succulent
{
    public string persistentId;
    public string name;
    public string resourcePath;
    
    public float waterLevel;
    public float sunlightLevel;
    
    public float waterDecayIndex; //
    public float sunlightDecayIndex;

    public Succulent(string persistentId, string name, string resourcePath, float waterLevel, float sunlightLevel, float waterDecayIndex, float sunlightDecayIndex)
    {
        this.persistentId = persistentId;
        this.name = name;
        this.resourcePath = resourcePath;
        this.waterLevel = waterLevel;
        this.sunlightLevel = sunlightLevel;
        this.waterDecayIndex = waterDecayIndex;
        this.sunlightDecayIndex = sunlightDecayIndex;
    }

    public void update(long timeDelta)
    {
        waterLevel -= waterDecayIndex * (timeDelta/(3600F*1000F));
        sunlightLevel -= sunlightDecayIndex * (timeDelta/(3600F*1000F));
    }
    // This class does NOT need a save method for persistence, it will be part of an immutable collection that lives only at runtime.

    public override string ToString()
    {
        return "Name: " + name + " - " + "Water level: " + waterLevel + " - " + "Sunlight level: " + sunlightLevel;
    }
}