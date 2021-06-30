using IsTakipSureci.Business.Interfaces;
using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.TagHelpers
{
    [HtmlTargetElement("GetWorkByUserId")]
    public class WorkAppUserIdTagHelper:TagHelper
    {
        private readonly IWorkService _workService;
        public WorkAppUserIdTagHelper(IWorkService workService)
        {
            _workService = workService;
        }

        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           List<Work> works =  _workService.GetByUserId(AppUserId);

            int completed =works.Where(x => x.Status).Count();

            int ongoing = works.Where(x => x.Status == false).Count();

            string htmlString = $"<strong> Tamamladığı Görev Sayısı :  </strong>{completed} <br> <strong>Devam Eden Görevler : </strong>{ongoing}";

            output.Content.SetHtmlContent(htmlString);

        }
    }
}
