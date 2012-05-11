//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Ru.GameSchool.DataLayer.Repository
{
    public partial class Announcement
    {
        #region Primitive Properties
    
        public virtual int AnnouncementId
        {
            get;
            set;
        }
    
        public virtual string Title
        {
            get;
            set;
        }
    
        public virtual string Article
        {
            get;
            set;
        }
    
        public virtual int CourseId
        {
            get { return _courseId; }
            set
            {
                if (_courseId != value)
                {
                    if (Course != null && Course.CourseId != value)
                    {
                        Course = null;
                    }
                    _courseId = value;
                }
            }
        }
        private int _courseId;
    
        public virtual int LevelId
        {
            get { return _levelId; }
            set
            {
                if (_levelId != value)
                {
                    if (Level != null && Level.LevelId != value)
                    {
                        Level = null;
                    }
                    _levelId = value;
                }
            }
        }
        private int _levelId;
    
        public virtual System.DateTime DisplayDateTime
        {
            get;
            set;
        }
    
        public virtual int CreatedByUserInfoId
        {
            get { return _createdByUserInfoId; }
            set
            {
                if (_createdByUserInfoId != value)
                {
                    if (UserInfo != null && UserInfo.UserInfoId != value)
                    {
                        UserInfo = null;
                    }
                    _createdByUserInfoId = value;
                }
            }
        }
        private int _createdByUserInfoId;
    
        public virtual System.DateTime CreateDateTime
        {
            get;
            set;
        }
    
        public virtual string CreatedBy
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> UpdateDateTime
        {
            get;
            set;
        }
    
        public virtual string UpdatedBy
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Course Course
        {
            get { return _course; }
            set
            {
                if (!ReferenceEquals(_course, value))
                {
                    var previousValue = _course;
                    _course = value;
                    FixupCourse(previousValue);
                }
            }
        }
        private Course _course;
    
        public virtual Level Level
        {
            get { return _level; }
            set
            {
                if (!ReferenceEquals(_level, value))
                {
                    var previousValue = _level;
                    _level = value;
                    FixupLevel(previousValue);
                }
            }
        }
        private Level _level;
    
        public virtual UserInfo UserInfo
        {
            get { return _userInfo; }
            set
            {
                if (!ReferenceEquals(_userInfo, value))
                {
                    var previousValue = _userInfo;
                    _userInfo = value;
                    FixupUserInfo(previousValue);
                }
            }
        }
        private UserInfo _userInfo;

        #endregion
        #region Association Fixup
    
        private void FixupCourse(Course previousValue)
        {
            if (previousValue != null && previousValue.Announcements.Contains(this))
            {
                previousValue.Announcements.Remove(this);
            }
    
            if (Course != null)
            {
                if (!Course.Announcements.Contains(this))
                {
                    Course.Announcements.Add(this);
                }
                if (CourseId != Course.CourseId)
                {
                    CourseId = Course.CourseId;
                }
            }
        }
    
        private void FixupLevel(Level previousValue)
        {
            if (previousValue != null && previousValue.Announcements.Contains(this))
            {
                previousValue.Announcements.Remove(this);
            }
    
            if (Level != null)
            {
                if (!Level.Announcements.Contains(this))
                {
                    Level.Announcements.Add(this);
                }
                if (LevelId != Level.LevelId)
                {
                    LevelId = Level.LevelId;
                }
            }
        }
    
        private void FixupUserInfo(UserInfo previousValue)
        {
            if (previousValue != null && previousValue.Announcements.Contains(this))
            {
                previousValue.Announcements.Remove(this);
            }
    
            if (UserInfo != null)
            {
                if (!UserInfo.Announcements.Contains(this))
                {
                    UserInfo.Announcements.Add(this);
                }
                if (CreatedByUserInfoId != UserInfo.UserInfoId)
                {
                    CreatedByUserInfoId = UserInfo.UserInfoId;
                }
            }
        }

        #endregion
    }
}
