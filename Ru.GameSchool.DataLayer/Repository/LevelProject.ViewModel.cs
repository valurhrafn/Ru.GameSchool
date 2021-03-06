﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ru.GameSchool.DataLayer.Interfaces;

namespace Ru.GameSchool.DataLayer.Repository
{
    [MetadataType(typeof(LevelProjectMetadata))]
    public partial class LevelProject : IListObject
    {
        [Display(Name = "Skrá")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }

        public bool IsNew()
        {
            return Start.AddHours(23) >= DateTime.Now;
        }

        public string ItemName()
        {
            return Name;
        }

        public DateTime Date()
        {
            return Start;
        }

        public string ItemUrl()
        {
            return string.Format("/Project/Index/{0}", Level.CourseId);
        }

        public bool IsReturned(int userInfoId)
        {
            return _levelProjectResults.Where(x => x.UserInfoId == userInfoId).Count() > 0;
        }

    }
    public class LevelProjectMetadata
    {
        [Required(ErrorMessage = "Vantar byrjunardagsetningu.")]
        [Display(Name = "Byrjunardagsetning")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Vantar endadagsetningu.")]
        [Display(Name = "Endadagsetning")]
        [DataType(DataType.DateTime)]
        public DateTime Stop { get; set; }

        [Required(ErrorMessage = "Vantar lýsingu.")]
        [Display(Name = "Lýsing")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Verður að velja vægi.")]
        [Display(Name = "Vægi")]
        public double GradePercentageValue { get; set; }

        [Required(ErrorMessage = "Vantar nafn.")]
        [Display(Name = "Nafn")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Verður að velja borð")]
        [Display(Name = "Borð")]
        public int LevelId { get; set; }

        [Display(Name = "Athugasemd til kennara")]
        [DataType(DataType.MultilineText)]
        public string UserFeedback { get; set; }

        [Display(Name = "Viðhengi")]
        public Guid ContentID { get; set; }

    }
}
