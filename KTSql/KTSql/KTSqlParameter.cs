using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KTSql
{
    public class KTWhereParameter
    {
        public string ColumnName { get; set; }
        public string ParameterName { get; set; }
        public DbType DbType { get; set; }
        public string Value { get; set; }
        public string OperatorSymbol { get; set; }
    }
    public class QueryWithParametersModel
    {
        public string Query { get; set; }
        public List<SqlParameter> Parameters { get; set; }
    }
}
