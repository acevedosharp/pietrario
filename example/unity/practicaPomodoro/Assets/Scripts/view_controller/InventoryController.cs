using System;
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
    public Text inv_gua2;
    public Text inv_gua3;
    public Text inv_mus;
    public Text inv_agua;
    public void createInventory()
    {
      
        //Aqui me imagino que iran las modificaciones cuando apliquen la logica de ustedes
        
        
        //Normalmente el usuario deberia iniciar con una suculenta, de tipo 1, pero para pruebas mas adelante, se crearán
        // 3 entidades de cada item
        Inventory.updateCantidadByReferencedItem("SUC1",2);
        Inventory.updateCantidadByReferencedItem("SUC2",2);
        Inventory.updateCantidadByReferencedItem("SUC3",2);
        Inventory.updateCantidadByReferencedItem("GUA1",1);
        Inventory.updateCantidadByReferencedItem("GUA2",1);
        Inventory.updateCantidadByReferencedItem("GUA3",1);
        Inventory.updateCantidadByReferencedItem("MUS",1);
        Inventory.updateCantidadByReferencedItem("AGUA",10);
    }

    public void getInventory()
    {
        //Se actualizan los textos en el inventario general
        
        
        inv_suc1.text = "X " + Inventory.getCantidadByReferencedItem("SUC1");
        inv_suc2.text = "X " + Inventory.getCantidadByReferencedItem("SUC2");
        inv_suc3.text = "X " + Inventory.getCantidadByReferencedItem("SUC3");
        inv_gua1.text = "X " + Inventory.getCantidadByReferencedItem("GUA1");
        inv_gua2.text = "X " + Inventory.getCantidadByReferencedItem("GUA2");
        inv_gua3.text = "X " + Inventory.getCantidadByReferencedItem("GUA3");
        inv_mus.text = "X " + Inventory.getCantidadByReferencedItem("MUS");
        inv_agua.text = "X " + Inventory.getCantidadByReferencedItem("AGUA");
    }

    //Recibe un String en formato "ID.Cantidad_a_reducir"
    public void decreaseItem(string id_quantity)
    {
        //Caracteres a tener en cuenta para el Split y máximo numero de resultados que devuelve
        char[] separator = {'.'};
        int max = 2;
        //Metodo de Split devuelve un array
        string[] items = id_quantity.Split(separator,max);

        //Se guardan en variables independientes el id, el numero de items a reducir y el numero de items actuales
        string id = items[0];
        int decreaded_quantity = Int32.Parse(items[1]);
        int actual_quantity = Inventory.getCantidadByReferencedItem(id);
        
        //Se actualiza a el nuevo valor con una verificación por si algo 
        if (decreaded_quantity <= actual_quantity)
        {
            Inventory.updateCantidadByReferencedItem(id, (actual_quantity - decreaded_quantity));
            print("Ahora hay " + Inventory.getCantidadByReferencedItem(id) + " items de " + id);
        }
        else
        {
            /*Se supone que esto nunca va a pasar pues se habilitan o deshabilitan los botones dependiendo de
            si hay o no items*/
            
            print("Imposible restar esa cantidad de items");
        }


    }


}
