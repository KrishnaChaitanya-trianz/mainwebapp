using MainApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MainApp.bal
{
    public class TaskBal : ITaskBal
    {
        private readonly DatabaseContext _context;

        public TaskBal(DatabaseContext context)
        {
            _context = context;
        }

        public void InsertTask(Models.Task task)
        {
            _context.tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Models.Task task)
        {
            _context.tasks.Update(task);
            _context.SaveChanges();
        }
    }
}

