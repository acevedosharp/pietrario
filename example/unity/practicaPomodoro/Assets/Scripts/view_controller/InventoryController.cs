using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public Text inv_suc1;
    public Text inv_suc2;
    public Text inv_suc3;
    public Text inv_gua1;

    public void createInventory()
    {
      
        //Aqui me imagino que iran las modificaciones cuando apliquen la logica de ustedes
        
        
        //Normalmente el usuario deberia iniciar con una suculenta, de tipo 1, pero para pruebas mas adelante, se crearán
        // 3 entidades de cada item
        Inventory.addCantidadByReferencedItem("SUC1",3);
        Inventory.addCantidadByReferencedItem("SUC2",3);
        Inventory.addCantidadByReferencedItem("SUC3",3);
        Inventory.addCantidadByReferencedItem("GUA1",3);
    }

    public void getInventory()
    {
        //Se actualizan los textos en el inventario general
        
        
        inv_suc1.text = "X " + Inventory.getCantidadByReferencedItem("SUC1");
        inv_suc2.text = "X " + Inventory.getCantidadByReferencedItem("SUC2");
        inv_suc3.text = "X " + Inventory.getCantidadByReferencedItem("SUC3");
        inv_gua1.text = "X " + Inventory.getCantidadByReferencedItem("GUA1");

    }


}
