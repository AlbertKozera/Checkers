using NLog;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.Forms;

namespace Warcaby.CSharp.Service
{
    public class LoggerService
    {
        public static long timer;
        public static Logger logger = LogManager.GetCurrentClassLogger();
        PictureBox fieldThrough;

        public void WriteLogger(bool whiteTurn, int indexFrom, int indexThrough, int indexTo, PictureBox fieldFrom, PictureBox fieldTo)
        {
            string round;
            if (!whiteTurn)
                round = Constant.WHITE;
            else
                round = Constant.RED;

            if (indexThrough == 0)
            {
                if(round == Constant.WHITE)
                {
                    logger.Info("===> indexFrom: {0} " +
                    "|| indexThrough:  - " +
                    "|| indexTo: {1} " +
                    "|| fieldFrom: {2} " +
                    "|| fieldThrough:     -    " +
                    "|| fieldTo: {3} " +
                    "|| turn: {4} " +
                    "|| timer: {5}", indexFrom, indexTo, fieldFrom.Name, fieldTo.Name, round, timer);
                } 
                else
                {
                    logger.Info("===> indexFrom: {0} " +
                    "|| indexThrough:  - " +
                    "|| indexTo: {1} " +
                    "|| fieldFrom: {2} " +
                    "|| fieldThrough:     -    " +
                    "|| fieldTo: {3} " +
                    "|| turn: {4}   " +
                    "|| timer: {5}", indexFrom, indexTo, fieldFrom.Name, fieldTo.Name, round, timer);
                }
                
            } 
            else
            {
                fieldThrough = Extend.GetFieldByIndex(indexThrough);
                if (round == Constant.WHITE)
                {
                    logger.Info("===> indexFrom: {0} " +
                    "|| indexThrough: {1} " +
                    "|| indexTo: {2} " +
                    "|| fieldFrom: {3} " +
                    "|| fieldThrough: {4} " +
                    "|| fieldTo: {5} " +
                    "|| turn: {6} " +
                    "|| timer: {7}", indexFrom, indexThrough, indexTo, fieldFrom.Name, fieldThrough.Name, fieldTo.Name, round, timer);
                }
                 else
                {
                    logger.Info("===> indexFrom: {0} " +
                    "|| indexThrough: {1} " +
                    "|| indexTo: {2} " +
                    "|| fieldFrom: {3} " +
                    "|| fieldThrough: {4} " +
                    "|| fieldTo: {5} " +
                    "|| turn: {6}   " +
                    "|| timer: {7}", indexFrom, indexThrough, indexTo, fieldFrom.Name, fieldThrough.Name, fieldTo.Name, round, timer);
                }
            }
        }
    }
}
