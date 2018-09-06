﻿using System;

namespace Cuda.Service.Interfaces
{
    public interface IDto
    {
        Guid Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime UpdatedDate { get; set; }
    }
}