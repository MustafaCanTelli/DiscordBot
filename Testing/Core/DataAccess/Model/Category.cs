﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Descriptoin { get; set; }

    }
}
