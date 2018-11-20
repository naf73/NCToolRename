using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NCToolRename;

namespace UnitTestNCToolRename
{
    [TestClass]
    public class UnitTestFormMain
    {
        [TestMethod]
        public void TestRenameCommandToolLine_ToolCall()
        {
            #region Arrange

            string format = "\"ULA{0:d6}\"";
            string source = "36 TOOL CALL 10 Z S1200; (FACE_MILL_D50_ROUGH)";
            string expected = "36 TOOL CALL \"ULA000010\" Z S1200; (FACE_MILL_D50_ROUGH)";
            FormMain f = new FormMain();


            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]
        public void TestRenameCommandToolLine_ToolDef()
        {
            #region Arrange

            string format = "\"ULA{0:d6}\"";
            string source = "40 TOOL DEF 116 ; ( DRILL_D8 )";
            string expected = "40 TOOL DEF \"ULA000116\" ; ( DRILL_D8 )";
            FormMain f = new FormMain();


            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]
        public void TestRenameCommandToolLine_TooCall_Zero()
        {
            #region Arrange

            string format = "\"ULA{0:d6}\"";
            string source = "232 TOOL CALL 0";
            string expected = "232 TOOL CALL 0";
            FormMain f = new FormMain();


            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }


        [TestMethod]
        public void TestRenameCommandToolLine_OtherLine()
        {
            #region Arrange

            string format = "\"ULA{0:d6}\"";
            string source = "221 L  X+0  Y-300 FMAX";
            string expected = "221 L  X+0  Y-300 FMAX";
            FormMain f = new FormMain();


            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }
    }
}
