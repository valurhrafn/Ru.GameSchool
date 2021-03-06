﻿using System.Data;
using System.Linq;
using Ru.GameSchool.BusinessLayer.Enums;
using Ru.GameSchool.DataLayer;
using System.Collections.Generic;
using Ru.GameSchool.DataLayer.Repository;
using Ru.GameSchool.Utilities;
using System;

namespace Ru.GameSchool.BusinessLayer.Services
{
    /// <summary>
    /// Service class that abstracts the interraction around the user entity with the data layer.
    /// </summary> 
    public class UserService : BaseService
    {
        /// <summary>
        /// Gets a user by userId
        /// </summary>
        /// <param name="userId">Id of the user to get.</param>
        /// <returns>A user instance.</returns>
        public UserInfo GetUser(int userId)
        {
            var user = from x in GameSchoolEntities.UserInfoes
                       where x.UserInfoId == userId
                       select x;

            return user.FirstOrDefault();
        }

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>A user instance.</returns>
        public UserInfo GetUser(string username)
        {
            var user = from x in GameSchoolEntities.UserInfoes
                       where x.Username == username
                       select x;

            return user.FirstOrDefault();
        }

        /// <summary>
        /// Returns a collection of userinfo instances.
        /// </summary>
        /// <returns>IEnumerable of userinfo instances.</returns>
        public IEnumerable<UserInfo> GetUsers()
        {
            var userInfoList = from x in GameSchoolEntities.UserInfoes
                               select x;

            return userInfoList;
        }

        /// <summary>
        /// Confirms that user credentials are authentic
        /// </summary>
        /// <param name="userName">The username reserved for the user to login to GameSchool.</param>
        /// <param name="password">Password to confirm the user is allowed to log into given username.</param>
        /// <returns>A new user instance.</returns>
        public UserInfo Login(string userName, string password, string ipAddress)
        {
            if ((string.IsNullOrWhiteSpace(userName)) || (string.IsNullOrWhiteSpace(password)))
            {
                return null;
            }

            var userQuery = from x in GameSchoolEntities.UserInfoes
                            where x.Username == userName
                            select x;

            var userInfo = userQuery.FirstOrDefault();

            //User not found, return null;
            if (userInfo == null)
            {
                return null;
            }

            // Compare user entered clear text password to hashed value in db
            if (!PasswordUtilities.VerifyHash(password, userInfo.Password))
            {
                return null; // Password don't match, return null.
            }


            //Check if user status is active, If it's inactive we return null
            if (userInfo.StatusId != (int)UserStatus.Active)
            {
                return null;
            }

            var userLog = new UserLog
                                  {
                                      IpAddress = ipAddress,
                                      LoginTime = DateTime.Now,
                                      UserInfoId = userInfo.UserInfoId
                                  };

            this.CreateUserLog(userLog);

            return userInfo;
        }

        /// <summary>
        /// Change the password of a userinfo instance.
        /// </summary>
        /// <param name="newPassword">Clear text password that a user entered.</param>
        /// <param name="userInfoId">Id of a userinfo object.</param>
        public void ChangeUserInfoPassword(string newPassword, int userInfoId)
        {
            var query = GameSchoolEntities.UserInfoes.Where(u => u.UserInfoId == userInfoId);

            var user = query.FirstOrDefault();
            // Hash new user entered password
            var newHashedPassword = PasswordUtilities.ComputeHash(newPassword);
            user.Password = newHashedPassword; // Add password to datasource
            // Persist changes to datasource.
            Save();

            if (ExternalNotificationContainer != null)
            {
                ExternalNotificationContainer.CreateNotification("Lykilorði þínu hefur verið breytt.", "", userInfoId);
            }
        }

        /// <summary>
        /// Gets a userinfo instance through a parameter of this function and if it isn't null persist it to the database.
        /// </summary>
        /// <param name="userInfo">Instance of a userinfo</param>
        public void CreateUser(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                // Get user entered clear text password and hash it before storing in db
                var hashedPasswrd = PasswordUtilities.ComputeHash(userInfo.Password);
                userInfo.Password = hashedPasswrd;
                userInfo.CreateDateTime = DateTime.Now;
                GameSchoolEntities.UserInfoes.AddObject(userInfo);
                Save();
            }
        }

        /// <summary>
        /// Creates user log
        /// </summary>
        /// <param name="userLog"></param>
        public void CreateUserLog(UserLog userLog)
        {
            if (userLog != null)
            {
                if (userLog.IpAddress != "::1")
                {
                    GameSchoolEntities.UserLogs.AddObject(userLog);
                    Save();
                }
            }
        }

        /// <summary>
        /// Updates user info
        /// </summary>
        /// <param name="userInfo"></param>
        public void UpdateUser(UserInfo userInfo)
        {
            Save();
        }


        /// <summary>
        /// Gets users statuses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Status> GetUserStatuses()
        {
            var userStatus = from x in GameSchoolEntities.Status
                             select x;

            return userStatus;
        }

        /// <summary>
        /// Gets usertypes
        /// </summary>
        /// <returns>usertypes</returns>
        public IEnumerable<Ru.GameSchool.DataLayer.Repository.UserType> GetUserTypes()
        {
            var userTypes = from x in GameSchoolEntities.UserTypes
                            select x;

            return userTypes;
        }

        /// <summary>
        /// User search 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="userT"></param>
        /// <returns></returns>
        public IEnumerable<UserInfo> Search(string search, Enums.UserType userT)
        {
            if (string.IsNullOrEmpty(search))
            {
                return null;
            }
            var query =
                GameSchoolEntities.UserInfoes.Where(
                    u => u.UserTypeId == (int)userT && (u.Username.Contains(search) || u.Email.Contains(search)
                                                          || u.Fullname.Contains(search)));
            return query;
        }
    }
}
