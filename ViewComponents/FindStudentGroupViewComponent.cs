using Microsoft.AspNetCore.Mvc;
using Weblab2.Models;

namespace Weblab2.ViewComponents
{
    [ViewComponent]
    public class FindStudentGroupViewComponent: ViewComponent
    {
        private readonly _8i12LozhkomoevContext _context;

        public FindStudentGroupViewComponent(_8i12LozhkomoevContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid studentId)
        {
            using (var context = new _8i12LozhkomoevContext())
            {
                var groupId = context.StudentInGroups
                             .Where(s => s.StudentId == studentId)
                             .Select(s => s.GroupId)
                             .FirstOrDefault();
                string? groupName = _context.Groups.Find(groupId)?.Name;
                if (groupName != null)
                {
                    return View("Default", groupName);
                }
                return View("Default", "No group");
            }
        }
    }
}
