using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuerySeperator
{
    class Program
    {
        static void Main(string[] args)
        {
           // var qryGroup = new QueryGroup(@"D:\snapshot\logs\20160204.log");
           // qryGroup.Group();
           QryLines qryLines2 = new QryLines(@"D:\snapshot\logs\20160204170626829.log.qry");
           QryLines qryLines1 = new QryLines(@"D:\snapshot\logs\20160204170704863.log.qry");
        }
    }
}
