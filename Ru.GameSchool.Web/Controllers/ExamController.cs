﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ru.GameSchool.DataLayer.Repository;
using System.Web.Security;
using Ru.GameSchool.Web.Classes;

namespace Ru.GameSchool.Web.Controllers
{
    public class ExamController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = "Student, Teacher")]
        public ActionResult Index()
        {
            var exams = LevelService.GetLevelExams();

            return View(exams);
        }
        #region Student

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Get(int? LevelExamId)
        {
            if (LevelExamId.HasValue)
            {
                var exam = LevelService.GetLevelExam(LevelExamId.Value);
                return View(exam);
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult TakeExam(int? LevelExamId)
        {
            
            if (LevelExamId.HasValue)
            {
                var exam = LevelService.GetLevelExam(LevelExamId.Value);
                return View(exam);
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult TakeExam(LevelExam levelExam)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        #endregion

        #region Teacher

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GradePercentageValues = GradePercentageValue();
            ViewBag.MapCount = MapCount();
            return View();
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View();
        }

        

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public ActionResult Edit(int? LevelExamId)
        {
            ViewBag.LevelCount = GetLevelCounts();
            ViewBag.GradePercentageValue = GetPercentageValue();

            if (ModelState.IsValid)
            {
                if (LevelExamId.HasValue)
                {
                    var exam = LevelService.GetLevelExam(LevelExamId.Value);
                    return View(exam);
                }
            }
            return View();
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Edit(LevelExam levelExam)
        {
            if (ModelState.IsValid)
            {
                if (TryUpdateModel(levelExam))
                {
                    LevelService.UpdateLevelExam(levelExam);
                    ViewBag.SuccessMessage = "Upplýsingar um próf hafa verið uppfærðar";
                    return View(levelExam);
                }
                else
                {
                    ViewBag.ErrorMessage = "Náði ekki að skrá/uppfæra upplýsingar! Lagfærðu villur og reyndur aftur.";
                }
            }
            return View();
        }

        #endregion


        #region helper methods

        public IEnumerable<SelectListItem> MapCount()
        {
            for (int j = 1; j <= LevelService.GetLevels().Count(); j++)
            {
                yield return new SelectListItem
                {
                    Text = j.ToString(),
                    Value = j.ToString()
                };
            }
        }
        public IEnumerable<SelectListItem> GradePercentageValue()
        {
            for (int j = 1; j <= 100; j++)
            {
                yield return new SelectListItem
                {
                    Text = j.ToString() + "%",
                    Value = j.ToString()
                };
            }
        }
        public IEnumerable<SelectListItem> GetPercentageValue()
        {
            for (int j = 1; j <= 100; j++)
            {
                yield return new SelectListItem
                {
                    Text = j.ToString() + " %",
                    Value = j.ToString()
                };
            }
        }

        public IEnumerable<SelectListItem> GetLevelCounts()
        {
            for (int j = 0; j <= LevelService.GetLevels().Count(); j++)
            {
                var elementAtOrDefault = LevelService.GetLevels().ElementAtOrDefault(j);
                if (elementAtOrDefault != null)
                    yield return new SelectListItem
                    {
                        Text = elementAtOrDefault.Name,
                        Value = elementAtOrDefault.LevelId.ToString()
                    };
            }
        }


        private LevelExam CreateLevelExam(FormCollection collection)
        {
            return new LevelExam
            {
                GradePercentageValue = Convert.ToDouble(collection["GradePercentageValue"]),
                Description = collection["Description"],
                CreateDateTime = DateTime.Now,
                Name = collection["Name"],
                LevelId = Convert.ToInt32(collection["LevelId"]),
                LevelExamQuestions = new Collection<LevelExamQuestion>
                                     {
                                            new LevelExamQuestion
                                             {
                                                 Question = collection["question1"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer1_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check1_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer1_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check1_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer1_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check1_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer1_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check1_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question2"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer2_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check2_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer2_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check2_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer2_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check2_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer2_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check2_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question3"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer3_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check3_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer3_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check3_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer3_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check3_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer3_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check3_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question4"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer4_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check4_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer4_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check4_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer4_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check4_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer4_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check4_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question5"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer5_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check5_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer5_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check5_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer4_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check5_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer5_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check5_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question6"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer6_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check6_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer6_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check6_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer6_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check6_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer6_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check6_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question7"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer7_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check7_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer7_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check7_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer7_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check7_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer7_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check7_4"])
                                                                                }
                                                                        }
                                             },
                                                                                          new LevelExamQuestion
                                             {
                                                 Question = collection["question8"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer8_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check8_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer8_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check8_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer8_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check8_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer8_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check8_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question9"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer9_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check9_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer9_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check9_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer9_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check9_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer9_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check9_4"])
                                                                                }
                                                                        }
                                             },
                                             new LevelExamQuestion
                                             {
                                                 Question = collection["question10"],
                                                 LevelExamAnswers = new Collection<LevelExamAnswer>
                                                                        {
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer10_1"],
                                                                                    Correct = Convert.ToBoolean(collection["check10_1"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer10_2"],
                                                                                    Correct = Convert.ToBoolean(collection["check10_2"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer10_3"],
                                                                                    Correct = Convert.ToBoolean(collection["check10_3"])
                                                                                },
                                                                                new LevelExamAnswer
                                                                                {
                                                                                    Answer = collection["answer10_4"],
                                                                                    Correct = Convert.ToBoolean(collection["check10_4"])
                                                                                }
                                                                        }
                                             }
                                     }
            };
        }
        #endregion


        /*
        public ActionResult Statistics(int id)
        {
            return View();
        }*/

    }
}