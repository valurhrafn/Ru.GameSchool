﻿using Ru.GameSchool.DataLayer;
using System.Collections.Generic;

namespace Ru.GameSchool.BusinessLayer.Services
{
    /// <summary>
    /// Service class that abstracts the interraction around the course entity with the data layer.
    /// </summary> 
    public class CourseService : BaseService
    {
        public void CreateLevel(Level level)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLevel(Level level)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLevel(Level level)
        {
            throw new System.NotImplementedException();
        }
        
        public void CreateLevelExam(LevelExam LevelExam)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLevelExam(LevelExam LevelExam)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLevelExam(LevelExam LevelExam)
        {
            throw new System.NotImplementedException();
        }

        public void CreateLevelProject(LevelProject levelProject)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLevelProject(LevelProject levelProject)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLevelProject(LevelProject levelProject)
        {
            throw new System.NotImplementedException();
        }

        public void AddCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public void AddLevelExamResult(LevelExamResult LevelExamResult)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLevelExamResult(LevelExamResult LevelExamResult)
        {
            throw new System.NotImplementedException();
        }

        public LevelExamResult GetLevelExamResults(int LevelExamResultId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLevelExamResults(LevelExamResult LevelExamResult)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserToCourse(UserInfo user, Course course)
        {
            throw new System.NotImplementedException();
        }

        public void AddCourseGrade(CourseGrade courseGrade)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCourseGrade(CourseGrade courseGrade)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CourseGrade> GetCourseGrades()
        {
            throw new System.NotImplementedException();
        }

        public void AddLevelExamQuestion(LevelExamQuestion LevelExamQuestion)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLevelExamQuestion(LevelExamQuestion LevelExamQuestion)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLevelExamQuestion(LevelExamQuestion LevelExamQuestion)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LevelExamQuestion> GetLevelExamQuestions()
        {
            throw new System.NotImplementedException();
        }

        public void AddUserLevelExamResult(LevelExamResult LevelExamResult, UserInfo user)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserProjectResult(LevelProjectResult levelProjectResult, UserInfo user)
        {
            throw new System.NotImplementedException();
        }

        public void GetCurrentUserLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}
