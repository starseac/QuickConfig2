﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Collections;
using System.DirectoryServices;

namespace QuickConfig.Common
{
  public  class setOSUser
    {
         private static readonly string PATH = "WinNT://" + Environment.MachineName;

         public static void addUser(string username,string password) {
             AddUser(username, password, "Users", "");
         }

        ///
        /// 添加windows用户
        ///
        /// 用户名
        /// 密码
        /// 所属组
        /// 描述
        public static void AddUser(string username, string password, string group, string description)
        {
            using (DirectoryEntry dir = new DirectoryEntry(PATH))
            {
                using (DirectoryEntry user = dir.Children.Add(username, "User")) //增加用户名
                {
                    user.Properties["FullName"].Add(username); //用户全称
                    user.Invoke("SetPassword", password); //用户密码
                    user.Invoke("Put", "Description", description);//用户详细描述
                    //user.Invoke("Put","PasswordExpired",1); //用户下次登录需更改密码
                    user.Invoke("Put", "UserFlags", 66049); //密码永不过期
                    //user.Invoke("Put", "UserFlags", 0x0040);//用户不能更改密码s
                    user.CommitChanges();//保存用户
                    using (DirectoryEntry grp = dir.Children.Find(group, "group"))
                    {
                        if (grp.Name != "")
                        {
                            grp.Invoke("Add", user.Path.ToString());//将用户添加到某组
                        }
                    }
                }
            }
        }
        ///
        /// 更改windows用户密码
        ///
        /// 用户名
        /// 新密码
        public static void UpdateUserPassword(string username, string newpassword)
        {
            using (DirectoryEntry dir = new DirectoryEntry(PATH))
            {
                using (DirectoryEntry user = dir.Children.Find(username, "user"))
                {
                    user.Invoke("SetPassword", new object[] { newpassword });
                    user.CommitChanges();
                }
            }
        }
        public static bool isUserExist(string username)
        {
            using (DirectoryEntry dir = new DirectoryEntry(PATH))
            {
                try
                {
                    DirectoryEntry user = dir.Children.Find(username, "User");
                }catch(Exception eg){
                    return false;
                }
                return true;
               
            }
        }

        ///
        /// 删除windows用户
        ///
        /// 用户名
        public static void RemoveUser(string username)
        {
            using (DirectoryEntry dir = new DirectoryEntry(PATH))
            {
                using (DirectoryEntry user = dir.Children.Find(username, "User"))
                {
                    dir.Children.Remove(user);
                }
            }
        }
        ///
        /// 添加windows用户组
        ///
        /// 组名称
        /// 描述
        public static void AddGroup(string groupName, string description)
        {
            using (DirectoryEntry dir = new DirectoryEntry(PATH))
            {
                using (DirectoryEntry group = dir.Children.Add(groupName, "group"))
                {
                    group.Invoke("Put", new object[] { "Description", description });
                    group.CommitChanges();
                }
            }
        }
        ///
        /// 删除windows用户组
        ///
        /// 组名称
        public static void RemoveGroup(string groupName)
        {
            using (DirectoryEntry dir = new DirectoryEntry(PATH))
            {
                using (DirectoryEntry group = dir.Children.Find(groupName, "Group"))
                {
                    dir.Children.Remove(group);
                }
            }
        }
    }
}

