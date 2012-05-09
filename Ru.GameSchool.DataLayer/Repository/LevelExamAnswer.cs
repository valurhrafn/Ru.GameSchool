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
    public partial class LevelExamAnswer
    {
        #region Primitive Properties
    
        public virtual int LevelExamAnswerId
        {
            get;
            set;
        }
    
        public virtual int LevelExamQuestionId
        {
            get { return _levelExamQuestionId; }
            set
            {
                if (_levelExamQuestionId != value)
                {
                    if (LevelExamQuestion != null && LevelExamQuestion.LevelExamQuestionId != value)
                    {
                        LevelExamQuestion = null;
                    }
                    _levelExamQuestionId = value;
                }
            }
        }
        private int _levelExamQuestionId;
    
        public virtual string Answer
        {
            get;
            set;
        }
    
        public virtual bool Correct
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual LevelExamQuestion LevelExamQuestion
        {
            get { return _levelExamQuestion; }
            set
            {
                if (!ReferenceEquals(_levelExamQuestion, value))
                {
                    var previousValue = _levelExamQuestion;
                    _levelExamQuestion = value;
                    FixupLevelExamQuestion(previousValue);
                }
            }
        }
        private LevelExamQuestion _levelExamQuestion;
    
        public virtual ICollection<UserInfo> UserInfoes
        {
            get
            {
                if (_userInfoes == null)
                {
                    var newCollection = new FixupCollection<UserInfo>();
                    newCollection.CollectionChanged += FixupUserInfoes;
                    _userInfoes = newCollection;
                }
                return _userInfoes;
            }
            set
            {
                if (!ReferenceEquals(_userInfoes, value))
                {
                    var previousValue = _userInfoes as FixupCollection<UserInfo>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUserInfoes;
                    }
                    _userInfoes = value;
                    var newValue = value as FixupCollection<UserInfo>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUserInfoes;
                    }
                }
            }
        }
        private ICollection<UserInfo> _userInfoes;

        #endregion
        #region Association Fixup
    
        private void FixupLevelExamQuestion(LevelExamQuestion previousValue)
        {
            if (previousValue != null && previousValue.LevelExamAnswers.Contains(this))
            {
                previousValue.LevelExamAnswers.Remove(this);
            }
    
            if (LevelExamQuestion != null)
            {
                if (!LevelExamQuestion.LevelExamAnswers.Contains(this))
                {
                    LevelExamQuestion.LevelExamAnswers.Add(this);
                }
                if (LevelExamQuestionId != LevelExamQuestion.LevelExamQuestionId)
                {
                    LevelExamQuestionId = LevelExamQuestion.LevelExamQuestionId;
                }
            }
        }
    
        private void FixupUserInfoes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (UserInfo item in e.NewItems)
                {
                    if (!item.LevelExamAnswers.Contains(this))
                    {
                        item.LevelExamAnswers.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserInfo item in e.OldItems)
                {
                    if (item.LevelExamAnswers.Contains(this))
                    {
                        item.LevelExamAnswers.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
