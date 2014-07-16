using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Spacecat.Framework.CSVParser
{
    /// <summary>
    /// Controller class of CSV Parser.
    /// </summary>
    [Obsolete()]
    static public class CSVParserController
    {
        /// <summary>
        /// Load CSV file in a dictionary.
        /// </summary>
        static public String[,] GetValuesFromFile(String path)
        {
            try
            {
                String[] rows;
                {
					rows = File.ReadAllLines(path);
                }
                
                String[] fields;
                {
                    fields = _ParseCSVLine(rows[0]);
                }
                    
                String[,] result = new String[rows.Length, fields.Length];
                
                for (Int32 rowIndex = 0; rowIndex < rows.Length; rowIndex++)
                {
                    if (rowIndex == 0)
                    {
                        for (Int32 fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
                        {
                            result[0, fieldIndex] = fields[fieldIndex];
                        }
                    }
                    else
                    {
                        String[] values;
                        {
                            values = _ParseCSVLine(rows[rowIndex]);
                        
                            if (fields.Length == values.Length)
                            {
                                for (Int32 fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
                                {
                                    result[rowIndex, fieldIndex] = values[fieldIndex];
                                }
                            }
                        }
                    }
                }
                
                return result;
            }
            catch
            {
                return null;
            }
        }
        
        /// <summary>
        /// Parse from specified line in CSV format to an array of strings and return it.
        /// </summary>
        static private String[] _ParseCSVLine(String csvLine)
        {
            Char[] trimChars;
            {
                trimChars = new Char[] {' ', '\"'};
            }
            
            List<String> valueList;
            {
                valueList = new List<String>();
                
                foreach (Match match in Regex.Matches(csvLine, "((\\s*)\"([^,]+)\"\\s*)|([^\",]+)"))
                {
                    valueList.Add(match.Value.Trim(trimChars));
                }
            }
            
            return valueList.ToArray();
        }
    }
}
