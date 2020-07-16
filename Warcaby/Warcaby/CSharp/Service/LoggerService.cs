using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warcaby.CSharp.Game.Context;
using Warcaby.Forms;

namespace Warcaby.CSharp.Service
{
    public class LoggerService
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        
        public void WriteLogger(bool whiteTurn, int indexFrom, int indexThrough, int indexTo, PictureBox fieldFrom, PictureBox fieldTo, long timer)
        {
            if (indexThrough == 0)
            {
                var fieldThrough = 0;
            }
            string round;
            if (whiteTurn)
                round = Constant.WHITE;
            else
                round = Constant.RED;
            logger.Info(" || turn: {0} " +
                "indexFrom: {1} " +
                "indexThrough: {2} " +
                "indexTo: {3} " +
                "fieldFrom: {4} " +
                "fieldThrough:  " +
                "fieldTo: {5} " +
                "timer: {6}", round, indexFrom, indexThrough, indexTo, fieldFrom.Name, fieldTo.Name, timer);
        }
    }
}
