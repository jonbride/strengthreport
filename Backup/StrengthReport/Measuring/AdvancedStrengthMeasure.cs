/// <author>Adam Erdelyi (Erdelyi.Adam@stud.u-szeged.hu)</author>

using System;
using System.Collections.Generic;
using System.Text;
using KeePassLib;
using StrengthReport.Layouting;

namespace StrengthReport.Measuring {
    public class AdvancedStrengthMeasure : FunctionAbstract {
        public AdvancedStrengthMeasure() {
            m_Title = "AdvancedStrengthMeasure";
            m_Desc = "Examines the password using BuiltInStrengthMeasure and BasicStrengthMeasure functions, and looking for correspondence with the username or the reverse of username or a dictionary word.";
        }

        /// <summary>
        /// Make reverse the string "abcd"=>"dcba"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string Reverse(string s) {
            string rev = string.Empty;
            for (int i = s.Length - 1; i >= 0; i--) {
                rev += s[i];
            }
            return rev;
        }

        public override PasswordQuality Evaluate(PwEntry entry) {
            string usrname = GetValue(entry, EntryDataType.UserName);
            string pwd = GetValue(entry, EntryDataType.Password);
            BuiltInStrengthMeasure bism = new BuiltInStrengthMeasure();
            BasicStrengthMeasure bsm = new BasicStrengthMeasure();
            int strengthA = (int)bism.Evaluate(entry);
            int strengthB = (int)bsm.Evaluate(entry);
            int strength = (int)Math.Round((decimal)(strengthA + strengthB) / 2);
            bool containsDictWord = false;
            bool containsPartOfUsrName = false;
            bool containsReverseUsrName = false;
            bool containsReversePartOfUsrName = false;
            string reverseUsername = Reverse(usrname);
            try {

                
                /*
                 * I have put into resources with GZip compression, instead of file.(Peter Torok)
                 * If you place it uncompressed use this:
                 * System.IO.StringReader dict = new System.IO.StringReader(Resources.dictionary);
                 */
                
                
                System.IO.Stream resource_stream = new System.IO.MemoryStream(Resources.dictionary_gzip);
                System.IO.Compression.GZipStream gz_stream = new System.IO.Compression.GZipStream(resource_stream, System.IO.Compression.CompressionMode.Decompress);
                System.IO.StreamReader dict = new System.IO.StreamReader(gz_stream);
                

                //System.IO.FileStream fileStream = System.IO.File.OpenRead("dictionary.txt");
                //System.IO.StreamReader dict = new System.IO.StreamReader(fileStream);
                //System.IO.StringReader dict = new System.IO.StringReader(streamReader.ReadToEnd());
                
                //TEST
                //System.Windows.Forms.MessageBox.Show(dict.ReadLine());

                string dictWord = null;
                while ((dictWord = dict.ReadLine()) != null)
                    if (pwd.Contains(dictWord)) containsDictWord = true;
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show("An error has occured!\nDetails: " + e.ToString());
                return PasswordQuality.Error;
            }
            for (int i = 3; i < usrname.Length; i++)
                for (int j = 0; j < usrname.Length - i; j++)
                    if (pwd.Contains(usrname.Substring(j, i))) containsPartOfUsrName = true;
            for (int i = 3; i <= reverseUsername.Length; i++)
                for (int j = 0; j < reverseUsername.Length - i; j++)
                    if (pwd.Contains(reverseUsername.Substring(j, i))) containsReverseUsrName = true;
            for (int i = 3; i < usrname.Length; i++)
                for (int j = 0; j < usrname.Length - i; j++)
                    if (pwd.Contains(Reverse(usrname.Substring(j, i)))) containsReversePartOfUsrName = true;
            if (pwd.Contains(usrname) || containsPartOfUsrName || containsReverseUsrName || containsReversePartOfUsrName) strength--;
            if (containsDictWord) strength--;
            if (strength < 0) strength = 0;
            return (PasswordQuality)strength;
        }

    }
}
