using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Guardianes en disponinbilidad
public class GuardianRepository {
    // Acá se añaden los guardianes.
    public static Guardian[] guardianes = {
        new Guardian("GUA1", "Tigrito", "Miau"),
        new Guardian("GUA2", "Lobito", "Guau"),
        new Guardian("GUA3", "Zorrito", "Ffff")
    };

    public static Guardian find(string id) {
        // Es importante retornar una copia de el guardian (no una referencia), puesto que sobre esta se van a realizar algunas operaciones y no queremos modificar los objetos de este repositorio.
        Guardian referencedGuardian = guardianes.First(g => g.id.Equals(id));
        return new Guardian(
            referencedGuardian.id,
            referencedGuardian.name,
            referencedGuardian.mensaje
        );
    }
}