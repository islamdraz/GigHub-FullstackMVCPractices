using FullStackCourse1.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GigHub.Model.Models;

namespace FullStackCourse1.Core.ViewModels
{
    public class GigViewModel
    {
        //public DateTime DateTime
        //{
        //    get
        //    {
        //        return DateTime.Parse(String.Format("{0} {1}", this.Date, this.Time));
        //    }
        //}

        public int Id { get; set; }
        public DateTime GetDateTime()
        {
            
                return DateTime.Parse(String.Format("{0} {1}", this.Date, this.Time));
            
        }
        [Required]
        public string Venue { get; set; }

        [Required]
        [ValideDate]
        public string Date { get; set; }

        [Required]
        [ValideTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Action
        {
            get
            {

               Expression< Func<GigsController, ActionResult>> update = (c => c.Update(this));
                Expression < Func < GigsController, ActionResult>> create = (c => c.Create(this));


                var Action = (Id != 0) ? update : create;
                return (Action.Body as MethodCallExpression).Method.Name;

            }
        }

        public string Heading { get; set; }
    }
}