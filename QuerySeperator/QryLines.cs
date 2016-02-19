using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;

namespace QuerySeperator
{
    public class QryLine
    {

        public int line { get; set; }
        public int parent { get; set; }
        public string Raw { get; set; }
        public DateTime ts { get; set; }

        public string SrcLabel { get; set; }

        public string LogInfo { get; set; }

        public List<Tuple<int, QryLine>> lineGrp { get; set; }

        public QryLine(string raw)

        {
            if (string.IsNullOrEmpty(raw))
                return;
            Raw = raw;
            Match mSourceName = Regex.Match(Raw, @"\[.*\]");
           SrcLabel = mSourceName.Value;
            LogInfo = Raw.Substring(mSourceName.Index + mSourceName.Value.Length + 1,
                Raw.Length - (mSourceName.Index + mSourceName.Value.Length + 1));
            
           
        }


    }

    public class QryLines
    {
        public List< QryLine> qryLines = new List< QryLine>();

        public QryLines(string qryFile)
        {
            int currentLineNumber = 0;
            //2016-02-04T13:57:10.762  
            string pattern = "^[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]T[0-9][0-9]:[0-9][0-9]:[0-9][0-9]";
            Regex lineStartWithStamp = new Regex(pattern, RegexOptions.Compiled);

            using (StreamReader sr = new StreamReader(qryFile))
            {
                string line;
                QryLine ql = null;
                int grpLineNumber = 0;
                while (sr.Peek() >= 0)
                {

                    line = sr.ReadLine();
                    if (line == null)
                        break;


                    // if the begging of the line is timestamp it is a new line
                    if (lineStartWithStamp.IsMatch(line))
                    {
                        ql = new QryLine(line);
                        ql.line = ++currentLineNumber;
                        grpLineNumber = 0;
                        qryLines.Add( ql);
                    }
                    else // the following is a continuation of the previous line
                    {
                        if (ql == null)
                            continue;

                        if (ql.lineGrp == null)
                            ql.lineGrp = new List<Tuple<int, QryLine>>();

                        ql.lineGrp.Add(new Tuple<int, QryLine>(grpLineNumber++, new QryLine(line)));
                    }

                }
            }
        }

        public List<QryLine> ToList()
        {
            return qryLines;

        } 
         
    }
}
