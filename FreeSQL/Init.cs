
using System.Linq.Expressions;

namespace FreeSQLHelper
{
    public class Init
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private const string CONNECTIONSTRING = "Host=localhost;Port=8066;Database=postgres;Username=postgres;Password=root;";
        private readonly IFreeSql freeSql_;
        public Init() {
            freeSql_ = new FreeSql.FreeSqlBuilder()
                  .UseConnectionString(FreeSql.DataType.PostgreSQL, CONNECTIONSTRING)
                  .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                  .Build(); //请务必定义成 Singleton 单例模式
        }
        public IFreeSql GetInstance()
        {
            if (freeSql_ == null)
            {
                _ = new Init();
            }
            return freeSql_;
        }
    }
}