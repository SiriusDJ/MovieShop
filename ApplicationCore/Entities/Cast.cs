﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        
        public string Gender { get; set; }

        public string TmdbUrl { get; set; }


        public string ProfilePath { get; set; }

        public ICollection<MovieCast> CastsofMovie { get; set; }  

    }
}