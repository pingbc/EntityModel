﻿// // /*****************************************************
// // (c)2016-2016 Copy right www.gboxt.com
// // 作者:
// // 工程:Agebull.DataModel
// // 建立:2016-06-07
// // 修改:2016-06-16
// // *****************************************************/

#region 引用

using System;

#endregion

namespace Gboxt.Common.DataModel
{
    /// <summary>
    ///     表示属性结构
    /// </summary>
    public sealed class PropertySturct
    {
        /// <summary>
        ///     标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        ///     属性名称
        /// </summary>
        public string Name
        {
            get { return PropertyName; }
            set { PropertyName = value; }
        }

        /// <summary>
        ///     字段名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        ///     属性类型
        /// </summary>
        public Type PropertyType { get; set; }

        /// <summary>
        ///     索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///     能否为空
        /// </summary>
        public bool CanNull { get; set; }

        /// <summary>
        ///     属性类型
        /// </summary>
        public PropertyValueType ValueType { get; set; }

        /// <summary>
        ///     能否导入
        /// </summary>
        public bool CanImport { get; set; }

        /// <summary>
        ///     能否导出
        /// </summary>
        public bool CanExport { get; set; }
    }
}