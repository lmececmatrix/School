using KinderGarten.Data;
using KinderGarten.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace KinderGarten.Repositories
{
    public class ClassRepository
    {
        private readonly KinderGartenContext _context;

        public ClassRepository(KinderGartenContext context) { _context = context; }

        public async Task<List<ClassModel>> GetAllClasses() 
        {
            var classes = new List<ClassModel>();
            var allclassess = await _context.Classes.ToListAsync();

            if (allclassess?.Any() == true)
            {
                foreach (var @class in allclassess)
                {
                    classes.Add(new ClassModel()
                    {
                        Id = @class.ID,
                        Name = @class.Name,
                        Description = @class.Description,
                        StartAge = @class.StartAge,
                        EndAge = @class.EndAge,
                        StartTime = @class.StartTime,
                        EndTime = @class.EndTime,
                        TotalSeats = @class.TotalSeats,
                        TutionFee = @class.TutionFee,
                        ImageUrl = @class.ImageUrl
                    });
                }
            }
            return classes; 
        }


        public async Task<List<ClassModel>> GetTopClasses(int count)
        {
            var classes = new List<ClassModel>();
            var allclassess = await _context.Classes.Take(count).ToListAsync();

            if (allclassess?.Any() == true)
            {
                foreach (var @class in allclassess)
                {
                    classes.Add(new ClassModel()
                    {
                        Id = @class.ID,
                        Name = @class.Name,
                        Description = @class.Description,
                        StartAge = @class.StartAge,
                        EndAge = @class.EndAge,
                        StartTime = @class.StartTime,
                        EndTime = @class.EndTime,
                        TotalSeats = @class.TotalSeats,
                        TutionFee = @class.TutionFee,
                        ImageUrl = @class.ImageUrl
                    });
                }
            }
            return classes;
        }

        public async Task<ClassModel> GetClassById(int id)
        {
            var @class = await _context.Classes.FindAsync(id);

            if (@class != null)
            {
                return new ClassModel()
                {
                    Id = @class.ID,
                    Name = @class.Name,
                    Description = @class.Description,
                    StartAge = @class.StartAge,
                    EndAge = @class.EndAge,
                    StartTime = @class.StartTime,
                    EndTime = @class.EndTime,
                    TotalSeats = @class.TotalSeats,
                    TutionFee = @class.TutionFee,
                    ImageUrl = @class.ImageUrl
                };
            }

            return null;
        }

        public async Task<int> Create(ClassModel model)
        {
            var @class = new Class()
            {
                ID = model.Id,
                Name = model.Name,
                Description = model.Description,
                StartAge = model.StartAge,
                EndAge = model.EndAge,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                TotalSeats = model.TotalSeats,
                TutionFee = model.TutionFee,
                ImageUrl = "/img/class-2.jpg"
            };

            await _context.Classes.AddAsync(@class);
            await _context.SaveChangesAsync();

            return @class.ID;
        }
    }
}
