using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class SMSEncryptor
    {
        public static string Encrypt(string StringToEncrypt)
        {
            string Encrypt = String.Empty;
            double dblCountLength = 0;
            int intRandomNumber = 0;
            string strCurrentChar = String.Empty;
            int intAscCurrentChar = 0;
            int intInverseAsc = 0;
            int intAddNinetyNine = 0;
            double dblMultiRandom = 0;
            double dblWithRandom = 0;
            int intCountPower = 0;
            int intPower = 0;
            string strConvertToBase = String.Empty;
            const int intLowerBounds = 10;
            const int intUpperBounds = 28;

            try
            {



                // Store the current value of the mouse pointer
                //intMousePointer = Convert.ToInt32(System.Windows.Forms.Application.ActiveForm.Cursor);
                // Change the mousepointer to an hourglass.
                //Screen.MousePointer = Cursors.WaitCursor;
                // Start a For...Next loop that counts through the length of the parameter
                // 'StringToEncrypt'
                for (dblCountLength = 1; dblCountLength <= StringToEncrypt.Length; dblCountLength += 1)
                {
                    // Make sure random numbers do not hold any pattern
                    VBMath.Randomize();
                    // Choose a random integer between the constant 'intLowerBounds' and the
                    // constant 'intUpperBounds' and store it in 'intRandomNumber'
                    intRandomNumber = Convert.ToInt32(Conversion.Int((intUpperBounds - intLowerBounds + 1) * VBMath.Rnd() +
                        intLowerBounds));
                    // Select the next character in the parameter 'StringToEncrypt' based
                    // on the value of 'dblCountLength'
                    strCurrentChar = StringToEncrypt.Substring(Convert.ToInt32(dblCountLength) - 1, 1);
                    // Find the ascii number associated with 'strCurrentChar'
                    intAscCurrentChar = (short)(strCurrentChar[0]);
                    // Inverse the order of the numbers between 1 and 255 by subtracting the
                    // number from 256 (ie 1 turns into 255, 2 turns into 254, etc)
                    intInverseAsc = 256 - intAscCurrentChar;
                    // Add 99 to the number
                    intAddNinetyNine = intInverseAsc + 99;
                    // Multiply the integers 'intAddNinetyNine' and 'intRandomNumber'
                    // together
                    dblMultiRandom = intAddNinetyNine * intRandomNumber;
                    // Insert the random number into the middle of the result of
                    // 'dbsMultiRandom'
                    dblWithRandom = Convert.ToDouble(Convert.ToString(dblMultiRandom).Substring(1 - 1, 2) + intRandomNumber +
                        Convert.ToString(dblMultiRandom).Substring(3 - 1, 2));
                    // Start a For...Next loop that counts through the viable powers of 93
                    // to be used to convert 'dblWithRandom' from base 10 to base 93
                    for (intCountPower = 0; intCountPower <= 5; intCountPower += 1)
                    {
                        // Test to see if 'dblWithRandom' is large enough to accept the
                        // current power of 93 based on 'intCountPower'
                        if (dblWithRandom / (Math.Pow(93, intCountPower)) >= 1)
                        {
                            // Store the power into the 'intPower' variable
                            intPower = intCountPower;
                            // Stop the test of 'dblWithRandom'
                        }
                        // Go to the next highest power of 93
                    }
                    // Let 'strConvertToBase' be equal to an empty string.
                    strConvertToBase = "";
                    // Start a For...Next loop that counts down through the viable powers
                    // of 93 based on the results of the test above
                    for (intCountPower = intPower; intCountPower >= 0; intCountPower += -1)
                    {
                        // Divide 'dblWithRandom' by 93 to the power of 'intCountPower', add
                        // 33, take only the integer, find the character associated with the
                        // number, and place it into the variable called 'strConvertToBase'
                        strConvertToBase = strConvertToBase +
                            (char)(Convert.ToInt32(Conversion.Int(dblWithRandom / (Math.Pow(93, intCountPower))) + 33));
                        // Let 'dblWithRandom' be equal to the remainder of the previous
                        // process
                        dblWithRandom = Convert.ToInt32(dblWithRandom) % Convert.ToInt32(Math.Pow(93, intCountPower));
                        // Go to the next lowest power of 93
                    }
                    // Insert at the end of the function 'Encrypt' one character
                    // representing the length of 'strConvertToBase' and the value of
                    // 'strConvertToBase'
                    Encrypt = Encrypt + strConvertToBase.Length + strConvertToBase;
                    // Go to the next character in the variable 'StringToEncrypt'
                }
                // Return the mousepointer to the value that it was before the function
                // started
                //Screen.MousePointer = intMousePointer;
                // Stop execution of this function
                return Encrypt;

            }
            catch (Exception exc)
            {
                // Begin selecting occurences of an error number when an error has occured
                switch (Information.Err().Number)
                {
                    // For all occurences of an error number, do what follows
                    default:
                        // Erase the error
                        Information.Err().Clear();
                        // Go to the line of code that follows the error
                        // WARNING: Resume Next is not supported
                        // Stop selecting occurences of an error number
                        break;
                }

            }
            return Encrypt;
        }

        public static string Decrypt(String StringToDecrypt)
        {
            string Decrypt = "";

            try
            {
                int intMousePointer;
                double dblCountLength;
                int intLengthChar = 0;
                string strCurrentChar = "";
                double dblCurrentChar = 0;
                int intCountChar;
                int intRandomSeed = 0;
                int intBeforeMulti = 0;
                int intAfterMulti = 0;
                int intSubNinetyNine = 0;
                int intInverseAsc = 0;

                // Store the current value of the mouse pointer
                // Change the mousepointer to an hourglass
                // Start a For...Next loop that counts through the length of the parameter
                // StringToDecrypt'
                for (dblCountLength = 1; dblCountLength <= StringToDecrypt.Length; dblCountLength++)
                {
                    // Place the character at 'dblCountLength' into the variable
                    // intLengthChar'
                    intLengthChar = int.Parse(Strings.Mid(StringToDecrypt, Convert.ToInt32(dblCountLength), 1));
                    // Place the string 'intLengthChar' long, directly following
                    // dblCountLength' into the variable 'strCurrentChar'
                    strCurrentChar = Strings.Mid(StringToDecrypt, Convert.ToInt32(dblCountLength + 1), intLengthChar);
                    // Let the variable 'dblCurrentChar' be equal to 0
                    dblCurrentChar = 0;
                    // Start a For...Next loop that counts through the length of the
                    // variable 'strCurrentChar'
                    for (intCountChar = 1; intCountChar <= strCurrentChar.Length; intCountChar++)
                    {
                        // Convert the variable 'strCurrent' from base 98 to base 10 and
                        // place the value into the variable 'dblCurrentChar'
                        dblCurrentChar += (Convert.ToByte(Strings.Mid(strCurrentChar, intCountChar, 1)[0]) - 33) * (Math.Pow(93, (strCurrentChar.Length - intCountChar)));
                        // Go to the next character in the variable 'strCurrentChar'
                    } // intCountChar
                      // Determine the random number that was used in the 'Encrypt' function
                    var test = Strings.Mid(Convert.ToString(dblCurrentChar), 3, 2);
                    intRandomSeed = int.Parse(Strings.Mid(Convert.ToString(dblCurrentChar), 3, 2));
                    // Determine the number that represents the character without the random
                    // seed
                    intBeforeMulti = int.Parse(Strings.Mid(Convert.ToString(dblCurrentChar), 1, 2) + Strings.Mid(Convert.ToString(dblCurrentChar), 5, 2));
                    // Divide the number that represents the character by the random seed
                    // and place that value into the variable 'intAfterMulti'
                    var AfterMulti = double.Parse(intBeforeMulti.ToString()) / intRandomSeed;
                    intAfterMulti = Convert.ToInt32(AfterMulti);
                    // Subtract 99 from the variable 'intAfterMulti' and place that value
                    // into the variable 'intSubNinetyNine'
                    intSubNinetyNine = intAfterMulti - 99;
                    // Subtract the variable 'intSubNinetyNine' from 256 and place that
                    // value into the variable 'intInverseAsc'
                    intInverseAsc = 256 - intSubNinetyNine;
                    // Place the character equivalent of the variable 'intInverseAsc' at the
                    // end of the function 'Decrypt'
                    Decrypt = Decrypt + Convert.ToString(Convert.ToChar(intInverseAsc));
                    // Add the variable 'intLengthChar' to 'dblCountLength' to ensure that
                    // the next character is being analyzed
                    dblCountLength += intLengthChar;
                    // Go to the next character in the variable 'StringToEncrypt'
                } // dblCountLength
                  // Return the mousepointer to the value that it was before the function
                  // started
                return Decrypt;

            }
            catch (Exception ex)
            {   // ErrHandler:
                // Begin selecting occurences of an error number when an error has occured
                switch (Information.Err().Number)
                {
                    // For all occurences of an error number, do what follows

                    default:
                        {
                            // Erase the error
                            Information.Err().Clear();
                            // Go to the line of code that follows the error
                            {/*? Resume Next; */}
                            // Stop selecting occurences of an error number
                            break;
                        }
                } //end switch

            }
            return Decrypt;
        }

    }
}
