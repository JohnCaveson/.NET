//Project:       Project 2
//Filename:      TextManipulationForm.cs
//Description:   Contains various listeners for the TextManipulationForm
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       March 15, 2016
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project1;
using Utils;
using System.IO;

namespace Project2
{
    /// <summary>
    /// Class containing listeners for project2 
    /// </summary>
    public partial class TextManipulationForm : Form
    {
        public static Text txt;
        public static Words wrd;
        public static SentenceList sentList;
        public static ParagraphList paraList;
        public static string Filename = "";
        public TextManipulationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// listener for the tool strip file menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string contents = "";//string to hold text file 

            //open a file to work with
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Filter = "text files|*.txt;*.text|all files|*.*";
            OpenDlg.InitialDirectory = "Project2/Text Files";
            OpenDlg.Title = "Select the File you would like to work with.";
            if (OpenDlg.ShowDialog() != DialogResult.Cancel)
            {
                Filename = OpenDlg.FileName;
            }

            //Utilize the file using the Text class
            txt = new Text(Filename);
            wrd = new Words(txt);
            sentList = new SentenceList(txt);
            paraList = new ParagraphList(txt);
            int locate = (int)numericUpDown1.Value;//holds a formatted double for pulling from the SentenceList
            int paraLocate = (int)numericUpDown2.Value;//holds a formatted double for pulling from the ParagraphList
            contents = File.ReadAllText(Filename);

            //fill textBoxes for original text and tokens
            textBox1.Text = contents;
            textBox2.Text = string.Join(Environment.NewLine, txt.GetTokens());

            //fill textBox for distinctWords
            textBox3.Text = string.Join(Environment.NewLine, wrd.GetWords());

