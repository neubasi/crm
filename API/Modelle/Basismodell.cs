﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelle
{
    public class Basismodell
    {
        [Key]
        public long Id { get; set; }
    }
}
