
    public class Succulent
    {

        public string name;
        public float WaterIndex;
        public float SunLightIndex;

        public Succulent(string name, float waterIndex, float sunLightIndex)
        {
            this.name = name;
            this.WaterIndex = waterIndex;
            this.SunLightIndex = sunLightIndex;
        }
        
        // This class does NOT need a save method for persistence, it will be an immutable collection that lives only at runtime.
    }
