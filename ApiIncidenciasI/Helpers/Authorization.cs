namespace ApiIncidenciasI.Helpers;
public class Authorization
{
    public enum Roles
    {
        Administrador,
        Empleado,
        Camper
    }
    
    public const Roles default_role = Roles.Empleado;
}