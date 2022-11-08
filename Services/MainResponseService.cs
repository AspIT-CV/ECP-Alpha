﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MainResponseService
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Content { get; set; }
    }
}
