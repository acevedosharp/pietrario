
    public class Succulent
    {
        public int id;
        public string Name;
        public string ResourcePath;
        public float WaterIndex;
        public float SunLightIndex;

        public Succulent(string name, string resourcePath, float waterIndex, float sunLightIndex)
        {
            Name = name;
            ResourcePath = resourcePath;
            WaterIndex = waterIndex;
            SunLightIndex = sunLightIndex;
        }
        
        // This class does NOT need a save method for persistence, it will be an immutable collection that lives only at runtime.
    }
