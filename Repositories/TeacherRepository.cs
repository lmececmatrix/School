using KinderGarten.Data;
using KinderGarten.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace KinderGarten.Repositories
{
    public class TeacherRepository
    {
        private readonly KinderGartenContext _context;

        public TeacherRepository(KinderGartenContext context) { _context = context; }

        public async Task<List<TeacherModel>> GetAllTeachers()
        {
            var teachers = new List<TeacherModel>();
            var allTeachers = await _context.Teachers.ToListAsync();

            if (allTeachers?.Any() == true)
            {
                foreach (var teacher in allTeachers)
                {
                    teachers.Add(new TeacherModel()
                    {
                        Name = teacher.Name,
                        //ImageUrl = teacher.ImageUrl,
                        Subject = teacher.Subject,
                        Social = teacher.Social
                    });
                }
            }
            return teachers;
        }

        public async Task<TeacherModel> GetClassById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher != null)
            {
                return new TeacherModel()
                {
                    Name = teacher.Name,
                    ImageUrl = teacher.ImageUrl,
                    Subject = teacher.Subject,
                    Social = teacher.Social
                };
            }

            return null;
        }

        public async Task<int> Create(TeacherModel model)
        {
            var teacher = new Teacher()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Subject = model.Subject,
                Social = model.Social
            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return teacher.Id;
        }
    }
}
