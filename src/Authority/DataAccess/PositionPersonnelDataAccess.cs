﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Agebull.Common.DataModel.Redis;
using Gboxt.Common.DataModel;
using Gboxt.Common.DataModel.MySql;
using MySql.Data.MySqlClient;

namespace Agebull.SystemAuthority.Organizations.DataAccess
{
    /// <summary>
    /// 员工职位关联
    /// </summary>
    sealed partial class PositionPersonnelDataAccess : HitoryTable<PositionPersonnelData>
    {
        /// <summary>
        /// 读取选择职位数据
        /// </summary>
        /// <param name="pid">职位ID</param>
        /// <param name="kw">查询关键字</param>
        /// <returns></returns>
        public List<PositionPersonnelData> LoadForSelect(int pid, string kw)
        {
            using (MySqlReadTableScope<PositionPersonnelData>.CreateScope(this, "dbo.QueryPositionPersonnel(@pid,@oid,@kw)"))
            {
                var sp1 = new MySqlParameter { ParameterName = "@kw", MySqlDbType = MySqlDbType.VarString, Size = kw.Length * 2 + 10, Value = kw };
                var sp2 = new MySqlParameter { ParameterName = "@pid", MySqlDbType = MySqlDbType.Int32, Value = pid };
                var sp3 = new MySqlParameter { ParameterName = "@oid", MySqlDbType = MySqlDbType.Int32, Value = 0 };//BusinessContext.Current.LoginUser.CompanyId
                var list = LoadData(null, sp1, sp2, sp3);
                list.ForEach(p => p.__IsSelected = p.Id > 0);
                return list;
            }
        }

        /// <summary>
        /// 读取选择职位数据
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public List<PositionPersonnelData> LoadForOrg(int oid)
        {
            using (MySqlReadTableScope<PositionPersonnelData>.CreateScope(this, "V_OrgPosPersonnel"))
            {
                return All(p => p.DataState < DataStateType.Delete && p.OrganizationId == oid);
            }
        }
        /// <summary>
        ///     保存完成后期处理(Insert或Update)
        /// </summary>
        /// <param name="entity"></param>
        protected sealed override void OnDataSaved(DataOperatorType operatorType,PositionPersonnelData entity)
        {
            using (var proxy = new RedisProxy(RedisProxy.DbSystem))
            {
                proxy.SetEntity(entity);
            }
        }

        /// <summary>
        /// 获取公司及公司下级成员
        /// </summary>
        /// <param name="comId">公司ID</param>
        /// <returns>公司及公司下级成员</returns>
        public List<PositionPersonnelData> LoadForCom(int comId)
        {
            using (MySqlReadTableScope<PositionPersonnelData>.CreateScope(this, "V_OrgPosPersonnel"))
            {
                return All(p => p.DataState < DataStateType.Delete && p.OrganizationId == comId);
            }
        }

        /// <summary>
        /// 获取公司成员
        /// </summary>
        /// <param name="comId">公司ID</param>
        /// <returns>公司成员</returns>
        public List<PositionPersonnelData> LoadCom(int comId)
        {
            using (MySqlReadTableScope<PositionPersonnelData>.CreateScope(this, "V_OrgPosPersonnel"))
            {
                return All(p => p.DataState < DataStateType.Delete && p.OrganizationId == comId);
            }
        }

        /// <summary>
        /// 获取组织成员信息
        /// </summary>
        /// <param name="orgId">组织ID</param>
        /// <returns>组织成员信息</returns>
        public List<PositionPersonnelData> LoadOrg(int orgId)
        {
            using (MySqlReadTableScope<PositionPersonnelData>.CreateScope(this, "V_OrgPosPersonnel"))
            {
                return All(p => p.DataState < DataStateType.Delete && p.DepartmentId == orgId);
            }
        }
    }
}
