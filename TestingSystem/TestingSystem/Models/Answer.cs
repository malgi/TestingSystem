﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingSystem.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}