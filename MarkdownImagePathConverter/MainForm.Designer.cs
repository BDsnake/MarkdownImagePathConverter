using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace WindowsFormsAppFramework
{
    public partial class MainForm : Form
    {

        private void SetupUI()
        {
            // 创建文件选择控件
            var lblFilePath = new Label { Text = "Markdown 文件路径:", Left = 10, Top = 20, Width = 140 };
            txtFilePath = new TextBox { Left = 160, Top = 20, Width = 300 };
            var btnSelectFile = new Button { Text = "选择文件", Left = 470, Top = 18, Width = 80 };
            btnSelectFile.Click += btnSelectFile_Click;

            // 创建图床地址输入控件
            var lblRemotePath = new Label { Text = "图床地址 (不加结尾/):", Left = 10, Top = 60, Width = 140 };
            txtRemotePath = new TextBox { Left = 160, Top = 60, Width = 300 };

            // 创建本地路径输入控件
            var lblLocalPath = new Label { Text = "本地路径 (相对路径):", Left = 10, Top = 100, Width = 140 };
            txtLocalPath = new TextBox { Left = 160, Top = 100, Width = 300 };

            // 自动生成本地路径按钮
            var btnGenerateLocalPath = new Button { Text = "自动生成本地路径", Left = 160, Top = 140, Width = 140 };
            btnGenerateLocalPath.Click += btnGenerateLocalPath_Click;

            // 创建执行替换按钮
            var btnReplaceToLocal = new Button { Text = "替换为本地路径", Left = 320, Top = 140, Width = 140 };
            btnReplaceToLocal.Click += btnReplaceToLocal_Click;

            var btnReplaceToRemote = new Button { Text = "替换为图床路径", Left = 470, Top = 140, Width = 140 };
            btnReplaceToRemote.Click += btnReplaceToRemote_Click;

            // 将控件添加到窗体
            Controls.Add(lblFilePath);
            Controls.Add(txtFilePath);
            Controls.Add(btnSelectFile);
            Controls.Add(lblRemotePath);
            Controls.Add(txtRemotePath);
            Controls.Add(lblLocalPath);
            Controls.Add(txtLocalPath);
            Controls.Add(btnGenerateLocalPath);
            Controls.Add(btnReplaceToLocal);
            Controls.Add(btnReplaceToRemote);

            // 设置窗体属性
            Text = "Markdown 图片路径替换工具";
            Size = new System.Drawing.Size(650, 240);
        }

        // 选择 .md 文件
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        // 自动生成相对的本地路径
        private void btnGenerateLocalPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("请先选择 Markdown 文件路径！");
                return;
            }

            string filePath = txtFilePath.Text;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

            // 生成相对路径（相对于 .md 文件的目录）
            txtLocalPath.Text = $"{fileNameWithoutExtension}.assets";
        }

        // 将图床地址替换为本地相对路径
        private void btnReplaceToLocal_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            string remotePath = txtRemotePath.Text;
            string localPath = txtLocalPath.Text;

            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(remotePath) || string.IsNullOrEmpty(localPath))
            {
                MessageBox.Show("请确保所有配置项都已填写！");
                return;
            }

            string content = File.ReadAllText(filePath);

            string updatedContent = Regex.Replace(content, $@"\!\[img\]\({Regex.Escape(remotePath)}/(.+?)\)",
                $"![img]({localPath}/$1)");

            File.WriteAllText(filePath, updatedContent);
            MessageBox.Show("图片路径已成功替换为本地相对路径！");
        }

        // 将本地路径替换为图床地址
        private void btnReplaceToRemote_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            string remotePath = txtRemotePath.Text;
            string localPath = txtLocalPath.Text;

            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(remotePath) || string.IsNullOrEmpty(localPath))
            {
                MessageBox.Show("请确保所有配置项都已填写！");
                return;
            }

            string content = File.ReadAllText(filePath);

            string updatedContent = Regex.Replace(content, $@"\!\[img\]\({Regex.Escape(localPath)}/(.+?)\)",
                $"![img]({remotePath}/$1)");

            File.WriteAllText(filePath, updatedContent);

            MessageBox.Show("图片路径已成功替换为图床地址！");
        }

        // 定义控件
        private TextBox txtFilePath;
        private TextBox txtRemotePath;
        private TextBox txtLocalPath;
    }
}