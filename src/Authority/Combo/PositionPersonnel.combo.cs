﻿/*此标记表明此文件可被设计器更新,如果不允许此操作,请删除此行代码.design by:agebull designer date:2017/6/27 9:11:34*/
using System.Collections.Generic;
using System.Linq;
using Agebull.Common.DataModel.Redis;
using Agebull.ProjectDeveloper.WebDomain.Models;
using Gboxt.Common.DataModel;
using Gboxt.Common.DataModel.MySql;
using Gboxt.Common.WebUI;

namespace Agebull.SystemAuthority.Organizations.DataAccess
{
    partial class PositionPersonnelDataAccess
    {
        /// <summary>
        /// 下拉列表键
        /// </summary>
        private const string comboKey = "ui:combo:PositionPersonnel";
        /// <summary>
        /// 下拉树键
        /// </summary>
        private const string treeKey = "ui:tree:PositionPersonnel";

        /// <summary>
        /// 取得下拉列表值
        /// </summary>
        /// <returns></returns>
        public static List<EasyComboValues> GetComboValues()
        {
            using (var proxy = new RedisProxy(RedisProxy.DbComboCache))
            {
                var result = proxy.Client.Get<List<EasyComboValues>>(comboKey);
                if (result == null)
                {
                    var access = new PositionPersonnelDataAccess();
                    var datas = access.All(p => p.DataState == DataStateType.Enable);
                    result = new List<EasyComboValues>{EasyComboValues.Empty};
                    result.AddRange(datas.Select(p => new EasyComboValues(p.Id, p.Personnel)));
                    proxy.Client.Set(comboKey, result);
                }
                return result;
            }
        }

        /// <summary>
        /// 取得下拉树值
        /// </summary>
        /// <returns></returns>
        public static List<EasyUiTreeNode> GetTreeValues()
        {
            using (var proxy = new RedisProxy(RedisProxy.DbComboCache))
            {
                var result = proxy.Client.Get<List<EasyUiTreeNode>>(treeKey);
                if (result == null)
                {
                    var access = new PositionPersonnelDataAccess();
                    var datas = access.All(p => p.DataState == DataStateType.Enable);
                    result = new List<EasyUiTreeNode>{EasyUiTreeNode.EmptyNode};
                    result.AddRange(datas.Select(p => new EasyUiTreeNode
                    {
                        ID = p.Id,
                        Text = p.Personnel,
                        Title = p.Personnel,
                        IsOpen = true
                    }));
                    proxy.Client.Set(treeKey, result);
                }
                return result;
            }
        }

        /// <summary>
        ///     保存完成后期处理(Insert或Update)
        /// </summary>
        /// <param name="entity"></param>
        protected sealed override void OnDataSaved(PositionPersonnelData entity)
        {
            using (var proxy = new RedisProxy(RedisProxy.DbComboCache))
            {
                proxy.RemoveKey(treeKey);
                proxy.RemoveKey(comboKey);
            }
        }
    }
}