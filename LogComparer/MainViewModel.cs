using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuerySeperator;
using RTStringExtentions;


namespace LogComparer
{
    public class MainViewModel
    {
        QueryGroup qryGrp;
      
        
        

        public List<QryLine> LeftQryLines { get; set; }
        public List<QryLine> RightQryLines { get; set; }

        public MainViewModel()
        {
            QryLines leftQryLog =  new QryLines(@"D:\snapshot\logs\20160204170626829.log.qry");
            LeftQryLines = leftQryLog.ToList();
            QryLines rightQryLog = new QryLines(@"D:\snapshot\logs\20160204170704863.log.qry");
            RightQryLines = rightQryLog.ToList();

        }

        public List<QryLine>[] Compare(List<QryLine> left, List<QryLine> right)
        {
            List<QryLine> newLeft = new List<QryLine>();
            List<QryLine> newRight = new List<QryLine>();

            int offset = 0;
            foreach (var lline in left)
            {

                if (lline.LogInfo.CompareTo(right[offset].LogInfo) == 0)
                {
                    newLeft.Add(lline);
                    newRight.Add(lline);
                }
                else  //search the rest for something exact or then similar
                {
                    var matches = right.Find(x => x.LogInfo == lline.LogInfo);

                    if (matches == null)
                    {
                        var simMatches = right.Find(x =>  lline.LogInfo.Similiar(x.LogInfo));
                        newLeft.Add(lline);
                        newRight.Add(lline);
                    }
                    else
                    {
                        newLeft.Add(lline);
                        newRight.Add(null);

                    }
                }

                  

            }
            return new List<QryLine>[] {newLeft, newRight};



        }
    }


}
