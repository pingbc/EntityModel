﻿/*此标记表明此文件可被设计器更新,如果不允许此操作,请删除此行代码.design by:agebull designer date:2017/9/16 22:23:56*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Text;
using Gboxt.Common.DataModel;

using MySql.Data.MySqlClient;
using Gboxt.Common.DataModel.MySql;


namespace Agebull.SystemAuthority.Organizations.DataAccess
{
    /// <summary>
    /// 机构职位设置
    /// </summary>
    public partial class OrganizePositionDataAccess
    {

        #region 基本SQL语句

        /// <summary>
        /// 表的唯一标识
        /// </summary>
        public override int TableId
        {
            get { return Authorities.Table_OrganizePosition; }
        }

        /// <summary>
        /// 读取表名
        /// </summary>
        protected sealed override string ReadTableName
        {
            get
            {
                return @"view_sys_organize_position";
            }
        }

        /// <summary>
        /// 写入表名
        /// </summary>
        protected sealed override string WriteTableName
        {
            get
            {
                return @"tb_sys_organize_position";
            }
        }

        /// <summary>
        /// 主键
        /// </summary>
        protected sealed override string PrimaryKey
        {
            get
            {
                return @"Id";
            }
        }

        /// <summary>
        /// 全表读取的SQL语句
        /// </summary>
        protected sealed override string FullLoadFields
        {
            get
            {
                return @"
    `id` AS `Id`,
    `appellation` AS `Position`,
    `role_id` AS `RoleId`,
    `role` AS `Role`,
    `organization_id` AS `OrganizationId`,
    `organization` AS `Department`,
    `org_level` AS `OrgLevel`,
    `memo` AS `Memo`,
    `data_state` AS `DataState`,
    `is_freeze` AS `IsFreeze`,
    `author_id` AS `AuthorID`,
    `add_date` AS `AddDate`,
    `last_reviser_id` AS `LastReviserID`,
    `last_modify_date` AS `LastModifyDate`,
    `audit_state` AS `AuditState`,
    `auditor_id` AS `AuditorId`,
    `audit_date` AS `AuditDate`";
            }
        }

        

        /// <summary>
        /// 插入的SQL语句
        /// </summary>
        protected sealed override string InsertSqlCode
        {
            get
            {
                return @"
INSERT INTO `tb_sys_organize_position`
(
    `appellation`,
    `role_id`,
    `organization_id`,
    `memo`,
    `data_state`,
    `is_freeze`,
    `author_id`,
    `add_date`,
    `last_reviser_id`,
    `last_modify_date`,
    `audit_state`,
    `auditor_id`,
    `audit_date`
)
VALUES
(
    ?Position,
    ?RoleId,
    ?OrganizationId,
    ?Memo,
    ?DataState,
    ?IsFreeze,
    ?AuthorID,
    ?AddDate,
    ?LastReviserID,
    ?LastModifyDate,
    ?AuditState,
    ?AuditorId,
    ?AuditDate
);
SELECT @@IDENTITY;";
            }
        }

        /// <summary>
        /// 全部更新的SQL语句
        /// </summary>
        protected sealed override string UpdateSqlCode
        {
            get
            {
                return @"
UPDATE `tb_sys_organize_position` SET
       `appellation` = ?Position,
       `role_id` = ?RoleId,
       `organization_id` = ?OrganizationId,
       `memo` = ?Memo,
       `data_state` = ?DataState,
       `is_freeze` = ?IsFreeze,
       `audit_state` = ?AuditState,
       `auditor_id` = ?AuditorId,
       `audit_date` = ?AuditDate
 WHERE `id` = ?Id;";
            }
        }

        /// <summary>
        /// 取得仅更新的SQL语句
        /// </summary>
        internal string GetModifiedSqlCode(OrganizePositionData data)
        {
            if (data.__EntityStatusNull || !data.__EntityStatus.IsModified)
                return ";";
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE `tb_sys_organize_position` SET");
            //职位
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_Position] > 0)
                sql.AppendLine("       `appellation` = ?Position");
            //角色标识
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_RoleId] > 0)
                sql.AppendLine("       `role_id` = ?RoleId");
            //部门标识
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_OrganizationId] > 0)
                sql.AppendLine("       `organization_id` = ?OrganizationId");
            //备注
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_Memo] > 0)
                sql.AppendLine("       `memo` = ?Memo");
            //数据状态
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_DataState] > 0)
                sql.AppendLine("       `data_state` = ?DataState");
            //数据是否已冻结
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_IsFreeze] > 0)
                sql.AppendLine("       `is_freeze` = ?IsFreeze");
            //制作人
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_AuthorID] > 0)
                sql.AppendLine("       `author_id` = ?AuthorID");
            //制作时间
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_AddDate] > 0)
                sql.AppendLine("       `add_date` = ?AddDate");
            //最后修改者
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_LastReviserID] > 0)
                sql.AppendLine("       `last_reviser_id` = ?LastReviserID");
            //最后修改日期
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_LastModifyDate] > 0)
                sql.AppendLine("       `last_modify_date` = ?LastModifyDate");
            //审核状态
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_AuditState] > 0)
                sql.AppendLine("       `audit_state` = ?AuditState");
            //审核人
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_AuditorId] > 0)
                sql.AppendLine("       `auditor_id` = ?AuditorId");
            //审核时间
            if (data.__EntityStatus.ModifiedProperties[OrganizePositionData.Real_AuditDate] > 0)
                sql.AppendLine("       `audit_date` = ?AuditDate");
            sql.Append(" WHERE `id` = ?Id;");
            return sql.ToString();
        }

        #endregion


        #region 字段

        /// <summary>
        ///  所有字段
        /// </summary>
        static string[] _fields = new string[]{ "Id","Position","RoleId","Role","OrganizationId","Department","OrgLevel","Memo","DataState","IsFreeze","AuthorID","AddDate","LastReviserID","LastModifyDate","AuditState","AuditorId","AuditDate" };

        /// <summary>
        ///  所有字段
        /// </summary>
        public sealed override string[] Fields
        {
            get
            {
                return _fields;
            }
        }

        /// <summary>
        ///  字段字典
        /// </summary>
        public static Dictionary<string, string> fieldMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Id" , "id" },
            { "Position" , "appellation" },
            { "appellation" , "appellation" },
            { "RoleId" , "role_id" },
            { "role_id" , "role_id" },
            { "Role" , "role" },
            { "OrganizationId" , "organization_id" },
            { "organization_id" , "organization_id" },
            { "Department" , "organization" },
            { "organization" , "organization" },
            { "OrgLevel" , "org_level" },
            { "org_level" , "org_level" },
            { "Memo" , "memo" },
            { "DataState" , "data_state" },
            { "data_state" , "data_state" },
            { "IsFreeze" , "is_freeze" },
            { "is_freeze" , "is_freeze" },
            { "AuthorID" , "author_id" },
            { "author_id" , "author_id" },
            { "AddDate" , "add_date" },
            { "add_date" , "add_date" },
            { "LastReviserID" , "last_reviser_id" },
            { "last_reviser_id" , "last_reviser_id" },
            { "LastModifyDate" , "last_modify_date" },
            { "last_modify_date" , "last_modify_date" },
            { "AuditState" , "audit_state" },
            { "audit_state" , "audit_state" },
            { "AuditorId" , "auditor_id" },
            { "auditor_id" , "auditor_id" },
            { "AuditDate" , "audit_date" },
            { "audit_date" , "audit_date" }
        };

        /// <summary>
        ///  字段字典
        /// </summary>
        public sealed override Dictionary<string, string> FieldMap
        {
            get { return fieldMap ; }
        }
        #endregion
        #region 方法实现


        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="reader">数据读取器</param>
        /// <param name="entity">读取数据的实体</param>
        protected sealed override void LoadEntity(MySqlDataReader reader,OrganizePositionData entity)
        {
            using (new EditScope(entity.__EntityStatus, EditArrestMode.All, false))
            {
                entity._id = (int)reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    entity._position = reader.GetString(1).ToString();
                entity._roleid = (int)reader.GetInt32(2);
                if (!reader.IsDBNull(3))
                    entity._role = reader.GetString(3).ToString();
                entity._organizationid = (int)reader.GetInt32(4);
                if (!reader.IsDBNull(5))
                    entity._department = reader.GetString(5).ToString();
                if (!reader.IsDBNull(6))
                    entity._orglevel = (int)reader.GetInt32(6);
                if (!reader.IsDBNull(7))
                    entity._memo = reader.GetString(7).ToString();
                if (!reader.IsDBNull(8))
                    entity._datastate = (DataStateType)reader.GetInt32(8);
                entity._isfreeze = (bool)reader.GetBoolean(9);
                entity._authorid = (int)reader.GetInt32(10);
                if (!reader.IsDBNull(11))
                    try{entity._adddate = reader.GetMySqlDateTime(11).Value;}catch{}
                entity._lastreviserid = (int)reader.GetInt32(12);
                if (!reader.IsDBNull(13))
                    try{entity._lastmodifydate = reader.GetMySqlDateTime(13).Value;}catch{}
                if (!reader.IsDBNull(14))
                    entity._auditstate = (AuditStateType)reader.GetInt32(14);
                entity._auditorid = (int)reader.GetInt32(15);
                if (!reader.IsDBNull(16))
                    try{entity._auditdate = reader.GetMySqlDateTime(16).Value;}catch{}
            }
        }

        /// <summary>
        /// 得到字段的DbType类型
        /// </summary>
        /// <param name="field">字段名称</param>
        /// <returns>参数</returns>
        protected sealed override MySqlDbType GetDbType(string field)
        {
            switch (field)
            {
                case "Id":
                    return MySqlDbType.Int32;
                case "Position":
                    return MySqlDbType.VarString;
                case "RoleId":
                    return MySqlDbType.Int32;
                case "Role":
                    return MySqlDbType.VarString;
                case "OrganizationId":
                    return MySqlDbType.Int32;
                case "Department":
                    return MySqlDbType.VarString;
                case "OrgLevel":
                    return MySqlDbType.Int32;
                case "Memo":
                    return MySqlDbType.Text;
                case "DataState":
                    return MySqlDbType.Int32;
                case "IsFreeze":
                    return MySqlDbType.Byte;
                case "AuthorID":
                    return MySqlDbType.Int32;
                case "AddDate":
                    return MySqlDbType.DateTime;
                case "LastReviserID":
                    return MySqlDbType.Int32;
                case "LastModifyDate":
                    return MySqlDbType.DateTime;
                case "AuditState":
                    return MySqlDbType.Int32;
                case "AuditorId":
                    return MySqlDbType.Int32;
                case "AuditDate":
                    return MySqlDbType.DateTime;
            }
            return MySqlDbType.VarChar;
        }


        /// <summary>
        /// 设置插入数据的命令
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="cmd">命令</param>
        /// <returns>返回真说明要取主键</returns>
        private void CreateFullSqlParameter(OrganizePositionData entity, MySqlCommand cmd)
        {
            //02:标识(Id)
            cmd.Parameters.Add(new MySqlParameter("Id",MySqlDbType.Int32){ Value = entity.Id});
            //03:职位(Position)
            var isNull = string.IsNullOrWhiteSpace(entity.Position);
            var parameter = new MySqlParameter("Position",MySqlDbType.VarString , isNull ? 10 : (entity.Position).Length);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.Position;
            cmd.Parameters.Add(parameter);
            //04:角色标识(RoleId)
            cmd.Parameters.Add(new MySqlParameter("RoleId",MySqlDbType.Int32){ Value = entity.RoleId});
            //05:角色(Role)
            isNull = string.IsNullOrWhiteSpace(entity.Role);
            parameter = new MySqlParameter("Role",MySqlDbType.VarString , isNull ? 10 : (entity.Role).Length);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.Role;
            cmd.Parameters.Add(parameter);
            //06:部门标识(OrganizationId)
            cmd.Parameters.Add(new MySqlParameter("OrganizationId",MySqlDbType.Int32){ Value = entity.OrganizationId});
            //07:部门(Department)
            isNull = string.IsNullOrWhiteSpace(entity.Department);
            parameter = new MySqlParameter("Department",MySqlDbType.VarString , isNull ? 10 : (entity.Department).Length);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.Department;
            cmd.Parameters.Add(parameter);
            //08:级别(OrgLevel)
            cmd.Parameters.Add(new MySqlParameter("OrgLevel",MySqlDbType.Int32){ Value = entity.OrgLevel});
            //09:备注(Memo)
            isNull = string.IsNullOrWhiteSpace(entity.Memo);
            parameter = new MySqlParameter("Memo",MySqlDbType.Text , isNull ? 10 : (entity.Memo).Length);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.Memo;
            cmd.Parameters.Add(parameter);
            //10:数据状态(DataState)
            cmd.Parameters.Add(new MySqlParameter("DataState",MySqlDbType.Int32){ Value = (int)entity.DataState});
            //11:数据是否已冻结(IsFreeze)
            cmd.Parameters.Add(new MySqlParameter("IsFreeze",MySqlDbType.Byte) { Value = entity.IsFreeze ? (byte)1 : (byte)0 });
            //12:制作人(AuthorID)
            cmd.Parameters.Add(new MySqlParameter("AuthorID",MySqlDbType.Int32){ Value = entity.AuthorID});
            //13:制作时间(AddDate)
            isNull = entity.AddDate.Year < 1900;
            parameter = new MySqlParameter("AddDate",MySqlDbType.DateTime);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.AddDate;
            cmd.Parameters.Add(parameter);
            //14:最后修改者(LastReviserID)
            cmd.Parameters.Add(new MySqlParameter("LastReviserID",MySqlDbType.Int32){ Value = entity.LastReviserID});
            //15:最后修改日期(LastModifyDate)
            isNull = entity.LastModifyDate.Year < 1900;
            parameter = new MySqlParameter("LastModifyDate",MySqlDbType.DateTime);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.LastModifyDate;
            cmd.Parameters.Add(parameter);
            //16:审核状态(AuditState)
            cmd.Parameters.Add(new MySqlParameter("AuditState",MySqlDbType.Int32){ Value = (int)entity.AuditState});
            //17:审核人(AuditorId)
            cmd.Parameters.Add(new MySqlParameter("AuditorId",MySqlDbType.Int32){ Value = entity.AuditorId});
            //18:审核时间(AuditDate)
            isNull = entity.AuditDate.Year < 1900;
            parameter = new MySqlParameter("AuditDate",MySqlDbType.DateTime);
            if(isNull)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = entity.AuditDate;
            cmd.Parameters.Add(parameter);
        }


        /// <summary>
        /// 设置更新数据的命令
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="cmd">命令</param>
        protected sealed override void SetUpdateCommand(OrganizePositionData entity, MySqlCommand cmd)
        {
            cmd.CommandText = UpdateSqlCode;
            CreateFullSqlParameter(entity,cmd);
        }


        /// <summary>
        /// 设置插入数据的命令
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="cmd">命令</param>
        /// <returns>返回真说明要取主键</returns>
        protected sealed override bool SetInsertCommand(OrganizePositionData entity, MySqlCommand cmd)
        {
            cmd.CommandText = InsertSqlCode;
            CreateFullSqlParameter(entity, cmd);
            return true;
        }


        /// <summary>
        /// 构造一个缺省可用的数据库对象
        /// </summary>
        /// <returns></returns>
        protected override MySqlDataBase CreateDefaultDataBase()
        {
            return Authorities.Default ?? new Authorities();
        }
        
        /// <summary>
        /// 生成数据库访问范围
        /// </summary>
        internal static MySqlDataTableScope<OrganizePositionData> CreateScope()
        {
            var db = Authorities.Default ?? new Authorities();
            return MySqlDataTableScope<OrganizePositionData>.CreateScope(db, db.OrganizePositions);
        }
        #endregion

        #region 简单读取

        /// <summary>
        /// SQL语句
        /// </summary>
        public override string SimpleFields
        {
            get
            {
                return @"
    `id` AS `Id`,
    `appellation` AS `Position`,
    `role` AS `Role`,
    `organization` AS `Department`,
    `memo` AS `Memo`,
    `data_state` AS `DataState`,
    `is_freeze` AS `IsFreeze`,
    `audit_state` AS `AuditState`";
            }
        }


        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="reader">数据读取器</param>
        /// <param name="entity">读取数据的实体</param>
        public override void SimpleLoad(MySqlDataReader reader,OrganizePositionData entity)
        {
            using (new EditScope(entity.__EntityStatus, EditArrestMode.All, false))
            {
                entity._id = (int)reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    entity._position = reader.GetString(1).ToString();
                if (!reader.IsDBNull(2))
                    entity._role = reader.GetString(2).ToString();
                if (!reader.IsDBNull(3))
                    entity._department = reader.GetString(3).ToString();
                if (!reader.IsDBNull(4))
                    entity._memo = reader.GetString(4).ToString();
                if (!reader.IsDBNull(5))
                    entity._datastate = (DataStateType)reader.GetInt32(5);
                entity._isfreeze = (bool)reader.GetBoolean(6);
                if (!reader.IsDBNull(7))
                    entity._auditstate = (AuditStateType)reader.GetInt32(7);
            }
        }
        #endregion

    }

    partial class Authorities
    {


        /// <summary>
        /// 机构职位设置(view_sys_organize_position):机构职位设置
        /// </summary>
        public const int Table_OrganizePosition = 0x50004;


        /// <summary>
        /// 机构职位设置的结构语句
        /// </summary>
        private TableSql _view_sys_organize_positionSql = new TableSql
        {
            TableName = "view_sys_organize_position",
            PimaryKey = "Id"
        };


        /// <summary>
        /// 机构职位设置数据访问对象
        /// </summary>
        private OrganizePositionDataAccess _organizePositions;

        /// <summary>
        /// 机构职位设置数据访问对象
        /// </summary>
        public OrganizePositionDataAccess OrganizePositions
        {
            get
            {
                return this._organizePositions ?? ( this._organizePositions = new OrganizePositionDataAccess{ DataBase = this});
            }
        }
    }
}