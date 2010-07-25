/// <author>Adam Erdelyi (Erdelyi.Adam@stud.u-szeged.hu)</author>

using System;
using System.Collections.Generic;
using System.Text;
using KeePassLib;
using StrengthReport.Layouting;

namespace StrengthReport.Measuring {
    public class BuiltInStrengthMeasure : FunctionAbstract {
        public BuiltInStrengthMeasure() {
            m_Title = "BuiltInStrengthMeasure";
            m_Desc = "Examines the password strength using KeePass's built-in QualityEstimation class.";
        }

        public override PasswordQuality Evaluate(PwEntry entry) {
            string pwd = GetValue(entry, EntryDataType.Password);
            uint pwdBitStrength = KeePassLib.Cryptography.QualityEstimation.EstimatePasswordBits(pwd.ToCharArray());
            if (pwdBitStrength < 28) {
                return PasswordQuality.VeryWeak;
            } else if (pwdBitStrength < 36) {
                return PasswordQuality.Weak;
            } else if (pwdBitStrength < 60) {
                return PasswordQuality.Better;
            } else if (pwdBitStrength < 100) {
                return PasswordQuality.Medium;
            } else if (pwdBitStrength < 128) {
                return PasswordQuality.Strong;
            } else {
                return PasswordQuality.Strongest;
            }
        }

    }
}
