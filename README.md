# KTSql

Creates TSQL queries and returns dataTable result

##Usage

### Import

Add project into your solution and then add to your references. After adding references add

> using KTSql;

to your class references, which you want to use.


### ExecuteGetQuery

Import parameters connection string, query and where parameters.

> var dataTable = KTSql.ExecuteGetQuery([CONNECTION STRING], "SELECT * FROM table WHERE column1=@PARAM1 order by column2 desc", new List<SqlParameter>
>            {
>                new SqlParameter { DbType = DbType.String, ParameterName = "PARAM1", Value = "[DATA]" }
>            });


### GenerateWhere

Import where parameters only and returns sql query.

> List<KTWhereParameter> parameters = new List<KTWhereParameter>();
> var sqlQuery = "SELECT * FROM table ";
>
>	parameters.Add(new KTWhereParameter
>	{
>		ColumnName = "column1",
>		DbType = DbType.String,
>		ParameterName = "PARAM1",
>		Value = "[DATA]",
>		OperatorSymbol = "="
>		});
>
>   var whereQuery = QueryHelper.GenerateWhere(parameters);
>
>   var sqlParameters = new List<SqlParameter>();
>   if (whereQuery != null)
>    {
>       sqlQuery = string.Format("{0} {1}", sqlQuery, whereQuery.Query);
>       sqlParameters.AddRange(whereQuery.Parameters);
>   }

OperatorSymbol can be "=", ">=", "<=", "<>"