            //fill textBoxes for Sentence and Paragraph
            textBox4.Text = sentList.Sentences[locate].FullSentence;
            textBox5.Text = sentList.Sentences[locate].WordCount.ToString();
            string s;
            string t;
            textBox6.Text = s = string.Format("{0:0.00}", sentList.Sentences[locate].AvgWordLength);
            textBox9.Text = paraList.Paragraphs[paraLocate].OriginalParagraph;
            textBox8.Text = paraList.Paragraphs[paraLocate].NumSentences.ToString();
            textBox7.Text = paraList.Paragraphs[paraLocate].NumWords.ToString();
            textBox10.Text = t = string.Format("{0:0.00}", paraList.Paragraphs[paraLocate].AvgSentenceWordCount);
        }//newToolStripMenuItem_Click(object,EventArgs)
        /// <summary>
        /// unused, won't go away
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event handler for the numeric updown for sentences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            sentList = new SentenceList(txt);
            int locate = (int)numericUpDown1.Value;
            if (locate > -1 && locate < sentList.Sentences.Count-1)
            {
                textBox4.Text = sentList.Sentences[locate].FullSentence;
                textBox5.Text = sentList.Sentences[locate].WordCount.ToString();
                string s;
                textBox6.Text = s = string.Format("{0:0.00}", sentList.Sentences[locate].AvgWordLength);
            }
            else
            {
                textBox4.Text = "There isn't anymore sentences to be displayed.";
                textBox5.Text = "0";
                textBox6.Text = "0.00";
            }
        }
        /// <summary>
        /// event handler for decrementation of sentences - button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //decrementation by button
            if (numericUpDown1.Value > 0)
            {
                numericUpDown1.Value--;
            }
            else
            {
                numericUpDown1.Value = 0;
            }
            sentList = new SentenceList(txt);
            int locate = (int)numericUpDown1.Value;
            if (locate > -1 && locate < sentList.Sentences.Count - 1)
            {
                textBox4.Text = sentList.Sentences[locate].FullSentence;
                textBox5.Text = sentList.Sentences[locate].WordCount.ToString();
                string s;
                textBox6.Text = s = string.Format("{0:0.00}", sentList.Sentences[locate].AvgWordLength);
            }
            else
            {
                textBox4.Text = "There isn't anymore sentences to be displayed.";
                textBox5.Text = "0";
                textBox6.Text = "0.00";
            }
        }
        /// <summary>
        /// event handler for incrementation of sentences - button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            sentList = new SentenceList(txt);
           
            //incrementation by button
            if(numericUpDown1.Value > sentList.Sentences.Count)
            {
                numericUpDown1.Value = sentList.Sentences.Count;
            }
            else
            {
                numericUpDown1.Value++;
            }
            int locate = (int)numericUpDown1.Value;
            if (locate > -1 && locate < sentList.Sentences.Count - 1)
            {
                textBox4.Text = sentList.Sentences[locate].FullSentence;
                textBox5.Text = sentList.Sentences[locate].WordCount.ToString();
                string s;
                textBox6.Text = s = string.Format("{0:0.00}", sentList.Sentences[locate].AvgWordLength);
            }
            else
            {
                textBox4.Text = "There isn't anymore sentences to be displayed.";
                textBox5.Text = "0";
                textBox6.Text = "0.00";
            }
        }
        /// <summary>
        /// event handler for numeric updown of paragraphs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            paraList = new ParagraphList(txt);
            int paraLocate = (int)numericUpDown2.Value; ;
            if (paraLocate > -1 && paraLocate < paraList.Paragraphs.Count)
            {
                string t;
                textBox9.Text = paraList.Paragraphs[paraLocate].OriginalParagraph;
                textBox8.Text = paraList.Paragraphs[paraLocate].NumSentences.ToString();
                textBox7.Text = paraList.Paragraphs[paraLocate].NumWords.ToString();
                textBox10.Text = t = string.Format("{0:0.00}", paraList.Paragraphs[paraLocate].AvgSentenceWordCount);
            }
            else
            {
                textBox9.Text = "There isn't anymore sentences to be displayed.";
                textBox8.Text = "0";
                textBox7.Text = "0";
                textBox6.Text = "0.00";
            }
        }
        
        /// <summary>
        /// event handler for incrementation of paragraphs by button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //incrementation by button
            paraList = new ParagraphList(txt);
            if (numericUpDown2.Value < paraList.Paragraphs.Count)
            {
                numericUpDown2.Value++;
            }
            else
            {
                numericUpDown2.Value = paraList.Paragraphs.Count;
            }
            int paraLocate = (int)numericUpDown2.Value; ;
            if (paraLocate > -1 && paraLocate < paraList.Paragraphs.Count)
            {
                string t;
                textBox9.Text = paraList.Paragraphs[paraLocate].OriginalParagraph;
                textBox8.Text = paraList.Paragraphs[paraLocate].NumSentences.ToString();
                textBox7.Text = paraList.Paragraphs[paraLocate].NumWords.ToString();
                textBox10.Text = t = string.Format("{0:0.00}", paraList.Paragraphs[paraLocate].AvgSentenceWordCount);
            }
            else
            {
                textBox9.Text = "There isn't anymore sentences to be displayed.";
                textBox8.Text = "0";
                textBox7.Text = "0";
                textBox10.Text = "0.00";
            }
        }
        /// <summary>
        /// event handler for the decrementation of pararaphs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //decrementation by button
            if(numericUpDown2.Value > 0)
            {
                numericUpDown2.Value--;
            }
            else
            {
                numericUpDown2.Value = 0;
            }
            paraList = new ParagraphList(txt);
            int paraLocate = (int)numericUpDown2.Value; ;
            if (paraLocate > -1 && paraLocate < paraList.Paragraphs.Count - 1)
            {
                string t;
                textBox9.Text = paraList.Paragraphs[paraLocate].OriginalParagraph;
                textBox8.Text = paraList.Paragraphs[paraLocate].NumSentences.ToString();
                textBox7.Text = paraList.Paragraphs[paraLocate].NumWords.ToString();
                textBox10.Text = t = string.Format("{0:0.00}", paraList.Paragraphs[paraLocate].AvgSentenceWordCount);
            }
            else
            {
                textBox9.Text = "There isn't anymore sentences to be displayed.";
                textBox8.Text = "0";
                textBox7.Text = "0";
                textBox10.Text = "0.00";
            }
        }
        /// <summary>
        /// presents a goodbye message with the information of the program and uses the user's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextManipulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = "Thank you " + UserInfoForm.user._name + " for using " + Application.ProductName + " " + Application.ProductVersion + " created by " + Application.CompanyName;
            MessageBox.Show(msg, "Goodbye Message");
        }

        /// <summary>
        /// Event handler for loading and getting the user information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextManipulationForm_Load_1(object sender, EventArgs e)
        {
            UserInfoForm UserForm = new UserInfoForm();
            UserForm.ShowDialog();
        }
        /// <summary>
        /// Tool strip about menu event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AbBox = new AboutBox1();
            AbBox.ShowDialog();
        }
        /// <summary>
        /// tick timer to update the time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Text Analysis Toolkit by Greer Goodman" .PadRight(50)+ System.DateTime.Now.ToString();
        }
        /// <summary>
        /// event handler for clicking tab 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            toolStripStatusLabel1.Text = "File: " + Filename;
        }
    }
}
