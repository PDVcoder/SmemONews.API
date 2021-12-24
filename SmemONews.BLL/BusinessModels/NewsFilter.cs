using SmemONews.BLL.DTO;
using System;
using System.Collections.Generic;

namespace SmemONews.BLL.BusinessModels
{
    public class NewsFilter
    {
        public string Tag { get; set; }
        public int? HeadingId { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? SecondDate { get; set; }
        public string TitleOrName { get; set; }
    }
}
