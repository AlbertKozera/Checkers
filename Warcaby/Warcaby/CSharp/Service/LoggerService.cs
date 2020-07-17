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
                logger.Info("===> turn: {0} " +
                "|| indexFrom: {1} " +
                "|| indexThrough: {2} " +
                "|| indexTo: {3} " +
                "|| fieldFrom: {4} " +
                "|| fieldTo: {5} " +
                "|| timer: {6} <===|", round, indexFrom, indexThrough, indexTo, fieldFrom.Name,  fieldTo.Name, timer);
            }
            else
            {
                fieldThrough = Extend.GetFieldByIndex(indexThrough);
                logger.Info("===> turn: {0} " +
                    "|| indexFrom: {1} " +
                    "|| indexThrough: {2} " +
                    "|| indexTo: {3} " +
                    "|| fieldFrom: {4} " +
                    "|| fieldThrough: {5}" +
                    "|| fieldTo: {6} " +
                    "|| timer: {7} <===|", round, indexFrom, indexThrough, indexTo, fieldFrom.Name, fieldThrough.Name, fieldTo.Name, timer);
            }
        }
    }
}
