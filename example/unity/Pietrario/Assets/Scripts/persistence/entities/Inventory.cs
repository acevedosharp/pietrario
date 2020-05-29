using UnityEngine;


//Clase de manejo de inventario
public class Inventory {
    // El id inicia con GUA para guardianes y con SUC para suculentas
    public static int getCantidadByReferencedItem(string refId) {
        return PlayerPrefs.GetInt("inv_quantity_" + refId);
    }

    public static void updateCantidadByReferencedItem(string refId, int cantidad) {
        PlayerPrefs.SetInt("inv_quantity_" + refId, cantidad);
    }
}