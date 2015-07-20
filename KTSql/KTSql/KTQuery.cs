using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace KTSql
{
    class KTQuery
    {
        public static QueryWithParametersModel GenerateWhere(List<KTWhereParameter> parameters)
        {
            var queryParameters = new List<SqlParameter>();
            var strQuery = new StringBuilder();

            for (var i = 0; i < parameters.Count; i++)
            {
                if (i == 0)
                {
                    strQuery.Append("Where ");
                }
                strQuery.Append(string.Format("{0}{1}@{2} ", parameters[i].ColumnName, parameters[i].OperatorSymbol, parameters[i].ParameterName));

                queryParameters.Add(new SqlParameter
                {
                    DbType = parameters[i].DbType,
                    ParameterName = parameters[i].ParameterName,
                    Value = parameters[i].Value
                });

                if (i < parameters.Count - 1)
                {
                    strQuery.Append("AND ");
                }
            }

            return new QueryWithParametersModel
            {
                Parameters = queryParameters,
                Query = strQuery.ToString()
            };
        } 
    }
}
