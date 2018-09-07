using System;
using Vuighe.Service.Interfaces;

namespace Vuighe.Service.Dtos
{
    public class BaseDto: IDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}