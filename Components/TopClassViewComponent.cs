using KinderGarten.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Components
{
    public class TopClassViewComponent : ViewComponent
    {
        private readonly ClassRepository _classRepository;

        public TopClassViewComponent(ClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public  async Task<IViewComponentResult> InvokeAsync(int count)
        {
            return View(await _classRepository.GetTopClasses(count));
        }
    }
}
