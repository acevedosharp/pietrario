using System.Linq;
//suculentas en disponinbilidad

public class SucculentRepository
{
    // Acá se añaden las suculentas.
    public static Succulent[] Suculentas =
    {
        new Succulent("SUC1", "Cáctus", "/", 100F, 1f),
        new Succulent("SUC2", "Cac2", "/", 100F, 1f),
        new Succulent("SUC3", "Mushroom", "/", 100F, 1f)
    };

    public static Succulent find(string persistentId)
    {
        // Es importante retornar una copia de la Suculenta (no una referencia), puesto que sobre esta se van a realizar algunas operaciones y no queremos modificar los objetos de este repositorio.
        Succulent referencedSucculent = Suculentas.First(succulent => succulent.persistentId.Equals(persistentId));
        return new Succulent(
            referencedSucculent.persistentId,
            referencedSucculent.name,
            referencedSucculent.resourcePath,
            referencedSucculent.waterLevel,
            referencedSucculent.waterDecayIndex
        );
    }
}
