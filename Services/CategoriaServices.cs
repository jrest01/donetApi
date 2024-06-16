using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Models;

public class CategoriaServices : ICategoriaServices
{
    TareasContext context;

    public CategoriaServices(TareasContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoria == null)
        {
            throw new Exception("Not found");
        }
        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion = categoria.Descripcion;
        categoriaActual.Peso = categoria.Peso;
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual == null)
        {
            throw new Exception("Not found");
        }
        context.Remove(categoriaActual);
        await context.SaveChangesAsync();
    }
}

public interface ICategoriaServices
{
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}