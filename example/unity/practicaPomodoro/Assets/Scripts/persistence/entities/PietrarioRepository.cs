using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

//Clase que permite tener varios prietrarios
public class PietrarioRepository {
    public static void AddPietrario(Pietrario pietrario) {
        Debug.Log("Executed AddPietrario()");

        pietrario.id = assignId();
        pietrario.Save();
        //Debug.Log("Pietrario "+ pietrario.ToString());
        LoadPietrarios();
    }
    //Asigna un id a cada pietario
    public static int assignId() {
        int globalIdCounter = PlayerPrefs.GetInt("GLOBAL_ID_COUNTER");
        int newId = globalIdCounter + 1;
        PlayerPrefs.SetInt("GLOBAL_ID_COUNTER", newId);
        return newId;
    }


    //Carga TODOS los pietrarios existentes y los añade a memoria

    public static ArrayList LoadPietrarios() {
        //Debug.Log("Executed LoadPietrarios()");

        ArrayList result = new ArrayList();

        int idCounter = 1;

        while (PlayerPrefs.GetInt("id_pietrario_" + idCounter) != 0) {
            Succulent s1Obj = null;
            Succulent s2Obj = null;
            Succulent s3Obj = null;
            Guardian guardian = null;

            string s1Snapshot = PlayerPrefs.GetString("id_suc_1_piet_" + 1);
            if (!s1Snapshot.Equals("null"))
                s1Obj = SucculentRepository.find(s1Snapshot);

            string s2Snapshot = PlayerPrefs.GetString("id_suc_2_piet_" + 1);
            if (!s2Snapshot.Equals("null"))
                s2Obj = SucculentRepository.find(s2Snapshot);

            string s3Snapshot = PlayerPrefs.GetString("id_suc_3_piet_" + 1);
            if (!s3Snapshot.Equals("null"))
                s3Obj = SucculentRepository.find(s3Snapshot);
            string guardianSnapShot = PlayerPrefs.GetString("idGuardian " + 1);
            if (!guardianSnapShot.Equals("null")) {
                guardian = GuardianRepository.find(guardianSnapShot);
            }

            // Create and add existing Pietrarios to memory.
            Pietrario p = new Pietrario(
                PlayerPrefs.GetInt("id_pietrario_" + 1),
                PlayerPrefs.GetString("nombre_pietrario_" + 1),
                long.Parse(PlayerPrefs.GetString("last_timestamp_piet_" + 1)),
                PlayerPrefs.GetFloat("humidity_level_piet_" + 1),
                s1Obj,
                s2Obj,
                s3Obj,
                PlayerPrefs.GetFloat("s1wl_piet_" + 1),
                PlayerPrefs.GetFloat("s2wl_piet_" + 1),
                PlayerPrefs.GetFloat("s3wl_piet_" + 1),

                long.Parse(PlayerPrefs.GetString("dtS1 " + 1)),
                long.Parse(PlayerPrefs.GetString("dtS2 " + 1)),
                long.Parse(PlayerPrefs.GetString("dtS3 " + 1)),
                long.Parse(PlayerPrefs.GetString("dtL" + 1)),
                PlayerPrefs.GetFloat("sunLightLevel " + 1),
                PlayerPrefs.GetFloat("decaySunLightLevel " + 1),
                guardian
            );
            result.Add(p);

            idCounter++;
        }

        return result;
    }


    //Valida la existencia de pietrarios.
    public static bool existsAnyPietrario() {
        // If there the first Pietrario always has an id of 1.
        if (PlayerPrefs.GetInt("id_pietrario_" + 1) != 0)
            return true;

        return false;
    }

    //Resetea la aplicación, dejandola de fábrica
    public static void Reset() {
        PlayerPrefs.DeleteAll();
    }
}