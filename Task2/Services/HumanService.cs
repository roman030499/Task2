using Microsoft.EntityFrameworkCore;
using Task2;

public class HumanService
{
    private readonly AppDbContext _context;

    public HumanService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Human> GetAllHumans()
    {
        return _context.Humans.ToList();
    }

    public Human GetHumanById(int id)
    {
        return _context.Humans.Find(id);
    }

    public void AddHuman(Human human)
    {
        _context.Humans.Add(human);
        _context.SaveChanges();
    }

    public void UpdateHuman(int id, Human human)
    {
        if (id != human.Id)
        {
            throw new ArgumentException("Invalid ID");
        }

        _context.Entry(human).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public Human DeleteHuman(int id)
    {
        var human = _context.Humans.Find(id);

        if (human == null)
        {
            return null;
        }

        _context.Humans.Remove(human);
        _context.SaveChanges();

        return human;
    }
}