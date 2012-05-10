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
    public partial class Level
    {
        #region Primitive Properties
    
        public virtual int LevelId
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
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual System.DateTime Start
        {
            get;
            set;
        }
    
        public virtual System.DateTime Stop
        {
            get;
            set;
        }
    
        public virtual System.DateTime CreateDateTime
        {
            get;
            set;
        }
    
        public virtual int OrderNum
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
    
        public virtual ICollection<LevelMaterial> LevelMaterials
        {
            get
            {
                if (_levelMaterials == null)
                {
                    var newCollection = new FixupCollection<LevelMaterial>();
                    newCollection.CollectionChanged += FixupLevelMaterials;
                    _levelMaterials = newCollection;
                }
                return _levelMaterials;
            }
            set
            {
                if (!ReferenceEquals(_levelMaterials, value))
                {
                    var previousValue = _levelMaterials as FixupCollection<LevelMaterial>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLevelMaterials;
                    }
                    _levelMaterials = value;
                    var newValue = value as FixupCollection<LevelMaterial>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLevelMaterials;
                    }
                }
            }
        }
        private ICollection<LevelMaterial> _levelMaterials;
    
        public virtual ICollection<LevelProject> LevelProjects
        {
            get
            {
                if (_levelProjects == null)
                {
                    var newCollection = new FixupCollection<LevelProject>();
                    newCollection.CollectionChanged += FixupLevelProjects;
                    _levelProjects = newCollection;
                }
                return _levelProjects;
            }
            set
            {
                if (!ReferenceEquals(_levelProjects, value))
                {
                    var previousValue = _levelProjects as FixupCollection<LevelProject>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLevelProjects;
                    }
                    _levelProjects = value;
                    var newValue = value as FixupCollection<LevelProject>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLevelProjects;
                    }
                }
            }
        }
        private ICollection<LevelProject> _levelProjects;
    
        public virtual ICollection<Point> Points
        {
            get
            {
                if (_points == null)
                {
                    var newCollection = new FixupCollection<Point>();
                    newCollection.CollectionChanged += FixupPoints;
                    _points = newCollection;
                }
                return _points;
            }
            set
            {
                if (!ReferenceEquals(_points, value))
                {
                    var previousValue = _points as FixupCollection<Point>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPoints;
                    }
                    _points = value;
                    var newValue = value as FixupCollection<Point>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPoints;
                    }
                }
            }
        }
        private ICollection<Point> _points;
    
        public virtual ICollection<LevelExam> LevelExams
        {
            get
            {
                if (_levelExams == null)
                {
                    var newCollection = new FixupCollection<LevelExam>();
                    newCollection.CollectionChanged += FixupLevelExams;
                    _levelExams = newCollection;
                }
                return _levelExams;
            }
            set
            {
                if (!ReferenceEquals(_levelExams, value))
                {
                    var previousValue = _levelExams as FixupCollection<LevelExam>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLevelExams;
                    }
                    _levelExams = value;
                    var newValue = value as FixupCollection<LevelExam>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLevelExams;
                    }
                }
            }
        }
        private ICollection<LevelExam> _levelExams;
    
        public virtual ICollection<Announcement> Announcements
        {
            get
            {
                if (_announcements == null)
                {
                    var newCollection = new FixupCollection<Announcement>();
                    newCollection.CollectionChanged += FixupAnnouncements;
                    _announcements = newCollection;
                }
                return _announcements;
            }
            set
            {
                if (!ReferenceEquals(_announcements, value))
                {
                    var previousValue = _announcements as FixupCollection<Announcement>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAnnouncements;
                    }
                    _announcements = value;
                    var newValue = value as FixupCollection<Announcement>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAnnouncements;
                    }
                }
            }
        }
        private ICollection<Announcement> _announcements;

        #endregion
        #region Association Fixup
    
        private void FixupCourse(Course previousValue)
        {
            if (previousValue != null && previousValue.Levels.Contains(this))
            {
                previousValue.Levels.Remove(this);
            }
    
            if (Course != null)
            {
                if (!Course.Levels.Contains(this))
                {
                    Course.Levels.Add(this);
                }
                if (CourseId != Course.CourseId)
                {
                    CourseId = Course.CourseId;
                }
            }
        }
    
        private void FixupLevelMaterials(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LevelMaterial item in e.NewItems)
                {
                    item.Level = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LevelMaterial item in e.OldItems)
                {
                    if (ReferenceEquals(item.Level, this))
                    {
                        item.Level = null;
                    }
                }
            }
        }
    
        private void FixupLevelProjects(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LevelProject item in e.NewItems)
                {
                    item.Level = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LevelProject item in e.OldItems)
                {
                    if (ReferenceEquals(item.Level, this))
                    {
                        item.Level = null;
                    }
                }
            }
        }
    
        private void FixupPoints(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Point item in e.NewItems)
                {
                    item.Level = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Point item in e.OldItems)
                {
                    if (ReferenceEquals(item.Level, this))
                    {
                        item.Level = null;
                    }
                }
            }
        }
    
        private void FixupLevelExams(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LevelExam item in e.NewItems)
                {
                    item.Level = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LevelExam item in e.OldItems)
                {
                    if (ReferenceEquals(item.Level, this))
                    {
                        item.Level = null;
                    }
                }
            }
        }
    
        private void FixupAnnouncements(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Announcement item in e.NewItems)
                {
                    item.Level = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Announcement item in e.OldItems)
                {
                    if (ReferenceEquals(item.Level, this))
                    {
                        item.Level = null;
                    }
                }
            }
        }

        #endregion
    }
}
