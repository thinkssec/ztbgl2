using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.EntDisk
{
    /// <summary>
    /// 文件实体模型
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// 文件或文件夹名称
        /// </summary>
        public string fileName { get; set; }

        /// <summary>
        /// 文件或文件夹大小
        /// </summary>
        public string fileLength { get; set; }

        /// <summary>
        /// 文件或文件夹创建时间
        /// </summary>
        public DateTime fileCreateTime { get; set; }

        /// <summary>
        /// 文件或文件夹最后修改时间
        /// </summary>
        public DateTime fileModifyTime { get; set; }

        /// <summary>
        /// 文件类型 0为文件夹 1为文件
        /// </summary>
        public byte fileType { get; set; }
    }
}
