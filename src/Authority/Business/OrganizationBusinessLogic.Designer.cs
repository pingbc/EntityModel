﻿/*此标记表明此文件可被设计器更新,如果不允许此操作,请删除此行代码.design by:agebull designer date:2017/6/10 2:16:50*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

using Gboxt.Common.DataModel;
using Gboxt.Common.DataModel.BusinessLogic;
using Gboxt.Common.DataModel.MySql;
using Agebull.SystemAuthority.Organizations.DataAccess;

namespace Agebull.SystemAuthority.Organizations.BusinessLogic
{
    /// <summary>
    /// 机构
    /// </summary>
    partial class OrganizationBusinessLogic
    {
        
        /// <summary>
        ///     实体类型
        /// </summary>
        public override int EntityType => Authorities.Table_Organization;



    }
}