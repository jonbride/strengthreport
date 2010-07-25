/// <author>Adam Erdelyi (Erdelyi.Adam@stud.u-szeged.hu)</author>

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using KeePassLib;
using StrengthReport.Layouting;

namespace StrengthReport.Measuring {
    public class BasicStrengthMeasure : FunctionAbstract {
        public BasicStrengthMeasure() {
            m_Title = "BasicStrengthMeasure";
            m_Desc = "Examines the password length and whether it contains lower and uppercase carachters, numbers, special characters.";
        }

        public override PasswordQuality Evaluate(PwEntry entry) {
            string pwd = GetValue(entry, EntryDataType.Password);
            int strength = 0;
            Regex patternLowerCase = new Regex("[a-z]");
            Regex patternUpperCase = new Regex("[A-Z]");
            Regex patternNumber = new Regex("[0-9]");
            Regex patternSpecialChar = new Regex("[!,@,#,$,%,^,&,*,?,_,~,-,(,)]");
            if (pwd.Length > 6) strength++;
            if (pwd.Length > 14) strength++;
            if (patternLowerCase.IsMatch(pwd) && patternUpperCase.IsMatch(pwd)) strength++;
            if (patternNumber.IsMatch(pwd)) strength++;
            if (patternSpecialChar.IsMatch(pwd)) strength++;
            return (PasswordQuality)strength;
        }

    }
}
