using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class ProfileImage
    {
        public string Height { get; set; }
        public string Width { get; set; }

        public string ClassName { get; set; }

        public int UserId { get; set; }

        public string ImageName{ get;set;}


    }
}