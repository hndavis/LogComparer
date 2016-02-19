using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;

namespace QuerySeperator
{
    public class QueryGroup
    {
        private string LogFileName;

        public QueryGroup(String logfile)
        {
            LogFileName = logfile;
        }

        public IEnumerable Group()
        {
            List<String> QryFileNames= new List<string>();
            using (StreamReader sr = new StreamReader(LogFileName))
            {
                String fileName = Path.GetFileNameWithoutExtension(LogFileName);
                string outputPath = Path.GetDirectoryName(LogFileName);
                
                while (sr.Peek() >= 0)
                {
                    String tod = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond.ToString();
                    string qryFileName = outputPath + "\\" + fileName + tod + ".log.qry";
                    using (StreamWriter sw = new StreamWriter(qryFileName))
                    {
                        string line = "";
                        while (!line.Contains("[SnSProcessor] -- END --"))
                        {
                            line = sr.ReadLine();
                            sw.WriteLine(line);
                            if (line == null)
                                break;
                        }
                        QryFileNames.Add(qryFileName);
                        Debug.WriteLine("Finished one query");


                    }
                }
                return QryFileNames;
            }


        }
         
    }
}