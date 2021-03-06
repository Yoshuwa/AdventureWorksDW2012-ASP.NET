using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimCustomer_dbo_DimGeographyDataClass
{
    public static List<dbo_DimCustomer_dbo_DimGeographyClass> List()
    {
        List<dbo_DimCustomer_dbo_DimGeographyClass> dbo_DimCustomer_dbo_DimGeographyList = new List<dbo_DimCustomer_dbo_DimGeographyClass>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [GeographyKey] " 
            + "    ,[StateProvinceName] " 
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimCustomer_dbo_DimGeographyClass clsdbo_DimCustomer_dbo_DimGeography = new dbo_DimCustomer_dbo_DimGeographyClass();
            while (reader.Read())
            {
                clsdbo_DimCustomer_dbo_DimGeography = new dbo_DimCustomer_dbo_DimGeographyClass();
                clsdbo_DimCustomer_dbo_DimGeography.GeographyKey = System.Convert.ToInt32(reader["GeographyKey"]);
                clsdbo_DimCustomer_dbo_DimGeography.StateProvinceName = Convert.ToString(reader["StateProvinceName"]);
                dbo_DimCustomer_dbo_DimGeographyList.Add(clsdbo_DimCustomer_dbo_DimGeography);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimCustomer_dbo_DimGeographyList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimCustomer_dbo_DimGeographyList;
    }

}


 
