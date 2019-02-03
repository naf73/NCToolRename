/*
Developed 20.11.18 by NAF e-mail: alexnejchev@mail.ru
*/
using NCToolRename.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCToolRename
{
    public partial class FormMain : Form
    {
        #region Variables

        List<string> files = new List<string>();

        #endregion

        #region Constructors

        public FormMain()
        {
            InitializeComponent();
            rootFolderTextBox.Text = Settings.Default.SelectedPath;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                VersionToolStripStatusLabel.Text = string.Format("version: {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString());
            }
            else
            {
                VersionToolStripStatusLabel.Text = "Debug mode";
            }

        }

        #endregion

        #region Events

        /// <summary>
        /// Событие нажатия кнопки "Обзор"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderBrowserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(Settings.Default.SelectedPath)) FBD.SelectedPath = Settings.Default.SelectedPath;
            if (FBD.ShowDialog()==DialogResult.OK)
            {
                rootFolderTextBox.Text = FBD.SelectedPath;
                Settings.Default.SelectedPath = FBD.SelectedPath;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Событие нажатия кнопки "переименовать инструмент в УП"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameToolsButton_Click(object sender, EventArgs e)
        {
            outputRichTextBox.Clear();
            files.Clear();

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                Output(string.Format("Сканирование папки: {0}", rootFolderTextBox.Text));
                FileSearch(rootFolderTextBox.Text, "*.h");
                Output("Сканирование папки завершено!!!");
                Output(string.Format("Кол-во обнаруженных файлов файлов: {0} шт", files.Count));
                renameNCToolStripProgressBar.Maximum = files.Count;

                this.Cursor = System.Windows.Forms.Cursors.Default;

                if (MessageBox.Show("Переименовать обнаруженные файлы?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Output("Процесс переименования инструмента запущен ...");

                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                    foreach (var file in files)
                    {
                        RenameToolsNC(file);
                        renameNCToolStripProgressBar.Value++;
                    }

                    Output("Процесс переименования инструмента завершен!!!");
                    Output(string.Format("Кол-во обработанных файлов: {0} шт", renameNCToolStripProgressBar.Value));

                    if (MessageBox.Show("Инструмент во всех файлах переименован", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        renameNCToolStripProgressBar.Value = 0;
                    }

                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    Output("Отмена пользователя");
                }            
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Output(ex.Message + Environment.NewLine + ex.StackTrace);
            }            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод выводи в поле лога сообщение
        /// </summary>
        /// <param name="message"></param>
        private void Output(string message)
        {
            outputRichTextBox.AppendText(message + Environment.NewLine);
            outputRichTextBox.SelectionStart = outputRichTextBox.Text.Length;
            outputRichTextBox.ScrollToCaret();
        }

        /// <summary>
        /// Метод заполняет список файлов из указанной папки и ее подпапок
        /// </summary>
        /// <param name="dir">папка поиска</param>
        private void FileSearch(string dir, string extension = "*")
        {
            if (!Directory.Exists(dir)) throw new ArgumentException("dir isn't exists");

            try
            {
                DirectoryInfo DI = new DirectoryInfo(dir);
                DirectoryInfo[] subDir = DI.GetDirectories();

                for (int i = 0; i < subDir.Length; i++)
                {
                    this.FileSearch(subDir[i].FullName, extension);
                }

                FileInfo[] FI = DI.GetFiles(extension);
                for (int i = 0; i < FI.Length; i++)
                {
                    files.Add(FI[i].FullName);
                    Output(FI[i].FullName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод переименовывает все TOOL в указанном файле
        /// </summary>
        /// <param name="pathFile">полный путь к файлу NC с расширением *.h</param>
        private void RenameToolsNC(string pathFile)
        {
            if (!File.Exists(pathFile)) throw new ArgumentException("file isn't exists");

            try
            {
                string format = "\"ULA{0:d6}\"";
                //string tempPathfile = pathFile + "_tmp";
                //File.Copy(pathFile, tempPathfile);

                List<string> lines = new List<string>();

                using (StreamReader sr = new StreamReader(pathFile, System.Text.Encoding.Default))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                using (StreamWriter sw = new StreamWriter(pathFile, false, System.Text.Encoding.Default))
                {
                    foreach (var line in lines)
                    {
                        sw.WriteLine(RenameCommandToolLine(line, format));
                    }
                }
                //File.Delete(tempPathfile);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Функция переименовывает строку с вызовом инструмента
        /// </summary>
        /// <param name="line">строка УП</param>
        /// <param name="format">формат переименования</param>
        /// <example>format = "ULA{0:d6}"</example>
        /// <return>строку NC</returns>
        public string RenameCommandToolLine(string line, string format)
        {
            string[] words = line.Split(' ');

            if(words[1] == "TOOL" && words[2] == "CALL" ||
               words[1] == "TOOL" && words[2] == "DEF")
            {
                int.TryParse(words[3], out int numberTool);

                if(numberTool == 0)
                {
                    return line;
                }
                else
                {
                    words[3] = string.Format(format, numberTool);
                    return string.Join(" ", words);
                }               
            }
            else
            {
                return line;
            }                
        }

        #endregion

        
    }
}
