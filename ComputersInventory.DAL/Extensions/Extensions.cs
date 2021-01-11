using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComputersInventory.DAL.Extensions
{
    public static class Extensions
    {
        public static IQueryable<object> QueryGenerator(this IQueryable<object> dataSet, string orderBy = null,
           string orderDirection = null, int pageNumber = -1,
           int sizeOfPage = -1, string filterParams = null)
        {
            dataSet = dataSet.sortData(orderBy, orderDirection);
            dataSet = dataSet.filterData(filterParams);
            //dataSet = dataSet.Take(10000);
            return dataSet;
        }

        private static IQueryable<object> sortData(this IQueryable<object> dataSet, string orderBy,
            string orderDirection)
        {
            //Apply Order of Direction
            if (orderBy != null && orderDirection != null)
            {
                var orderString = orderBy + " ";
                orderString += orderDirection.ToLower() == "desc" ? "desc" : "asc";
                dataSet = dataSet.OrderBy(orderString);
            }

            return dataSet;
        }

        private static IQueryable<object> filterData(this IQueryable<object> dataSet, string filterParams)
        {
            if (filterParams != null)
                if (filterParams.Length != 2)
                {
                    var paramNumber = 0;
                    var paramList = new List<object>();
                    var query = "";

                    foreach (JObject filterParam in JsonConvert.DeserializeObject<object[]>(filterParams))
                    {
                        var filterValue = filterParam["filterValue"] == null
                            ? null
                            : filterParam["filterValue"].ToString();
                        var columnName = filterParam["columnDef"] == null ? null : filterParam["columnDef"].ToString();
                        var columnType = filterParam["fieldDisplayType"] == null
                            ? null
                            : filterParam["fieldDisplayType"].ToString();

                        query += paramNumber != 0 ? " && " : "";

                        switch (columnType)
                        {
                            case "dateTime":

                                if (filterParam["startDate"] != null || filterParam["endDate"] != null)
                                {
                                    var startDate = DateTime.Parse(filterParam["startDate"].ToString());
                                    var endDate = DateTime.Parse(filterParam["endDate"].ToString()).AddDays(1);
                                    paramList.Add(startDate);
                                    paramList.Add(endDate);

                                    query += columnName + " >= @" + paramNumber + " && " + columnName + " <= @" +
                                             ++paramNumber;
                                }

                                break;

                            case "number":
                                var minValue = filterParam.GetValue("minValue").ToString();
                                var maxValue = filterParam.GetValue("maxValue").ToString();
                                if (minValue != "" && maxValue != "")
                                    query += columnName + " >= " + minValue + " && " + columnName + " <= " + maxValue;

                                break;

                            case "boolean":

                                query += string.Format(@"{0} = {1}", columnName, filterValue);
                                break;

                            case "featureType":

                                if (filterValue != "")
                                    query += string.Format(@"{0} = ""{1}""", columnName, filterValue);

                                break;

                            case "publishedStatus":
                                if (filterValue != "")
                                    query += string.Format(@"{0} = ""{1}""", columnName, filterValue);
                                break;

                            case "reportType":
                                if (filterValue != "")
                                    query += string.Format(@"{0} = ""{1}""", columnName, filterValue);
                                break;

                            default:
                                query += columnName + ".Contains(@" + paramNumber + ")";
                                break;
                        }

                        paramList.Add(filterValue);
                        paramNumber++;
                    }

                    if (query.Length != 0 && paramList.ToArray().Length != 0)
                        dataSet = dataSet.Where(query, paramList.ToArray());
                }

            return dataSet;
        }
    }
}
