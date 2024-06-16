using webapi;
using webapi.Models;

public class TareaServices : ITareaServices
{
    TareasContext context;

    public TareaServices(TareasContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea newTarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual == null)
        {
            throw new Exception("Id not found");
        }
        tareaActual.Titulo = newTarea.Titulo;
        tareaActual.Descripcion = newTarea.Descripcion;
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        Tarea tarea = context.Tareas.Find(id);
        if (tarea == null)
        {
            throw new Exception("Id not found");
        }
        context.Remove(tarea);
        await context.SaveChangesAsync();
    }

}
public interface ITareaServices
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea newTarea);
    Task Delete(Guid id);
}