using NLog;
using System.Windows.Forms;
using Warcaby.CSharp.Config;


namespace Warcaby.CSharp.Service
{
    public class LoggerService
    {
        public static long timer;
        public static Logger logger = LogManager.GetCurrentClassLogger();
        
        public void WriteLogger(bool whiteTurn, int indexFrom, int indexThrough, int indexTo, PictureBox fieldFrom, PictureBox fieldTo)
        {
            string round;
            if (!whiteTurn)
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
