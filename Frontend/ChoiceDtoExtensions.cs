using Microsoft.AspNetCore.Mvc.Rendering;
using WebAPI.DTOs.ChoiceDtos;

namespace Frontend
{
    public static class ChoiceDtoExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<ChoiceDto> choices)
        {
            return choices.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Text
            });
        }
    }
}
