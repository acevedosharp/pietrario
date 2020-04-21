using UnityEngine;

namespace persistence.entities
{
    public class Pietrario
    {
        public int id;
        public string Name;
        public int S1, S2, S3;

        public Pietrario(int id, string name, int s1, int s2, int s3)
        {
            this.id = id;
            Name = name;
            S1 = s1;
            S2 = s2;
            S3 = s3;
        }

        // This class needs a save method for persistence
        public void Save()
        {
            PlayerPrefs.SetInt("id_pietrario_" + id, id);
            PlayerPrefs.SetString("nombre_pietrario_" + id, Name);
            PlayerPrefs.SetInt("id_suc_1_piet" + id, S1);
            PlayerPrefs.SetInt("id_suc_2_piet" + id, S2);
            PlayerPrefs.SetInt("id_suc_3_piet" + id, S3);
        }
    }
}