using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NCToolRename;

namespace UnitTestNCToolRename
{
    [TestClass]
    public class UnitTestFormMain
    {
        readonly string format = "\"ULA{0:d6}\"";
        readonly FormMain f = new FormMain();

        [TestMethod]
        public void TestRenameCommandToolLine_ToolCall()
        {
            #region Arrange

            string source = "36 TOOL CALL 10 Z S1200; (FACE_MILL_D50_ROUGH)";
            string expected = "36 TOOL CALL \"ULA000010\" Z S1200; (FACE_MILL_D50_ROUGH)";

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

            string source = "40 TOOL DEF 116 ; ( DRILL_D8 )";
            string expected = "40 TOOL DEF \"ULA000116\" ; ( DRILL_D8 )";

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

            string source = "232 TOOL CALL 0";
            string expected = "232 TOOL CALL 0";

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

            string source = "221 L  X+0  Y-300 FMAX";
            string expected = "221 L  X+0  Y-300 FMAX";

            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]
        public void TestTestRenameCommandToolLine_CALL_ULA()
        {
            #region Arrange

            string source = "1625 TOOL CALL \"ULA000339\" Z S2900 ; ( DRILL_D3.3_LONG )";
            string expected = "1625 TOOL CALL \"ULA000339\" Z S2900 ; ( DRILL_D3.3_LONG )";

            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]
        public void TestTestRenameCommandToolLine_DEF_ULA()
        {
            #region Arrange

            string source = "1629 TOOL DEF \"ULA000106\" ; ( DRILL_D5X8_L247 )";
            string expected = "1629 TOOL DEF \"ULA000106\" ; ( DRILL_D5X8_L247 )";

            #endregion

            #region Action

            string actual = f.RenameCommandToolLine(source, format);

            #endregion

            #region Assert

            Assert.AreEqual(expected, actual);

            #endregion
        }

        [TestMethod]
        public void TestTestRenameCommandToolLine_TOOLCALL_Change_Spindle()
        {
            #region Arrange

            string source = "1410 TOOL CALL  Z S3300 ; ( SPOTDRILL_D16 )";
            string expected = "1410 TOOL CALL  Z S3300 ; ( SPOTDRILL_D16 )";

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
