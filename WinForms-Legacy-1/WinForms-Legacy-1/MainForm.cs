using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Legacy_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Json Files|*.json|XML Files|*.xml";
            openFileDialog1.InitialDirectory = @"c:\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadFile(openFileDialog1.FileName);
            }
        }

        private void LoadFile(string fileName)
        {
            string contents = File.ReadAllText(fileName);

            LoadData(contents);            
        }
        
        private void LoadData(string text)
        {
            JArray jArr = (JArray)JsonConvert.DeserializeObject(text);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = CountProperties(jArr);
            txtStatus.Text = $"Found {count} properties\n";

            PopulateTreeView(jArr);

            stopwatch.Stop();
            txtStatus.Text += $"Run took {stopwatch.Elapsed.TotalMilliseconds}ms";
        }

        private void PopulateTreeView(JArray jArr)
        {
            int dataIdx = 1;
            foreach (var arr in jArr.Children<JObject>())
            {
                var nod = new TreeNode($"Data {dataIdx++}");
                string tagLine = string.Empty;

                foreach (var prop in arr.Properties())
                {
                    string value = prop.Value.ToString();
                    nod.Nodes.Add(value);

                    if (prop.Name == "SubDataProperty")
                    {
                        nod.Tag = prop.Value;
                    }
                }

                if (!FindTag(nod.Tag.ToString()))
                {
                    treeView1.Nodes.Add(nod);
                }
            }
        }

        public bool FindTag(string tag)
        {                        
            foreach (TreeNode nod in treeView1.Nodes)
            {
                var tagData = JObject.Parse(nod.Tag.ToString());
                var tagCompare = JObject.Parse(tag);

                if (tagData["ImportantValue"].Value<string>() == tagCompare["ImportantValue"].Value<string>()) return true;
            }
            return false;

        }

    private int CountProperties(JArray jArr)
        {
            int allProps = 0;
            
            foreach (var arr in jArr)
            {
                allProps += arr.Count();
            }
            
            return allProps;
        }
    }
}
