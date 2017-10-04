namespace Palindrome {
    public class PalindromeChecker : IPalindromeChecker {
        public bool IsPalindrome(string phrase) {
            string noSpacePhrase = phrase.Replace(" ", string.Empty);
            string noSpaceLowerPhrase = noSpacePhrase.ToLower();

            return IsPalindromeInternal(noSpaceLowerPhrase, noSpaceLowerPhrase.Length - 1);
        }

        private bool IsPalindromeInternal(string phrase, int currentIndex, string invertedPhrase = "") {
            /* INVERT STRING:
             * Have new string, init as empty
             * Take last character of phrase
             * Add to new string
             * Decrement currentIndex
             * If we're at the first character of the string, return
             * Else, call self with edited phrase and new string
            */
            
            //failsafe
            if(phrase.Length == 0) {
                return true;
            }

            char lastChar = phrase[currentIndex];   //take char of phrase, starting at last
            invertedPhrase += lastChar;             //add selected char (starting at last) to the inverted phrase
            currentIndex--;                         //decrement currentIndex by 1, meaning next iteration will take preceding char
            if(currentIndex < 0) {                  //if we've hit the beginning of phrase,
                return (phrase == invertedPhrase);  //return a bool comparing phrase and invertedPhrase
            }
            
            return(IsPalindromeInternal(phrase, currentIndex, invertedPhrase)); //call self with updated phrases and index
        }
    }
}