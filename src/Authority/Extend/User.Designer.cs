﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace YhxBank.Common.Organization
{
	partial class UserData
	{


        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns>校验消息,如果正确,返回空</returns>
        public override string Validate()
        {
            var msg =new List< string>();
            if(string.IsNullOrWhiteSpace(UserName))
                msg.Add("[用户名]不能为空");
            if(string.IsNullOrWhiteSpace(PassWord))
                msg.Add("[密码]不能为空");
            if(string.IsNullOrWhiteSpace(RealName))
                msg.Add("[姓名]不能为空");
            ValidateEx(msg);
            var bm = base.Validate();
            if(bm != null)
                msg.Add(bm);
            return msg.Count ==0 ? null : string.Join(",", msg);
        }
        partial void ValidateEx(List<string> msg);
        
    }
}