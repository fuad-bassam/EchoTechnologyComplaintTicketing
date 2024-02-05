using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Models.Generic
{
    public class PageInfo<T>
    {
        [Range(0, short.MaxValue, ErrorMessage = "The Page Number must be between 0 and 32767.")]
        public short pageNumber { get; set; }
        [Range(1, short.MaxValue, ErrorMessage = "The Page Size must be between 1 and 32767.")]
        public short pageSize { get; set; }
        public T content { set; get; }
    }
}
